using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPGTracker2.Models
{
    public class FillupsWithVehiclesAndOwners
    {
        public string OwnerName { get; set; }
        public DateTime VehicleYear { get; set; }
        public Make VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public DateTime DateFilled { get; set; }
        public DateTime DateEmpty { get; set; }
        public int GallonsFilled { get; set; }
        public int MilesDriven { get; set; }
        public decimal MPG { get; set; }
        public int FillupsID { get; set; }
        public SelectList Owners { get; set; }
    }
}
