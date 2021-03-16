using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MPGTracker2.Models
{
    public enum Make { Toyota, Honda, Tesla, Ford, Yamaha, Kawasaki }
    public class Vehicle
    {
        public int ID { get; set; }
        public Make Make { get; set; }
        [DataType(DataType.Date)]
        public DateTime Year { get; set; } = new DateTime(System.DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public string Model { get; set; }


        public ICollection<Fillup> Fillups { get; set; }
        public int OwnerID { get; set; }
    }
}
