using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.BackCalculations.ListHeroes
{
    public class Jnec:IHero
    {
        public List<IHero> HeroList;
        public string Name { get; set; } = "Жнец";
        public string Description { get; set; }
        public string TypeOfTroops { get; set; }
        public decimal Health { get; set; } = 100;
        public decimal Atack { get; set; } = 100;
        public int Row { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        List<IHero> IHero.HeroList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Skills(){}
    }
}
