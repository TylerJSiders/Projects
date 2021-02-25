using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpaceTraderAssets;

namespace MoonMiner
    {
    public partial class Form2 : Form
        {
        Player player = new Player();
        Runerth runerth = new Runerth();
        Horuta horuta = new Horuta();
        Gederth gederth = new Gederth();
        Yaclite yaclite = new Yaclite();
        Ketune ketune = new Ketune();
        Qal qal = new Qal();
        Ohex ohex = new Ohex();
        Vaakzail vaakzail = new Vaakzail();
        Drerkel drerkel = new Drerkel();
        Khingrox khingrox = new Khingrox();
        const int RiskThreshold = 20;
        int RiskLevel = 0;
        
        //Enemies enemies = new Enemies();
          
        public Form2( )
        {
            InitializeComponent();
            TradeButtons(player.atTradeFederation);
            UpdateText();
            IntroText.Visible = false;
            OutroText.Visible = false;
            GameOver.Visible = false;
            DrerkelPic.Visible = false;
            QalPic.Visible = false;
            OhexPic.Visible = false;
            VaakzailPic.Visible = false;
            KhingroxPic.Visible = false;
            YouWin.Visible = false;
        }

    

        public void UpdateText()
        {
            GoldValue.Text = player.gold.ToString();
            PlatinumValue.Text = player.platinum.ToString();
            EmeraldValue.Text = player.emerald.ToString();
            EtheriumValue.Text = player.etherium.ToString();
            MadtweedValue.Text = player.madtweed.ToString();
            SpaceFleetValue.Text = player.playerLives.ToString();
            EarthPenniesValue.Text = player.earthPennies.ToString();
        }

        private void _RunerthButton_Click(object sender, EventArgs e)
        {
            if (IntroText.Visible)
                IntroText.Visible = false;
            if (OutroText.Visible)
                OutroText.Visible = false;
            HideInteraction();

            bool EnemyIsSpawned = false;
            if (player.atTradeFederation)
            {
                player.atTradeFederation = false;
                TradeButtons(player.atTradeFederation);
            }
            EnemyIsSpawned = EnemySpawned(drerkel);
            if (EnemyIsSpawned)
            {
                EnemyLogic(drerkel);
                UpdateText();
            }
            else
            {
                player.gold += runerth.ResourceValue;
                UpdateText();
            }
            
        }
        private void _HorutaButton_Click(object sender, EventArgs e)
        {
            if (IntroText.Visible)
                IntroText.Visible = false;
            if (OutroText.Visible)
                OutroText.Visible = false;
            HideInteraction();
            if (player.atTradeFederation)
            {
                player.atTradeFederation = false;
                TradeButtons(player.atTradeFederation);
            }
            if(EnemySpawned(qal))
            {
                EnemyLogic(qal);
                UpdateText();
            }
            else
            {
                player.platinum += horuta.ResourceValue;
                UpdateText();
            }
        }

        private void _GederthButton_Click(object sender, EventArgs e)
        {
            if (IntroText.Visible)
                IntroText.Visible = false;
            if (OutroText.Visible)
                OutroText.Visible = false;
            HideInteraction();
            if (player.atTradeFederation)
            {
                player.atTradeFederation = false;
                TradeButtons(player.atTradeFederation);
            }
            if (EnemySpawned(khingrox))
            {
                EnemyLogic(khingrox);
                UpdateText();
            }
            else
            {
                player.emerald += gederth.ResourceValue;
                UpdateText();
            }
        }

        private void _YacliteButton_Click(object sender, EventArgs e)
        {
            if (IntroText.Visible)
                IntroText.Visible = false;
            if (OutroText.Visible)
                OutroText.Visible = false;
            HideInteraction();
            if (player.atTradeFederation)
            {
                player.atTradeFederation = false;
                TradeButtons(player.atTradeFederation);
            }
            if (EnemySpawned(ohex))
            {
                EnemyLogic(ohex);
                UpdateText();
            }
            else
            {
                player.etherium += yaclite.ResourceValue;
                UpdateText();
            }
        }

        private void _KetuneButton_Click(object sender, EventArgs e)
        {
            if (IntroText.Visible)
                IntroText.Visible = false;
            if (OutroText.Visible)
                OutroText.Visible = false;
            HideInteraction();
            if (player.atTradeFederation)
            {
                player.atTradeFederation = false;
                TradeButtons(player.atTradeFederation);
            }
            ;
            if (EnemySpawned(vaakzail))
            {
                EnemyLogic(vaakzail);
                UpdateText();
            }
            else
            {
                player.madtweed += ketune.ResourceValue;
                UpdateText();
            }
        }

        private void EnemyLogic(Enemies aEnemy)
        {
            switch (aEnemy.resourceToSteal)
            {
                case Materials.Gold:
                    if (player.gold > 0)
                    {
                        IntroText.Text = aEnemy.IntroQuoteIfEnough;
                        player.gold = 0;
                        UpdateText();
                        OutroText.Text = aEnemy.OutroQuote;
                        IntroText.Visible = true;
                        OutroText.Visible = true;
                        DrerkelPic.Visible = true;
                    }
                    else
                    {
                        IntroText.Text = aEnemy.IntroQuoteIfNotEnough;
                        if(player.playerLives > 0)
                        {
                            player.playerLives -= 1;
                            UpdateText();
                            OutroText.Text = aEnemy.OutroQuote;
                            IntroText.Visible = true;
                            OutroText.Visible = true;
                            DrerkelPic.Visible = true;
                            if (player.playerLives == 0)
                                GameOverLose();
                        }
                        else
                        {
                            GameOverLose();
                        }
                    }
                    break;
                case Materials.Platinum:
                    if (player.platinum > 0)
                    {
                        IntroText.Text = aEnemy.IntroQuoteIfEnough;
                        player.platinum = 0;
                        UpdateText();
                        OutroText.Text = aEnemy.OutroQuote;
                        IntroText.Visible = true;
                        OutroText.Visible = true;
                        QalPic.Visible = true;
                    }
                    else
                    {
                        IntroText.Text = aEnemy.IntroQuoteIfNotEnough;
                        if (player.playerLives > 0)
                        {
                            player.playerLives -= 1;
                            UpdateText();
                            OutroText.Text = aEnemy.OutroQuote;
                            IntroText.Visible = true;
                            OutroText.Visible = true;
                            QalPic.Visible = true;
                            if (player.playerLives == 0)
                                GameOverLose();
                        }
                        else
                        {
                            GameOverLose();
                        }
                    }
                    break;
                case Materials.Emerald:
                    if (player.emerald > 0)
                    {
                        IntroText.Text = aEnemy.IntroQuoteIfEnough;
                        player.emerald = 0;
                        UpdateText();
                        OutroText.Text = aEnemy.OutroQuote;
                        IntroText.Visible = true;
                        OutroText.Visible = true;
                        KhingroxPic.Visible = true;
                    }
                    else
                    {
                        IntroText.Text = aEnemy.IntroQuoteIfNotEnough;
                        if (player.playerLives > 0)
                        {
                            player.playerLives -= 1;
                            UpdateText();
                            OutroText.Text = aEnemy.OutroQuote;
                            IntroText.Visible = true;
                            OutroText.Visible = true;
                            KhingroxPic.Visible = true;
                            if (player.playerLives == 0)
                                GameOverLose();
                        }
                        else
                        {
                            GameOverLose();
                        }
                    }
                    break;
                case Materials.Etherium:
                    if (player.etherium > 0)
                    {
                        IntroText.Text = aEnemy.IntroQuoteIfEnough;
                        player.etherium = 0;
                        UpdateText();
                        OutroText.Text = aEnemy.OutroQuote;
                        IntroText.Visible = true;
                        OutroText.Visible = true;
                        OhexPic.Visible = true;
                    }
                    else
                    {
                        IntroText.Text = aEnemy.IntroQuoteIfNotEnough;
                        if (player.playerLives > 0)
                        {
                            player.playerLives -= 1;
                            UpdateText();
                            OutroText.Text = aEnemy.OutroQuote;
                            IntroText.Visible = true;
                            OutroText.Visible = true;
                            OhexPic.Visible = true;
                            if (player.playerLives == 0)
                                GameOverLose();
                        }
                        else
                        {
                            GameOverLose();
                        }
                    }
                    break;
                case Materials.Madtweed:
                    if (player.madtweed > 0)
                    {
                        IntroText.Text = aEnemy.IntroQuoteIfEnough;
                        player.madtweed = 0;
                        UpdateText();
                        OutroText.Text = aEnemy.OutroQuote;
                        IntroText.Visible = true;
                        OutroText.Visible = true;
                        VaakzailPic.Visible = true;
                    }
                    else
                    {
                        IntroText.Text = aEnemy.IntroQuoteIfNotEnough;
                        if (player.playerLives > 0)
                        {
                            player.playerLives -= 1;
                            UpdateText();
                            OutroText.Text = aEnemy.OutroQuote;
                            IntroText.Visible = true;
                            OutroText.Visible = true;
                            VaakzailPic.Visible = true;
                            if (player.playerLives == 0)
                                GameOverLose();
                        }
                        else
                        {
                            GameOverLose();
                        }
                    }
                    break;

            }

            
        }

        private void GoToTradeFederation_Click(object sender, EventArgs e)
        {
            RiskLevel = 0;
            if (!player.atTradeFederation)
            {
                player.atTradeFederation = true;
            }
            TradeButtons(player.atTradeFederation);
        }

        private void Sell1GoldOre_Click(object sender, EventArgs e)
        {
            Materials material = runerth.material;
            SellResourceIndiv(material);
        }
        private void Sell1PlatinumOre_Click(object sender, EventArgs e)
        {
            Materials material = horuta.material;
            SellResourceIndiv(material);
        }

        private void Sell1EmeraldGem_Click(object sender, EventArgs e)
        {
            Materials material = gederth.material;
            SellResourceIndiv(material);
        }

        private void Sell1Etherium_Click(object sender, EventArgs e)
        {
            Materials material = yaclite.material;
            SellResourceIndiv(material);
        }

        private void Sell1Madtweed_Click(object sender, EventArgs e)
        {
            Materials material = ketune.material;
            SellResourceIndiv(material);
        }

        private void SellResourceIndiv(Materials aMaterial)
        {
            
            switch (aMaterial)
            {
                case Materials.Gold:
                    if (player.gold > 0)
                    {
                        player.earthPennies += 50;
                        player.gold -= 1;
                        UpdateText();
                    }
                    break;
                case Materials.Platinum:
                    if (player.platinum > 0)
                    {
                        player.earthPennies += 65;
                        player.platinum -= 1;
                        UpdateText();
                    }
                    break;
                case Materials.Emerald:
                    if (player.emerald > 0)
                    {
                        player.earthPennies += 120;
                        player.emerald -= 1;
                        UpdateText();
                    }
                    break;
                case Materials.Etherium:
                    if (player.etherium > 0)
                    {
                        player.earthPennies += 500;
                        player.etherium -= 1;
                        UpdateText();
                    }
                    break;
                case Materials.Madtweed:
                    if (player.madtweed > 0)
                    {
                        player.earthPennies += 765;
                        player.madtweed -= 1;
                        UpdateText();
                    }
                    break;
             }
        }

        public void TradeButtons(bool player)
        {
            Sell1GoldOre.Visible = player;
            Sell1PlatinumOre.Visible = player;
            Sell1EmeraldGem.Visible = player;
            Sell1Etherium.Visible = player;
            Sell1Madtweed.Visible = player;
            SellAllGold.Visible = player;
            SellAllPlatinumOre.Visible = player;
            SellAllEmeraldGems.Visible = player;
            SellAllEtherium.Visible = player;
            SellAllMadtweed.Visible = player;
            label12.Visible = player;
            pictureBox1.Visible = player;
            label6.Visible = player;
            label5.Visible = player;
            label4.Visible = player;
            label3.Visible = player;
            LabelMadtweed.Visible = player;
            label13.Visible = player;
            label14.Visible = player;
            label15.Visible = player;
            label16.Visible = player;
            label17.Visible = player;
            label18.Visible = player;
            label19.Visible = player;
            label20.Visible = player;
            label21.Visible = player;
            label22.Visible = player;
            label7.Visible = player;
            label8.Visible = player;
            label9.Visible = player;
            label10.Visible = player;
            label11.Visible = player;
            label23.Visible = player;
            label24.Visible = player;
            label25.Visible = player;
            label26.Visible = player;
            label27.Visible = player;
            _BuyShipButton.Visible = player;
        }

        private void SellAllPlatinumOre_Click(object sender, EventArgs e)
        {
            Materials material = horuta.material;
            SellResourceAll(material);
        }

        private void SellAllEmeraldGems_Click(object sender, EventArgs e)
        {
            Materials material = gederth.material;
            SellResourceAll(material);
        }

        private void SellAllEtherium_Click(object sender, EventArgs e)
        {
            Materials material = yaclite.material;
            SellResourceAll(material);
        }

        private void SellAllMadtweed_Click(object sender, EventArgs e)
        {
            Materials material = ketune.material;
            SellResourceAll(material);
        }

        private void SellAllGold_Click(object sender, EventArgs e)
        {
            Materials material = runerth.material;
            SellResourceAll(material);
        }

        public void SellResourceAll(Materials aMaterial)
        {
            switch(aMaterial)
            {
                case Materials.Gold:
                    if (player.gold > 0)
                    {
                        player.earthPennies += 50 * player.gold;
                        player.gold = 0;
                        UpdateText();
                    }
                    break;
                case Materials.Platinum:
                    if (player.platinum > 0)
                    {
                        player.earthPennies += 65 * player.platinum;
                        player.platinum = 0;
                        UpdateText();
                    }
                    break;
                case Materials.Emerald:
                    if (player.emerald > 0)
                    {
                        player.earthPennies += 120 * player.emerald;
                        player.emerald = 0;
                        UpdateText();
                    }
                    break;
                case Materials.Etherium:
                    if (player.etherium > 0)
                    {
                        player.earthPennies += 500 * player.etherium;
                        player.etherium = 0;
                        UpdateText();
                    }
                    break;
                case Materials.Madtweed:
                    if (player.madtweed > 0)
                    {
                        player.earthPennies += 765 * player.madtweed;
                        player.madtweed = 0;
                        UpdateText();
                    }
                    break;

            }
        }

        private void _BuyShipButton_Click(object sender, EventArgs e)
        {
            if (player.earthPennies >= 3000)
            {
                player.playerLives += 1;
                player.earthPennies -= 3000;
                UpdateText();
            }
            if (player.playerLives > 10)
            {
                GameOverWin();
            }
        }

        private bool EnemySpawned(Enemies aEnemy)
        {
            Random rnd = new Random(System.DateTime.Now.Second);
            int RiskIncrease = 0;
            switch(aEnemy.enemyName)
            {
                case EnemyNames.Drerkel:
                    RiskIncrease = rnd.Next(1, 8);

                    break;
                case EnemyNames.Qal:
                    RiskIncrease = rnd.Next(6, 12);
                    break;
                case EnemyNames.Khingrox:
                    RiskIncrease = rnd.Next(7, 13);
                    break;
                case EnemyNames.Ohex:
                    RiskIncrease = rnd.Next(8, 21);
                    break;
                case EnemyNames.Vaakzail:
                    RiskIncrease = rnd.Next(10, 22);
                    break;
            }
            RiskLevel += RiskIncrease;
            if (RiskLevel > RiskThreshold)
            {
                RiskLevel = 0;
                return true;
            }
            else
                return false;
        }

        public void GameOverLose()
        {
            DrerkelPic.Visible = false;
            KhingroxPic.Visible = false;
            OhexPic.Visible = false;
            QalPic.Visible = false;
            VaakzailPic.Visible = false;
            IntroText.Visible = false;
            OutroText.Visible = false;
            IntroNaut.Visible            = false;
            label1.Visible               = false;
            EarthPenniesValue.Visible    = false;
            SpaceFleetLabel.Visible      = false;
            SpaceFleetValue.Visible      = false;
            GoldLabel.Visible            = false;
            GoldValue.Visible            = false;
            platinumLabel.Visible        = false;
            PlatinumValue.Visible        = false;
            EmeraldLabel.Visible         = false;
            EmeraldValue.Visible         = false;
            EtheriumValue.Visible        = false;
            EtheriumLabel.Visible        = false;
            MadtweedLabel.Visible        = false;
            MadtweedValue.Visible        = false;
            SpaceMarket.Visible          = false;
            MoonMinerTitle.Visible       = false;
            RunerthPic.Visible           = false;
            YaclitePic.Visible           = false;
            HorutaPic.Visible            = false;
            GederthPic.Visible           = false;
            KetunePic.Visible            = false;
            _HorutaButton.Visible        = false;
            _KetuneButton.Visible        = false;
            _RunerthButton.Visible       = false;
            _GederthButton.Visible       = false;
            _YacliteButton.Visible       = false;
            Sell1GoldOre.Visible         = false;
            Sell1PlatinumOre.Visible     = false;
            Sell1EmeraldGem.Visible      = false;
            Sell1Etherium.Visible        = false;
            Sell1Madtweed.Visible        = false;
            SellAllGold.Visible          = false;
            SellAllPlatinumOre.Visible   = false;
            SellAllEmeraldGems.Visible   = false;
            SellAllEtherium.Visible      = false;
            SellAllMadtweed.Visible      = false;
            label12.Visible              = false;
            pictureBox1.Visible          = false;
            label6.Visible               = false;
            label5.Visible               = false;
            label4.Visible               = false;
            label3.Visible               = false;
            LabelMadtweed.Visible        = false;
            label13.Visible              = false;
            label14.Visible              = false;
            label15.Visible              = false;
            label16.Visible              = false;
            label17.Visible              = false;
            label18.Visible              = false;
            label19.Visible              = false;
            label20.Visible              = false;
            label21.Visible              = false;
            label22.Visible              = false;
            label7.Visible               = false;
            label8.Visible               = false;
            label9.Visible               = false;
            label10.Visible              = false;
            label11.Visible              = false;
            label23.Visible              = false;
            label24.Visible              = false;
            label25.Visible              = false;
            label26.Visible              = false;
            label27.Visible              = false;
            _BuyShipButton.Visible       = false;
            GoToTradeFederation.Visible = false;
            GameOver.Visible = true;
        }
        public void GameOverWin()
        {
            DrerkelPic.Visible = false;
            KhingroxPic.Visible = false;
            OhexPic.Visible = false;
            QalPic.Visible = false;
            VaakzailPic.Visible = false;
            IntroText.Visible = false;
            OutroText.Visible = false;
            IntroNaut.Visible         = false;
            label1.Visible            = false;
            EarthPenniesValue.Visible = false;
            SpaceFleetLabel.Visible   = false;
            SpaceFleetValue.Visible   = false;
            GoldLabel.Visible         = false;
            GoldValue.Visible         = false;
            platinumLabel.Visible     = false;
            PlatinumValue.Visible     = false;
            EmeraldLabel.Visible      = false;
            EmeraldValue.Visible      = false;
            EtheriumValue.Visible     = false;
            EtheriumLabel.Visible     = false;
            MadtweedLabel.Visible     = false;
            MadtweedValue.Visible     = false;
            SpaceMarket.Visible       = false;
            MoonMinerTitle.Visible    = false;
            RunerthPic.Visible        = false;
            YaclitePic.Visible        = false;
            HorutaPic.Visible         = false;
            GederthPic.Visible        = false;
            KetunePic.Visible         = false;
            _HorutaButton.Visible     = false;
            _KetuneButton.Visible     = false;
            _RunerthButton.Visible = false;
            _GederthButton.Visible = false;
            _YacliteButton.Visible = false;
            Sell1GoldOre.Visible   = false;
            Sell1PlatinumOre.Visible = false;
            Sell1EmeraldGem.Visible = false;
            Sell1Etherium.Visible = false;
            Sell1Madtweed.Visible = false;
            SellAllGold.Visible = false;
            SellAllPlatinumOre.Visible = false;
            SellAllEmeraldGems.Visible = false;
            SellAllEtherium.Visible = false;
            SellAllMadtweed.Visible = false;
            label12.Visible = false;
            pictureBox1.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            label4.Visible = false;
            label3.Visible = false;
            LabelMadtweed.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            _BuyShipButton.Visible = false;
            GoToTradeFederation.Visible = false;
            YouWin.Visible = true;
        }

        public void HideInteraction()
        {
            DrerkelPic.Visible = false;
            QalPic.Visible = false;
            VaakzailPic.Visible = false;
            OhexPic.Visible = false;
            KhingroxPic.Visible = false;
        }
    }
}
