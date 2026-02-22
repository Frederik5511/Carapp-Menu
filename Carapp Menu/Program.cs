namespace Carapp_Menu
{
    internal class Program
    {
        static string brand = "";
        static string model = "";
        static int year = 0;
        static int mileage = 0;
        static bool IsEngineOn = false;
        static double kmPerLiter = 0;


        static void Main(string[] args)
        {

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
                        ReadCarDetails();
                        break;
                    case "2":
                        StartEngine();
                        break;
                    case "3":
                        StopEngine();
                        break;
                    case "4":
                        Console.WriteLine("Hvor langt vil du kører?");
                        double distance;
                        while(!double.TryParse(Console.ReadLine(), out distance))
                        {
                            Console.WriteLine("Ugyldigt tal. Prøv igen");
                        }

                        Drive(distance);
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

                        double Price = CalculateTripPrice(TripDistance, LiterPrice, FuelType);
                        Console.WriteLine($"Pris for turen: {Price}");
                        break;
                    case "6":
                        if (IsPalindrome(mileage))
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
    static void ReadCarDetails()
        {
            Console.WriteLine("Hvilket bilmærke er din bil?");
            brand = Console.ReadLine();
            Console.WriteLine("Hvilken model er din bil?");
            model = Console.ReadLine();
            Console.WriteLine("Hvilken Årgang er din bil fra?");

            // while betyder: kør så længe betingelsen er sand
            // int.TryParse prøver at lave brugerens tekst om til et helt tal (int)
            // out year betyder: hvis det lykkes, gem tallet i variablen year
            // ! betyder "ikke"
            // Så loopet kører så længe input IKKE kan konverteres til et tal
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                // Hvis brugeren skriver noget der ikke er et tal,
                // kommer vi herind og beder dem prøve igen
                Console.WriteLine("Ugyldigt svar. Prøv igen");
            }

            Console.WriteLine("Hvad er din kilometerstand?");
            // Samme som tidligere bare med mileage i stedet for year
            while (!int.TryParse(Console.ReadLine(),out mileage))
            {
                Console.WriteLine("Ugyldigt svar. Prøv igen");
            }
            Console.WriteLine("Hvor langt kører din bil per liter?");
            while (!double.TryParse(Console.ReadLine(), out kmPerLiter))
            {
                Console.WriteLine("Ugyldigt svar. Prøv igen");
            }



        }
        
    static void StartEngine()
        {
            IsEngineOn = true;
            Console.WriteLine("Motoren er nu tændt");
        }

    static void StopEngine()
        {
            IsEngineOn = false;
            Console.WriteLine("Motoren er nu slukket");
        }

    static void Drive(double distance)
        {
            if (IsEngineOn)
            {
                mileage += (int)Math.Round(distance);
                Console.WriteLine($"Ny kilometerstand: {mileage}");
            }
            else
            {
                Console.WriteLine("Tænd motoren");
            }
        }
    
    static double CalculateTripPrice(double distance, double LiterPrice, string FuelType)
        {
            // Undgå division med 0
            if (kmPerLiter == 0)
            {
                Console.WriteLine("Fejl: kmPerLiter er 0. Indtastbilinfo først(punkt 1)");
                return 0;
            }
            // Tjek brændstoftype
            FuelType = (FuelType ?? "").Trim().ToLower();
            if (FuelType != "benzin" && FuelType !="diesel")
            {
                Console.WriteLine("Fejl: Brændstoftype skal være 'benzin' eller 'diesel'");
                return 0;
            }
            // Beregn forbrug og pris
            double LitersUsed = distance / kmPerLiter;
            double TotalPrice = LitersUsed * LiterPrice;
            return TotalPrice;
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
    static void PrintCarDetails()
        {

        }


        
    }
}
