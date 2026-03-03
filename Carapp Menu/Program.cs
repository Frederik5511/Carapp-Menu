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
                        Console.WriteLine("Hvor langt vil du kører?");
                        double distance;
                        while(!double.TryParse(Console.ReadLine(), out distance))
                        {
                            Console.WriteLine("Ugyldigt tal. Prøv igen");
                        }

                        myCar.Drive(distance);
                        break;
                    case "5":
                        Console.WriteLine("Hvor langt er turen (km)?");
                        double TripDistance;
                        while (!double.TryParse(Console.ReadLine(),out TripDistance))
                        {
                            Console.WriteLine("Ugyldigt tal. Prøv igen");
                        }
                        Console.WriteLine("Hvad koster 1 liter?");
                        double LiterPrice;
                        while (!double.TryParse(Console.ReadLine(), out  LiterPrice))
                        {
                            Console.WriteLine("Ugyldigt tal. Prøv igen");
                        }
                        Console.WriteLine("Brændstoftype benzin/diesel?");
                        string FuelType = Console.ReadLine();

                        double Price = myCar.CalculateTripPrice(TripDistance, LiterPrice);
                        Console.WriteLine($"Pris for turen: {Price}");
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
