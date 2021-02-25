using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTraderAssets
{
    public class Player
    {
        public int playerLives, gold, platinum, emerald, etherium, madtweed, earthPennies;
        public bool atTradeFederation;

        public Player()
        {
            playerLives = 1;
            atTradeFederation = false;
        }
    }
}