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
            Console.WriteLine("=============================");
            Console.WriteLine("       + ADD FLIGHT +        ");//Показва функцията, която е избрал потребителят
            Console.WriteLine("=============================");

            string destination;
            while (true)//повтарят се същите действия докато не е въведено правилно 
            {
                Console.Write("Enter destination: ");
                destination = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(destination)) break;//Ако destination не е празен продължава надолу с departure и записва информацията в destination
                Console.WriteLine("DESTINATION IS EMPTY.Please enter one.");//Ако е празно принтира това съобщение
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
                Console.WriteLine("INVALID DATE/TIME FORMAT. Use yyyy-MM-dd HH:mm.");
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
                    else Console.WriteLine("INVALID ARRIVAL TIME. Arrival time must be after departure time.");
                }
                else
                {
                    Console.WriteLine("INVALID DATE/TIME FORMAT. Use yyyy-MM-dd HH:mm.");
                }
            }

            decimal price;
            while (true)//повтарят се същите действия докато не е въведено правилно 
            {
                Console.Write("Enter price: ");
                if (decimal.TryParse(Console.ReadLine(), out price) && price >= 0) break;//запазва цената в price, ако е по-голяма от нула и е превърната от string в decimal
                Console.WriteLine("INVALID PRICE. Please enter a positive number.");
            }

            int seats;
            while (true)//повтарят се същите действия докато не е въведено правилно 
            {
                Console.Write("Enter available seats: ");
                if (int.TryParse(Console.ReadLine(), out seats) && seats > 0) break;//запазва свободните места в seats,ако може да се превърне числото написано в int и са над 0
                Console.WriteLine("INVALID SEAT COUNT.Please enter a positive whole number.");
            }

            Flight newFlight = new Flight(destination, departure, arrival, price) { SeatsAvailable = seats };//създава нов полет с подадените данни и задава колко свободни места има в seats available

            data.Flights.Add(newFlight);//добавя новия полет в flights
            data.Save();//добавя в дата класа, който запазва информацията в текстовия файл
            Console.WriteLine("Flight added successfully.");//информира че е запазен полетът  
        } 
        public void SellTickets()
        {
            ShowAllFlights();//показва всички полети с помощта на 4тия метод
            Console.Write("Enter flight ID to book tickets for: ");
            string id = Console.ReadLine();

            Flight flight = data.Flights.FirstOrDefault(f => f.FlightID == id);//търси първия полет с id като въведеното, ако не намери връща null
            if (flight == null)//ако няма такъв полет принтира съобщението
            {
                Console.WriteLine("FLIGHT NOT FOUND.Try again or search up another flight!");
                return;
            }

            Console.Write("Enter number of tickets to purchase: ");
            int tickets = int.Parse(Console.ReadLine());

            if (tickets > flight.SeatsAvailable)//проверява дали има достатъчно свободни места на дадения полет
            {
                Console.WriteLine("NOT ENOUGHT SEATS AVAILABLE.");
                return;
            }

            decimal total = tickets * flight.Price;//изчислява общата сума за закупените билети
            flight.SeatsAvailable -= tickets;//премахва закупените билети от останалите билети
            data.Save();//запазва информацията в класа дата

            Console.WriteLine($"Successfully booked {tickets} tickets. Total price: {total}");

        }

        

        public void CheckAvailability()
        {
            Console.Write("Enter flight ID or destination: ");
            string input = Console.ReadLine();

            List<Flight> matchingFlights = data.Flights
                .Where(f => f.FlightID == input || f.Destination.Equals(input, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (matchingFlights.Count == 0)
            {
                Console.WriteLine("No flights found.");
                return;
            }

            foreach (var flight in matchingFlights)
            {
                Console.WriteLine($"Flight to {flight.Destination} ({flight.FlightID}) - Seats: {flight.SeatsAvailable}, Price: {flight.Price:C}");
            }
        }

        public void ShowAllFlights()
        {
            if (data.Flights.Count == 0)
            {
                Console.WriteLine("No flights available.");
                return;
            }

            foreach (var flight in data.Flights)
            {
                Console.WriteLine($"ID: {flight.FlightID}, To: {flight.Destination}, Departure: {flight.DeparatureTime}, Arrival: {flight.ArrivalTime}, Price: {flight.Price:C}, Seats: {flight.SeatsAvailable}");
            }
        }
        



    }
}
