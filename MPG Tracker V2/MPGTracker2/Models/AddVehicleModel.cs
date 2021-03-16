using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPGTracker2.Models
{
    public class AddVehicleModel : Vehicle
    {
        public SelectList OwnerIDs { get; set; }
        public SelectList OwnerNames { get; set; }
        public string OwnerName { get; set; }
    }
}
