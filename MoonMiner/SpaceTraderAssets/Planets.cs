using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTraderAssets
{
    public class Planet
    {
        
        public int ResourceValue { get; set; }
        public Materials material;
        
    }

    public class Runerth : Planet
    {
        public Runerth()
        {
            material = Materials.Gold;
            ResourceValue = 5;
            
        }
    }
    public class Horuta : Planet
    {
        public Horuta()
        {
            material = Materials.Platinum;
            ResourceValue = 4;
            
        }
    }
    public class Gederth : Planet
    {
        public Gederth()
        {
            material = Materials.Emerald;
            ResourceValue = 3;
            
        }
    }
    public class Yaclite : Planet
    {
        public Yaclite()
        {
            material = Materials.Etherium;
            ResourceValue = 2;
        }
    }
    public class Ketune : Planet
    {
        public Ketune()
        {
            material = Materials.Madtweed;
            ResourceValue = 1;
        }
    }

}
