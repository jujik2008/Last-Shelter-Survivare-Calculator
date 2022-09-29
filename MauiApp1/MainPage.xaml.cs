using MauiApp1.BackCalculations;
using System.ComponentModel.DataAnnotations.Schema;
using MauiApp1.BackCalculations.ListHeroes;

using Button = Microsoft.Maui.Controls.Button;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MauiApp1;

public class StartPage : ContentPage
{
    public List<string> listOfHeroes = new List<string> { "Небесное", "Валькирия", "Целитель", };
    public List<string> listOfTroops = new List<string> { "Vehicles", "Figters", "Shoters" };

    //ints выбранных troops
    public int _troopsChange;
    public int _troopsChange1;
    public int _troopsChange2;
    public int _troopsChange3;
    public int _troopsChange4;
    public int _troopsChange5;

    public Calculation CalculationAtacker = new Calculation();
    public Calculation CalculationDefender = new Calculation();
    public Calculation CalculationStatus = new Calculation();

    public static Troops calculationAtacker0Row = new();
    public static Troops calculationAtacker1Row = new();
    public static Troops calculationAtacker2Row = new();
    public static Troops calculationDefender0Row = new();
    public static Troops calculationDefender1Row = new();
    public static Troops calculationDefender2Row = new();

    public static List<Troops> ListOfTroops = new List<Troops>() { calculationAtacker0Row, calculationAtacker1Row, calculationAtacker2Row, calculationDefender0Row, calculationDefender1Row, calculationDefender2Row };
    public StartPage()
    {
        AddingNewHeroesToList();
        Markup();
    }
    public void AddingNewHeroesToList()
    {
        //Adding a new heroes to main list 
        //добавление новых героев в главный список приложения
        Jnec jnec = new Jnec();
        listOfHeroes.Add(jnec.Name);
        Valkirija valkirija = new Valkirija();
        listOfHeroes.Add(valkirija.Name);
    }
    public void Markup()        //Разметка страниц
    {
        Picker heroChange = new Picker { Title = "Герой 1" };
        Picker heroChange1 = new Picker { Title = "Герой 2" };
        Picker heroChange2 = new Picker { Title = "Герой 3" };
        Picker heroChange3 = new Picker { Title = "Герой 1" };
        Picker heroChange4 = new Picker { Title = "Герой 2" };
        Picker heroChange5 = new Picker { Title = "Герой 3" };

        Picker troopsChange = new Picker { Title = "troops row 1" };
        Picker troopsChange1 = new Picker { Title = "troops row 2" };
        Picker troopsChange2 = new Picker { Title = "troops row 3" };
        Picker troopsChange3 = new Picker { Title = "troops row 1" };
        Picker troopsChange4 = new Picker { Title = "troops row 2" };
        Picker troopsChange5 = new Picker { Title = "troops row 3" };

        Button button = new Button
        {
            Text = "Нажми",
            FontSize = 22,
            BorderWidth = 1,
            BackgroundColor = Colors.LightPink,
            TextColor = Colors.DarkRed,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        button.Clicked += OnButtonClicked;

        Grid grid = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition(),
            },
            ColumnDefinitions =
            {
                new ColumnDefinition(),
                new ColumnDefinition(),
            }
        };

        MarkupGrid();
        HeroTroopsChangingFromList();

        void MarkupGrid()
        {
            grid.Add(heroChange, 0, 0);
            grid.Add(troopsChange, 0, 1);
            grid.Add(heroChange1, 0, 2);
            grid.Add(troopsChange1, 0, 3);
            grid.Add(heroChange2, 0, 4);
            grid.Add(troopsChange2, 0, 5);
            grid.Add(heroChange3, 1, 0);
            grid.Add(troopsChange3, 1, 1);
            grid.Add(heroChange4, 1, 2);
            grid.Add(troopsChange4, 1, 3);
            grid.Add(heroChange5, 1, 4);
            grid.Add(troopsChange5, 1, 5);
            grid.Add(button, 1, 6);
        }
        void HeroTroopsChangingFromList()
        {
            heroChange.ItemsSource = listOfHeroes;
            heroChange1.ItemsSource = listOfHeroes;
            heroChange2.ItemsSource = listOfHeroes;
            heroChange3.ItemsSource = listOfHeroes;
            heroChange4.ItemsSource = listOfHeroes;
            heroChange5.ItemsSource = listOfHeroes;
            // 
            troopsChange.ItemsSource = listOfTroops;
            troopsChange1.ItemsSource = listOfTroops;
            troopsChange2.ItemsSource = listOfTroops;
            troopsChange3.ItemsSource = listOfTroops;
            troopsChange4.ItemsSource = listOfTroops;
            troopsChange5.ItemsSource = listOfTroops;

            //troopsChange.SelectedIndexChanged += PickerSelectedIndexChanged;
        }
        void OnButtonClicked(object sender, System.EventArgs e)
        {
            _troopsChange = troopsChange.SelectedIndex;
            _troopsChange1 = troopsChange1.SelectedIndex;
            _troopsChange2 = troopsChange2.SelectedIndex;
            _troopsChange3 = troopsChange3.SelectedIndex;
            _troopsChange4 = troopsChange4.SelectedIndex;
            _troopsChange5 = troopsChange5.SelectedIndex;

            Button button = (Button)sender;
            Calc();
            button.Text = CalculationStatus.StatusOfBattle(CalculationAtacker, CalculationDefender);


        }
        Content = grid;
    }
    public void Calc()
    {
        GetTroopsChanged();
        Health();
        SumAtack();
        Rounding();
        AtackByRound();
        CalcHealthTotaL();

        void GetTroopsChanged()
        {
            calculationAtacker0Row = MainCalculation(_troopsChange, 1, true);
            calculationAtacker1Row = MainCalculation(_troopsChange1, 2, true);
            calculationAtacker2Row = MainCalculation(_troopsChange2, 3, true);
            calculationDefender0Row = MainCalculation(_troopsChange3, 1, false);
            calculationDefender1Row = MainCalculation(_troopsChange4, 2, false);
            calculationDefender2Row = MainCalculation(_troopsChange5, 3, false);
        }
        void CalcHealthTotaL()
        {
            calculationAtacker0Row.CalcHealthTotal();
            calculationAtacker1Row.CalcHealthTotal();
            calculationAtacker2Row.CalcHealthTotal();
            calculationDefender0Row.CalcHealthTotal();
            calculationDefender1Row.CalcHealthTotal();
            calculationDefender2Row.CalcHealthTotal();

        }
        void Health()//Sumary Health
        {
            CalculationAtacker.Health =
                calculationAtacker0Row.Health * calculationAtacker0Row.CurentNumOfTroops +
                calculationAtacker1Row.Health * calculationAtacker1Row.CurentNumOfTroops +
                calculationAtacker2Row.Health * calculationAtacker2Row.CurentNumOfTroops;

            CalculationDefender.Health =
                calculationDefender0Row.Health * calculationDefender0Row.CurentNumOfTroops +
                calculationDefender1Row.Health * calculationDefender1Row.CurentNumOfTroops +
                calculationDefender2Row.Health * calculationDefender2Row.CurentNumOfTroops;
        }
        void SumAtack()//Sumary Atack
        {
            CalculationAtacker.Atack =
                calculationAtacker0Row.Atack * calculationAtacker0Row.CurentNumOfTroops +
                calculationAtacker1Row.Atack * calculationAtacker1Row.CurentNumOfTroops +
                calculationAtacker2Row.Atack * calculationAtacker2Row.CurentNumOfTroops;

            CalculationDefender.Atack =
                calculationDefender0Row.Atack * calculationDefender0Row.CurentNumOfTroops +
                calculationDefender1Row.Atack * calculationDefender1Row.CurentNumOfTroops +
                calculationDefender2Row.Atack * calculationDefender2Row.CurentNumOfTroops;
        }
    }
    public Troops MainCalculation(int troopsChanged, int row, bool statusBySideAtack)
    {
        switch (troopsChanged)
        {
            case -1:
                Troops troops = new Troops();
                return troops;

            case 0:
                Vehicles vehicles = new Vehicles() { Row = row, StatusBySideAtack = statusBySideAtack };
                return vehicles;

            case 2:
                Shoters shoters = new Shoters() { Row = row, StatusBySideAtack = statusBySideAtack };
                return shoters;

            case 1:
                Figters figters = new Figters() { Row = row, StatusBySideAtack = statusBySideAtack };
                return figters;

            default:
                throw new NotImplementedException();
        }
        Hero ChangedHero0 = new() { };
        // ChangedHero0 = ChangeHero((string)heroChange.SelectedItem, 1);
    }
    public Hero ChangeHero(string hero, int row)
    {
        Hero Hero1 = new Hero();
        switch (hero)
        {
            case "Жнец":
                Jnec jnec = new Jnec() { Row = row };
                return (Hero)jnec;

            default:
                return null;
                break;
        }
    }
    public static void Rounding() //  ListOfTroops.Sort();
    {
        List<Troops> listoftroops = Listoftroops();

        List<Troops> listoftroops1 = listoftroops.OrderByDescending(x => x.SpeedOfAtack).ToList();

        Troops Round0 = listoftroops1[0];
        Troops Round1 = listoftroops1[1];
        Troops Round2 = listoftroops1[2];
        Troops Round3 = listoftroops1[3];
        Troops Round4 = listoftroops1[4];
        Troops Round5 = listoftroops1[5];

        Atack(Round0, 0);
        Atack(Round1, 1);
        Atack(Round2, 2);
        Atack(Round3, 3);
        Atack(Round4, 4);
        Atack(Round5, 5);
        //Atack(Round0);
        void Atack(Troops troops, int round)
        {
            if (troops.StatusBySideAtack)
                switch (troops.Row)
                {
                    case 1:
                        calculationAtacker0Row = troops;
                        calculationAtacker0Row.Round = round;
                        break;
                    case 2:
                        calculationAtacker1Row = troops;
                        calculationAtacker1Row.Round = round;
                        break;
                    case 3:
                        calculationAtacker2Row = troops;
                        calculationAtacker2Row.Round = round;
                        break;
                }
            else
            {
                switch (troops.Row)
                {
                    case 1:
                        calculationDefender0Row = troops;
                        calculationDefender0Row.Round = round;
                        break;
                    case 2:
                        calculationDefender1Row = troops;
                        calculationDefender1Row.Round = round;
                        break;
                    case 3:
                        calculationDefender2Row = troops;
                        calculationDefender2Row.Round = round;
                        break;
                }
            }
        }

    }
    public void AtackByRound()
    {
        List<Troops> listoftroops = Listoftroops();
        Round0();

        void Round0()
        {
            for (int i = 0; i < 6; i++)
            {
                foreach (var item in listoftroops)
                {
                    if (item.Round == i)
                    {
                        if (item.StatusBySideAtack)
                        {
                            if (calculationDefender0Row.HealthTotal != 0)
                            {
                                int a = calculationDefender0Row.Health * calculationDefender0Row.CurentNumOfTroops;
                                int b = item.Atack * item.CurentNumOfTroops;
                                a -= b;
                                calculationDefender0Row.HealthTotal = a;
                            }
                            else if (calculationDefender1Row.HealthTotal != 0)
                            {
                                int a = calculationDefender1Row.Health * calculationDefender1Row.CurentNumOfTroops;
                                int b = item.Atack * item.CurentNumOfTroops;
                                a -= b;
                                calculationDefender1Row.HealthTotal = a;
                            }
                            else
                            {
                                int a = calculationDefender2Row.Health * calculationDefender2Row.CurentNumOfTroops;
                                int b = item.Atack * item.CurentNumOfTroops;
                                a -= b;
                                calculationDefender2Row.HealthTotal = a;
                            }
                        }
                        else
                        {
                            if (calculationAtacker0Row.HealthTotal != 0)
                            {
                                int a = calculationAtacker0Row.Health * calculationAtacker0Row.CurentNumOfTroops;
                                int b = item.Atack * item.CurentNumOfTroops;
                                a -= b;
                                calculationAtacker0Row.HealthTotal = a;
                            }
                            else if (calculationAtacker1Row.HealthTotal != 0)
                            {
                                int a = calculationAtacker1Row.Health * calculationAtacker1Row.CurentNumOfTroops;
                                int b = item.Atack * item.CurentNumOfTroops;
                                a -= b;
                                calculationAtacker1Row.HealthTotal = a;
                            }
                            else
                            {
                                int a = calculationAtacker2Row.Health * calculationAtacker2Row.CurentNumOfTroops;
                                int b = item.Atack * item.CurentNumOfTroops;
                                a -= b;
                                calculationAtacker2Row.HealthTotal = a;
                            }
                        }
                    }
                }
            }
        }
    }
    public static List<Troops> Listoftroops()
    {
        List<Troops> listoftroops = new List<Troops>();
        listoftroops.Add(calculationAtacker0Row);
        listoftroops.Add(calculationAtacker1Row);
        listoftroops.Add(calculationAtacker2Row);
        listoftroops.Add(calculationDefender0Row);
        listoftroops.Add(calculationDefender1Row);
        listoftroops.Add(calculationDefender2Row);
        return listoftroops;
    }
}