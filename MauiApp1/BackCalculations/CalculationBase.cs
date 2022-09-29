namespace MauiApp1.BackCalculations
{
    public class CalculationBase
    {
        public int SpeedOfAtack { get; set; }
        public int Atack { get; set; }
        public int Defense { get; set; }
        public int Health { get; set; }
        public int BattlePower { get; set; }
        public int Row { get; set; }
        public string StatusOfBattle(Calculation atacker, Calculation defencer)
        {
            Calculation Atacker = new Calculation();
            Calculation Defencer = new Calculation();
            Atacker = atacker;
            Defencer = defencer;

            if ((Atacker.Health & Defencer.Health) != 0) { return "next Round"; }
            else if (Atacker.Health >= Defencer.Health) { return "Atacker is Win"; }
            else { return "Defenser is Win"; }

            throw new NotImplementedException();
        }
    }
}