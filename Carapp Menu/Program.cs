namespace Carapp_Menu
{
    internal class Program
    {
        static string brand = "";
        static string model = "";
        static int year = 0;
        static int mileage = 0;
        static bool IsEngineOn = false;


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
                Console.WriteLine("5");
                Console.WriteLine("6");
                Console.WriteLine("7");

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
    
    static double CalculateTripPrice(double distance, double LiterPrice, double FuelType)
        {
            return 0;
        }
    static bool isPalindrome (double distance)
        {
            return false;
        }
    static void PrintCarDetails()
        {

        }


        
    }
}
