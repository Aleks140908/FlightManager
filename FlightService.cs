using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace FlightManager
{
    public class FlightService

    { 
        private readonly Data data;//само чете данните от класа дата

        public FlightService()
        {
            data = new Data();//създава конструктор, с който можем да ползваме данните от дата класа.
        }


        public void AddFlight()
        {
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=============================");
            Console.WriteLine("       + ADD FLIGHT +        ");//Показва функцията, която е избрал потребителят
            Console.WriteLine("=============================");
            Console.ResetColor();
            string destination;
            while (true)//повтарят се същите действия докато не е въведено правилно 
            {
                Console.Write("Enter destination: ");
                destination = Console.ReadLine();
                int number; //ако въведеното е число, то се записва тук, но не е нужно за никъде другаде (с out number)
                if (!string.IsNullOrWhiteSpace(destination) && !int.TryParse(destination, out number))//записва destination само ако не е празно и не е число
                {
                    break; //спира цикъла ако е вярно написано
                }
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Destination is empty, please enter the destination you'd like correctly.");//Ако е празно принтира това съобщение
                Console.ResetColor();
            }

            DateTime departure;
            while (true)//повтарят се същите действия докато не е въведено правилно 
            {
                Console.Write("Enter departure time (yyyy-MM-dd HH:mm): ");
                string depInput = Console.ReadLine();

                if (DateTime.TryParseExact(depInput, "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out departure))
                // DateTime.TryParseExact(arrInput, "yyyy-MM-dd HH:mm" -превръща string в dateTime, без да срива програма дори и да е с грешно въведен input
                //globalization.cultureInfo.InvariantCulture -винаги очаква това форматиране yyyy-mm-dd hh:mm без значение от език или регион
                //Globalization.DateTimeStyles.None -кара parsera да вземе input така както е въведен
                //out arrival- съхранява информацията в arrival, ако е въведена правилно
                {
                    break;//ако форматът е правилен излизаме от цикъла
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Use yyyy-MM-dd HH:mm.");
                Console.ResetColor();
            }

            DateTime arrival;
            while (true)//повтарят се същите действия докато не е въведено правилно 
            {
                Console.Write("Enter arrival time (yyyy-MM-dd HH:mm): ");
                string arrInput = Console.ReadLine();

                if (DateTime.TryParseExact(arrInput, "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out arrival))
                //същото като за departure, само че използва arrival (обяснено е горе всичко подробно)
                {
                    if (arrival > departure) break;//проверява дали излитането е преди кацането
                    else Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Arrival time must be after departure time."); Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Use yyyy-MM-dd HH:mm.");
                    Console.ResetColor();
                }
            }

            decimal price;
            while (true)//повтарят се същите действия докато не е въведено правилно 
            {
                Console.Write("Enter price: ");
                if (decimal.TryParse(Console.ReadLine(), out price) && price >= 0) break;//запазва цената в price, ако е по-голяма от нула и е превърната от string в decimal
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Please enter a positive number."); Console.ResetColor();
            }

            int seats;
            while (true)//повтарят се същите действия докато не е въведено правилно 
            {
                Console.Write("Enter available seats: ");
                if (int.TryParse(Console.ReadLine(), out seats) && seats > 0) break;//запазва свободните места в seats,ако може да се превърне числото написано в int и са над 0
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Please enter a positive whole number.");Console.ResetColor();
            }

            Flight newFlight = new Flight(destination, departure, arrival, price) { SeatsAvailable = seats };//създава нов полет с подадените данни и задава колко свободни места има в seats available

            data.Flights.Add(newFlight);//добавя новия полет в flights
            data.Save();//добавя в дата класа, който запазва информацията в текстовия файл
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Flight added successfully.");//информира че е запазен полетът  
            Console.ResetColor();
        }
        public void SellTickets()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=============================");
            Console.WriteLine("      $  TICKET SHOP  $      ");//Показва функцията, която е избрал потребителят
            Console.WriteLine("=============================");
            Console.ResetColor();
            ShowAllFlights();//показва всички полети с помощта на 4тия метод


            Flight flight = null;
            while (flight == null) // повтаря се докато flight-а е наличен (докато се въведе валидно id)
            {
                Console.Write("Enter flight ID to book tickets for: ");
                string id = Console.ReadLine();
                flight = data.Flights.FirstOrDefault(f => f.FlightID == id);//търси първия полет с id като въведеното, ако не намери връща null
                if (flight == null)//ако няма такъв полет принтира съобщението
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Try again or search another flight!");
                    Console.ResetColor();
                }
            }

            int tickets;//декларираме празна променлива
            while (true) // проверява дали правилно е въведен броят на билетите
            {
                Console.Write("Enter number of tickets to purchase: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out tickets) && tickets > 0)//проверява дали са над 0 и дали входът е число
                {
                    if (tickets > flight.SeatsAvailable)//проверява дали има достатъчно свободни места на дадения полет
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Not enough seats available.");
                        Console.ResetColor();
                        return;
                    }
                    break; //излиза от цикъла
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Please enter a positive number.");
                    Console.ResetColor();
                }
            }

            decimal total = tickets * flight.Price;//изчислява общата сума за закупените билети
            flight.SeatsAvailable -= tickets;//премахва закупените билети от останалите билети
            data.Save();//запазва информацията в класа дата
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Successfully booked {tickets} tickets. Overall price: {total}");
            Console.ResetColor();
        }



        public void CheckAvailability()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=============================");
            Console.WriteLine("  ?  AVAILABILITY CHECKER  ? ");//Показва функцията, която е избрал потребителят
            Console.WriteLine("=============================");
            Console.ResetColor();

            string input;
            while (true)
            {
                Console.Write("Enter flight ID or destination: ");
                input = Console.ReadLine();
                int number;//запазва ако е число в number
                if (!string.IsNullOrWhiteSpace(input) && !int.TryParse(input, out number))//проверява input дали не е празно или число
                {
                    break; //продължава извън цикъла
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a correct flight ID or destination.");
                Console.ResetColor();
            }
            List<Flight> matchingFlights = data.Flights.Where(f => f.FlightID == input || f.Destination.Equals(input, StringComparison.OrdinalIgnoreCase)).ToList();
            //достъпва списъка с полети от класа дата, проверява дали id или дестинацията ги има в списъка без значение как са написани (малки/главни букви и т.н.)

            if (matchingFlights.Count == 0)//ако няма полети принтира съобщението
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No flights found.");
                Console.ResetColor();
                return;
            }

            foreach (var flight in matchingFlights)
            {
                //изписва информацията за дадения полет
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Flight to {flight.Destination} ({flight.FlightID}) - Seats: {flight.SeatsAvailable}, Price: {flight.Price}");
                Console.ResetColor();
            }
        }
        public void ShowAllFlights()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=============================");
            Console.WriteLine("     <-  FLIGHTS LIST  ->    ");//Показва функцията, която е избрал потребителят
            Console.WriteLine("=============================");
            Console.ResetColor();

            if (data.Flights.Count == 0)//проверява дали има полети от класа дата (във файлът).
            {
                Console.WriteLine("No flights available.");
                return;
            }

            foreach (var flight in data.Flights)//принтира всички полети
            {
                Console.WriteLine($"ID: {flight.FlightID}, To: {flight.Destination}, Departure: {flight.DeparatureTime}, Arrival: {flight.ArrivalTime}, Price: {flight.Price:C}, Seats: {flight.SeatsAvailable}");
            }
        }
        public void CancelTickets()
        {

        }



    }
}
