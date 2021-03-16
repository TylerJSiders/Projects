using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace MPGTracker2.Models
{
    public class Fillup
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public DateTime DateFilled { get; set; } = new DateTime(System.DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public DateTime DateEmpty { get; set; } = new DateTime(System.DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public int GallonsFilled { get; set; }
        public int MilesDriven { get; set; }
    }
}
