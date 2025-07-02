using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager
{
    public class Flight
    {
        private bool isSeatAvailable;
        private decimal price;
        public int fightID { get; set; }

        public string destination { get; set; }

        public DateTime deparatureTime { get; set; }
        public DateTime arrivalTime { get; set; }
        public string SeatTaken { get; set; }
        public int seatsAvailable
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
                if (value <= 0) throw new ArgumentException("There is no such price. The number needs to be positive");
                price = value;
            }

        }

        public bool IsSeatAvailable
        {
            get
            {
                return isSeatAvailable;
            }
            set
            {
                isSeatAvailable = value;
                if (isSeatAvailable)
                {
                    SeatTaken = string.Empty; //
                }
            }
        }
    }

}
