using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.BackCalculations
{
    public class Troops
    {
        public int SpeedOfAtack { get; set; }
        public int Atack { get; set; }
        public int Defense { get; set; }
        public int Health { get; set; }
        public int HealthTotal { get; set; }
        public int BattlePower { get; set; }
        public int Row { get; set; }
        public int CurentNumOfTroops { get; set; }
        public int Round { get; set; }
        public bool StatusBySideAtack { get; set; }    //true if is Atacker, false if is defencer
        public void CalcHealthTotal()
        {
            HealthTotal = Health * CurentNumOfTroops;
        }

    }
    public class Vehicles : Troops
    {
        public Vehicles()
        {
            SpeedOfAtack = 120;
            Atack = 87;
            Defense = 49;
            Health = 18;
            BattlePower = 7;
            Row = 0;
            CurentNumOfTroops = 117000;

        }
    }
    public class Shoters : Troops
    {
        public Shoters()
        {
            SpeedOfAtack = 100;
            Atack = 102;
            Defense = 30;
            Health = 17;
            BattlePower = 7;
            Row = 0;
            CurentNumOfTroops = 117000;
        }
    }
    public class Figters : Troops
    {
        public Figters()
        {
            SpeedOfAtack = 80;
            Atack = 70;
            Defense = 73;
            Health = 20;
            BattlePower = 7;
            Row = 1;
            CurentNumOfTroops = 117000;
        }
    }
}