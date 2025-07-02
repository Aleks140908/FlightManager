using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager
{
    public class Flight
    {
        
        private decimal price;
        public string FlightID { get; set; }

        public string Destination { get; set; }

        public DateTime DeparatureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        
        
        public int SeatsAvailable
        {
            get; set;
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value <= 0) throw new ArgumentException("There is no such price. The number needs to be positive");//изписва текста и показва цхе има грешка
                price = value;
            }

        }
       



        public Flight() { }
        public Flight(string destination, DateTime departure, DateTime arrival, decimal price)//конструктор
        {
            FlightID = Guid.NewGuid().ToString();//да съсдава уникално Id за всеки полет
            Destination = destination;
            DeparatureTime = departure;
            ArrivalTime = arrival;
            Price = price;

        }




    }

}
