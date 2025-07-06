namespace FlightManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FlightService flightService = new FlightService();//създава нов обект от FlightService, за да можем да извикаме методите му

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
                Console.WriteLine("  5. Cancelation of Tickets");
                Console.WriteLine("  6. Airline Statistics");
                Console.WriteLine("  0. Exit");
                Console.ResetColor();

                int choice;
                while (true)//проверка на изборът на потребителя
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Please choose a number: ");
                    Console.ResetColor();
                    string input = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out choice) && choice >= 0 && choice <= 6)//проверява дали не е празно и дали е число от менюто
                    {
                        break;//продължава със switch case-а, защото има валиден вход
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a number between 0 and 5.");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.ResetColor();

                Console.Clear();
                switch (choice)//според входа избира метод, който да изпълни в класа FlightService
                {
                    case 1:

                        flightService.AddFlight();
                        break;
                    case 2:

                        flightService.SellTickets();
                        break;
                    case 3:

                        flightService.CheckAvailability();
                        break;
                    case 4:

                        flightService.ShowAllFlights();
                        break;
                    case 5:
                        flightService.CancelTickets();
                        break;
                    case 6:
                        flightService.ShowAirlineStatistics();
                        break;
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Exiting...");
                        Console.ResetColor();
                        return;
                   // не е необходим default, защото проверяваме дали е окей входа още след менюто    
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to return to the main menu");
                Console.ReadKey();
                //след всеки метод се принтира това отгоре, за да ги върне в началото (менюто)
            }
        }
    }
}
