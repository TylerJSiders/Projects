using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPGTracker2.Models
{
    public class AddFIllupVM : Fillup
    {
        public string OwnerName { get; set; }
        public DateTime VehicleYear { get; set; }
        public Make VehicleMake { get; set; } 
        public string VehicleModel { get; set; }
    }
}
