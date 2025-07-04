namespace FlightManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FlightService flightService = new FlightService();
          
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("===========================================");
                Console.WriteLine("          FLIGHT MANAGEMENT MENU         ");
                Console.WriteLine("===========================================");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("  1. Add a New Flight");
                Console.WriteLine("  2. Sell Tickets for a Flight");
                Console.WriteLine("  3. Check Availability for a Flight");
                Console.WriteLine("  4. Show Information for All Flights");
                Console.WriteLine("  0. Exit");
                Console.ResetColor();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Please choose a number: ");
                Console.ResetColor();
                string choice = Console.ReadLine();

                Console.Clear();
                switch (choice)
                {
                    case "1":
                        
                        flightService.AddFlight();
                        break;
                    case "2":
                       
                        flightService.SellTickets();
                        break;
                    case "3":
                      
                         flightService.CheckAvailability();
                        break;
                    case "4":
                       
                        flightService.ShowAllFlights();
                        break;
                    case "0":
                        Console.ForegroundColor= ConsoleColor.Gray;
                        Console.WriteLine("Exiting...");
                        Console.ResetColor();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" THERE ISN'T AN OPTION WITH THIS NUMBER. PLEASE ENTER A NUMBER BETWEEN 0 AND 4");
                        Console.ResetColor();
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to return to the main menu");
                Console.ReadKey();
            }
        }
    }
}
