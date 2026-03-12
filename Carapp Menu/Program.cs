using System;
using System.Collections.Generic;

namespace Carapp_Menu
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Car myCar = new Car();


            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("MENU");
                Console.WriteLine("1. Bil Info");
                Console.WriteLine("2. Start Motoren");
                Console.WriteLine("3. Sluk Motoren");
                Console.WriteLine("4. Kør en tur");
                Console.WriteLine("5. Beregn prisen for en tur");
                Console.WriteLine("6. Tjek palindrom (km-stand)");
                Console.WriteLine("7. Luk ned");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        myCar.ReadCarDetails();
                        break;
                    case "2":
                        myCar.StartEngine();
                        break;
                    case "3":
                        myCar.StopEngine();
                        break;
                    case "4":
                        Console.WriteLine("Hvor langt er turen (km)?");
                        double distance;
                        while(!double.TryParse(Console.ReadLine(), out distance))
                        {
                            Console.WriteLine("Ugyldigt tal. Prøv igen");
                        }
                        Console.WriteLine("Hvor mange minutter varer turen? (fx 30)");
                        int minutes;
                        while (!int.TryParse(Console.ReadLine(),out minutes)|| minutes <= 0)
                        {
                            Console.WriteLine("Ugyldigt tal. Prøv igen");
                        }
                        DateTime startTime = DateTime.Now;
                        DateTime endTime = startTime.AddMinutes(minutes);

                        Trip newTrip = new Trip(myCar, distance, startTime, endTime);
                        myCar.Drive(newTrip);

                        Console.WriteLine("Turen er tilføjet (hvis motor var tændt og turen tilhørte bilen)");
                        break;
                    case "5":
                        Console.WriteLine("Hvad koster 1 liter?");
                        double LiterPrice;
                        while (!double.TryParse(Console.ReadLine(), out  LiterPrice) || LiterPrice < 0)
                        {
                            Console.WriteLine("Ugyldigt tal. Prøv igen");
                        }
                        List<Trip> trips = myCar.GetTrips();
                        if (trips.Count == 0)
                        {
                            Console.WriteLine("Der er ingen ture endnu");
                        }
                        else
                        {
                            Console.WriteLine("=== Ture ===");
                            foreach (Trip trip in trips)
                            {
                                Console.WriteLine(trip.GetTripDetails(LiterPrice));
                                Console.WriteLine();
                            }
                        }
                        break;                  
                    case "6":
                        if (IsPalindrome(myCar.Mileage))
                        {
                            Console.WriteLine("Kilometerstanden er et palindrom");
                        }
                        else
                        {
                            Console.WriteLine("Kilometerstanden er ikke et palindrom");
                        }
                        break;
                    case "7":
                        isRunning = false;
                        Console.WriteLine("Lukker ned.");
                        break;
                    default:
                        Console.WriteLine("Ugyldigt input. Vælg mellem 1 og 7.");
                        break;
                }


            }
        }
        static bool IsPalindrome(int km)
        {
            // Lav tallet om til tekst
            string value = km.ToString();

            int left = 0;
            int right = value.Length - 1;

            // Sammenlign yderste tegn og arbejd indad
            while (left < right)
            {
                if (value[left] != value[right])
                {
                    return false; //Hvis noget ikke matcher, er det ikke et palindrom
                }
                left++; // Flytter én position ind fra venstre
                right--; // Flytter én position ind fra højre
            }
            // Hvis vi når hertil uden mismatch, er det et palindrom
            return true;
        }
    }
}
