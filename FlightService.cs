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
        
       
        
        public void AddFlight()

        {
            
        }
        public void SellTickets()
        {
        
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
