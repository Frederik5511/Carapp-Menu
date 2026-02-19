namespace Carapp_Menu
{
    internal class Program
    {
        static string brand = "";
        static string model = "";
        static int year = 0;
        static int mileage = 0;


        static void Main(string[] args)
        {

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("MENU");
                Console.WriteLine("1");
                Console.WriteLine("2");
                Console.WriteLine("3");
                Console.WriteLine("4");
                Console.WriteLine("5");
                Console.WriteLine("6");
                Console.WriteLine("7");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ReadCarDetails();
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
            while (!int.TryParse(Console.ReadLine(),out mileage))
            {
                Console.WriteLine("Ugyldigt svar. Prøv igen");
            }

        }
    static void Drive(double distance)
        {

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
