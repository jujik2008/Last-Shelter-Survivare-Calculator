using MauiApp1.BackCalculations;
using MauiApp1.BackCalculations.ListHeroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.BackCalculations
{
    public interface IHero
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TypeOfTroops {get; set;} 
        public decimal Health { get; set; }
        public decimal Atack { get; set; }
        List<IHero> HeroList { get; set; }

        public enum TypeOfTroops1
        {
            Vehicle,
            Shoters,
            Fighters
        }
        public void Skills(){}
        public void AddNameToList(){}
        public int Row { get; set; }
        public string Status { get; set; }  //Atack Defence
    }
}
public class Hero : IHero
{
    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string TypeOfTroops { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public decimal Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public decimal Atack { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public List<IHero> HeroList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int Row { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public static explicit operator Hero(Jnec v)
    {
        throw new NotImplementedException();
    }
}
