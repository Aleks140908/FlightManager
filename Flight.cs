using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager
{
    public class Flight
    {
        public int fightID {  get; set; }

        public string destination { get; set; }

        public DateTime deparatureTime { get; set; }
        public DateTime arrivalTime { get; set; }
        public int seatsAvailable { get; set; }
        public decimal price { get; set; }
    }
}
