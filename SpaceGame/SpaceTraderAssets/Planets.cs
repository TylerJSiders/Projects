using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTraderAssets
{
    public class Planet
    {
        //resources       
        //enemy appear - call to enemy class?
        //mining

        public void RiskLevel()
        {
                //Determine risk level
        }

    }

    public class Runerth : Planet
    {
        Materials resource = Materials.Gold;

    }
    public class Horuta : Planet
    {
        Materials resource = Materials.Silver;
    }
    public class Gederth : Planet
    {
        Materials resource = Materials.Emerald;
    }
    public class Yaclite : Planet
    {
        Materials resource = Materials.Madtweed;
    }
    public class Ketune : Planet
    {
        Materials resource = Materials.Etherium;
    }

}
