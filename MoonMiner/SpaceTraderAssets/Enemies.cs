using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceTraderAssets;

namespace SpaceTraderAssets
{
    public enum EnemyNames
    {
        Drerkel,
        Qal,
        Vaakzail,
        Khingrox,
        Ohex
    }
    public class Enemies
    {
        public EnemyNames enemyName;
        public string IntroQuoteIfEnough;
        public string IntroQuoteIfNotEnough;
        public string OutroQuote;
        public Materials resourceToSteal;
    }
    public class Drerkel : Enemies
    { 
        public Drerkel()
        {
            enemyName = EnemyNames.Drerkel;
            resourceToSteal = Materials.Gold;
            IntroQuoteIfEnough = $"{enemyName}: Your comfort turns to discomfort when I take all of your {resourceToSteal}";
            IntroQuoteIfNotEnough = $"{enemyName}: You have no {resourceToSteal} to give me!  I'll take a ship instead!";
            OutroQuote = $"{enemyName}: Thanks for the {resourceToSteal} SpaceMonkey!";
        }
    }

    public class Qal : Enemies
    {
       public Qal()
        {
            enemyName = EnemyNames.Qal;
            resourceToSteal = Materials.Platinum;
            IntroQuoteIfEnough = $"{enemyName}: You sound like you're screaming in space!";
            IntroQuoteIfNotEnough = $"{enemyName}: You have no {resourceToSteal} to give me!  I'll take a ship instead!";
            OutroQuote = $"{enemyName}: Thanks for the {resourceToSteal} SpaceMonkey!";
        }
    }

    public class Vaakzail : Enemies
    {
        
        public Vaakzail()
        {
            enemyName = EnemyNames.Vaakzail;
            resourceToSteal = Materials.Madtweed;
            IntroQuoteIfEnough = $"{enemyName}: Is that {resourceToSteal} you have there? Oh boy, I'm going to have a good 'ol time!";
            IntroQuoteIfNotEnough = $"{enemyName}: You have no {resourceToSteal} to give me!  I'll take a ship instead!";
            OutroQuote = $"{enemyName}: hehehehe.. you fool! Now I can rule the galaxy!";
        }
    }

    public class Khingrox : Enemies
    {
        public Khingrox()
        {
            enemyName = EnemyNames.Khingrox;
            resourceToSteal = Materials.Emerald;
            IntroQuoteIfEnough = $"{enemyName}: I am going to float you like a brick if you don't give me ma {resourceToSteal}";
            IntroQuoteIfNotEnough = $"{enemyName}: You have no {resourceToSteal} to give me!  I'll take a ship instead!";
            OutroQuote = $"{enemyName}: I better not see you again in my planet you Bozo!";
        }
    }

    public class Ohex : Enemies
    {

        public Ohex()
        {
            enemyName = EnemyNames.Ohex;
            resourceToSteal = Materials.Etherium;
            IntroQuoteIfEnough = $"{enemyName}: Silly Trader, I AM OHEX! Give you me your {resourceToSteal} NOW!";
            IntroQuoteIfNotEnough = $"{enemyName}: You have no {resourceToSteal} to give me!  I'll take a ship instead!";
            OutroQuote = $"{enemyName}: pla..pla..pla..plaaaaa....{resourceToSteal.ToString().ToUpper()}!!!!";
        }
    }
}
