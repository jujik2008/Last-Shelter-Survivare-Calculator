using MauiApp1.BackCalculations.ListHeroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.BackCalculations
{
    public class Calculation : Troops
    {
        //public List<Troops> RoundBySpeed(List<Troops> list)
        //{

        //    List < Troops > x= from p in list orderby p.SpeedOfAtack descending select p;


        //    return x;
        //}

        public string StatusOfBattle(Calculation atacker, Calculation defencer)
        {
            Calculation Atacker = new();
            Calculation Defencer = new();
            Atacker = atacker;
            Defencer = defencer;


       //     if ((Atacker.Health & Defencer.Health) != 0) { return "next Round"; }
            if (Atacker.Health >= Defencer.Health) { return "Atacker is Win"; }
            else { return "Defenser is Win"; }

           // throw new NotImplementedException();
        }
    }
}
