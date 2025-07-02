using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager
{
    public class FilePath
    {
        public const string FlightsFilePath = "flights.txt";
        //different method for FilePath, changed the properties on flights.txt
        //(Build Action->Content , Copy to Output Directory->Copy if newer)
    }
}
