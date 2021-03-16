using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MPGTracker2.Data;
using MPGTracker2.Models;

namespace MPGTracker2.Controllers
{
    public class FillupsController : Controller
    {
        private readonly MPGContext _context;

        public FillupsController(MPGContext context)
        {
            _context = context;
        }

        // GET: Fillups
        public async Task<IActionResult> Index(string OwnerFilter = "All", string MakeFilter = "All", string ModelFilter = "All", DateTime? DateFilledFilter = null, DateTime? DateEmptyFilter = null )
        {
            
            var FillupTable = from fillups in _context.Fillups
                                     join vehicles in _context.Vehicles
                                         on fillups.VehicleID equals vehicles.ID
                                     join owners in _context.Owners
                                         on vehicles.OwnerID equals owners.ID
                                     select new FillupsWithVehiclesAndOwners
                                     {
                                         OwnerName = owners.Name,
                                         VehicleYear = vehicles.Year,
                                         VehicleMake = vehicles.Make,
                                         VehicleModel = vehicles.Model,
                                         DateFilled = fillups.DateFilled,
                                         DateEmpty = fillups.DateEmpty,
                                         GallonsFilled = fillups.GallonsFilled,
                                         MilesDriven = fillups.MilesDriven,
                                         FillupsID = fillups.ID,
                                         MPG = (decimal)fillups.MilesDriven / (decimal)fillups.GallonsFilled,
                                     };
            ViewBag.Owners = await _context.Owners.Select(o => o.Name).Distinct().ToListAsync();
            List<string> Makes = new List<string>();
            foreach(var brand in Enum.GetValues(typeof(Make)))
            {
                Makes.Add(brand.ToString());
            }
            ViewBag.Makes = Makes;
            ViewBag.Models = await FillupTable.Select(o => o.VehicleModel).Distinct().ToListAsync();

            if (OwnerFilter != "All")
            {
                FillupTable = FillupTable.Where(o => o.OwnerName == OwnerFilter);
                                          
            }
            //if (MakeFilter != "All")
            //{
            //    FillupTable = FillupTable.Where(o => Enum. == MakeFilter);
            //}//Can't get to work

            ViewBag.AverageMPG = "";
            if (ModelFilter != "All")
            {
                FillupTable = FillupTable.Where(o => o.VehicleModel == ModelFilter);
            }
            if (DateFilledFilter != null  && DateEmptyFilter != null)
            {
                FillupTable = FillupTable.Where(o => o.DateFilled >= DateFilledFilter && o.DateEmpty <= DateEmptyFilter);
                CaluculateAverage(FillupTable);
            }
            else if (DateFilledFilter == null && DateEmptyFilter != null)
            {
                FillupTable = FillupTable.Where(o => o.DateEmpty < DateEmptyFilter);
                CaluculateAverage(FillupTable);
            }
            else if (DateFilledFilter != null && DateEmptyFilter == null)
            {
                FillupTable = FillupTable.Where(o => o.DateFilled <= DateFilledFilter);
                CaluculateAverage(FillupTable);
            }


            return View(FillupTable);
        }

        private void CaluculateAverage(IQueryable<FillupsWithVehiclesAndOwners> FillupTable)
        {
            foreach (var row in FillupTable)
            {
                decimal averageMPG = FillupTable.Sum(o => o.MPG);
                averageMPG = averageMPG / FillupTable.Count();
                ViewBag.AverageMPG = $"The Average MPG for this date range is {Math.Round(averageMPG)}.";
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Index()
        //{

        //    return View();
        //}
        // GET: Fillups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fillup = await _context.Fillups
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fillup == null)
            {
                return NotFound();
            }

            return View(fillup);
        }

        // GET: Fillups/Create
        public IActionResult Create(int vehicleID, string ownerName, DateTime vehicleYear, Make vehicleMake, string vehicleModel)
        {
            var model = new AddFIllupVM
            {
                VehicleID = vehicleID,
                OwnerName = ownerName,
                VehicleYear = vehicleYear,
                VehicleMake = vehicleMake,
                VehicleModel = vehicleModel
            };
            return View(model);
        }

        // POST: Fillups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,VehicleID,DateFilled,DateEmpty,GallonsFilled,MilesDriven")]  Fillup fillup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fillup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fillup);
        }

        // GET: Fillups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fillup = await _context.Fillups.FindAsync(id);
            if (fillup == null)
            {
                return NotFound();
            }
            return View(fillup);
        }

        // POST: Fillups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DateFilled,DateEmpty,GallonsFilled,MilesDriven")] Fillup fillup)
        {
            if (id != fillup.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fillup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FillupExists(fillup.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fillup);
        }

        // GET: Fillups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fillup = await _context.Fillups
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fillup == null)
            {
                return NotFound();
            }

            return View(fillup);
        }

        // POST: Fillups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fillup = await _context.Fillups.FindAsync(id);
            _context.Fillups.Remove(fillup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FillupExists(int id)
        {
            return _context.Fillups.Any(e => e.ID == id);
        }
    }
}
