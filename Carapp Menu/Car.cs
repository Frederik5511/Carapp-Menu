using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Carapp_Menu
{
    internal class Car
    {
        private string _brand = "";
        private string _model = "";
        private int _year = 0;
        private char _gearType;
        private string _fueltype = "";
        private double _kmPerLiter = 0;
        private int _mileage = 0;
        private bool _IsEngineOn = false;

        public int Mileage
        {
            get {  return _mileage; }
        }
        public void ReadCarDetails()
        {
            Console.WriteLine("Hvilket bilmærke er din bil?");
            _brand = Console.ReadLine();
            Console.WriteLine("Hvilken model er din bil?");
            _model = Console.ReadLine();
            Console.WriteLine("Hvilken Årgang er din bil fra?");

            // while betyder: kør så længe betingelsen er sand
            // int.TryParse prøver at lave brugerens tekst om til et helt tal (int)
            // out year betyder: hvis det lykkes, gem tallet i variablen year
            // ! betyder "ikke"
            // Så loopet kører så længe input IKKE kan konverteres til et tal
            while (!int.TryParse(Console.ReadLine(), out _year))
            {
                // Hvis brugeren skriver noget der ikke er et tal,
                // kommer vi herind og beder dem prøve igen
                Console.WriteLine("Ugyldigt svar. Prøv igen");
            }
            Console.WriteLine("Vælg gear type (A = Automat, M = Manuel)");

            while (true)
            {
                string input = Console.ReadLine()?.Trim().ToUpper();
                if (!string.IsNullOrEmpty(input) && input.Length == 1) //Hvis input ikke er tomt OG består af præcis ét tegn
                {
                    char gear = input[0]; ;
                    if (gear == 'A' || gear == 'M')
                    {
                        _gearType = gear;
                        break;
                    }
                }
                Console.WriteLine("Ugyldigt valg. Skriv A eller M");
            }

            Console.WriteLine("Hvilken slags brændstof bruger din bil Benzin eller Diesel?");
            
            while (true)
            {
                string input = Console.ReadLine()?.Trim().ToLower();
                if (!string.IsNullOrEmpty(input))
                {
                    string fueltype = input;
                    if (fueltype == "benzin" || fueltype == "diesel")
                    {
                        _fueltype = fueltype;
                        break;
                    }
                }
                Console.WriteLine("Ugyldigt valg. Vælg Benzin eller Diesel");
            }

            Console.WriteLine("Hvad er din kilometerstand?");
            
            while (!int.TryParse(Console.ReadLine(), out _mileage))
            {
                Console.WriteLine("Ugyldigt svar. Prøv igen");
            }
            Console.WriteLine("Hvor langt kører din bil per liter?");
            while (!double.TryParse(Console.ReadLine(), out _kmPerLiter))
            {
                Console.WriteLine("Ugyldigt svar. Prøv igen");
            }



        }

        public void StartEngine()
        {
            _IsEngineOn = true;
            Console.WriteLine("Motoren er nu tændt");
        }

        public void StopEngine()
        {
            _IsEngineOn = false;
            Console.WriteLine("Motoren er nu slukket");
        }

        public void Drive(double distance)
        {
            if (_IsEngineOn)
            {
                _mileage += (int)Math.Round(distance);
                Console.WriteLine($"Ny kilometerstand: {_mileage}");
            }
            else
            {
                Console.WriteLine("Tænd motoren");
            }
        }

        public double CalculateTripPrice(double distance, double LiterPrice)
        {
            // Undgå division med 0
            if (_kmPerLiter == 0)
            {
                Console.WriteLine("Fejl: kmPerLiter er 0. Indtastbilinfo først(punkt 1)");
                return 0;
            }
            // Tjek brændstoftype
            string fuel = (_fueltype ?? "").Trim().ToLower();
            if (fuel != "benzin" && fuel != "diesel")
            {
                Console.WriteLine("Fejl: Brændstoftype skal være 'benzin' eller 'diesel'");
                return 0;
            }
            // Beregn forbrug og pris
            double LitersUsed = distance / _kmPerLiter;
            double TotalPrice = LitersUsed * LiterPrice;
            return TotalPrice;
        }
        public Car()
        {

        }
        
        
        public Car(string brand, string model, int year, char gearType, string fuelType, double kmPerLiter)
        {
            _brand = brand;
            _model = model;
            _year = year;
            _gearType = gearType;
            _fueltype = fuelType;
            _kmPerLiter = kmPerLiter;
        }
    }
}
