using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager
{
    public class Flight
    {
        //добавяме свойства на класа Flights
        private decimal price;
        public string FlightID { get; set; }

        public string Destination { get; set; }

        public DateTime DeparatureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        


        public int SeatsAvailable
        {
            get; set;
        }

        public decimal Price//проверяваме дали цената е по-малка от 0, ако е хвърляме exception (в setter-а)
        {
            get
            {
                return price;
            }
            set
            {
                if (value <= 0) throw new ArgumentException("There is no such price. The number needs to be positive");//изписва текста и показва, че има грешка
                price = value;
            }
            
        }
        public Flight() { }//празен конструктор, като default (само null-ове или 0)
        public Flight(string destination, DateTime departure, DateTime arrival, decimal price)//конструктор
        {
            //задаваме стойности на свойствата
            FlightID = Guid.NewGuid().ToString();//да съсдава уникално Id за всеки полет
            Destination = destination;
            DeparatureTime = departure;
            ArrivalTime = arrival;
            Price = price;

        }
    }

}
