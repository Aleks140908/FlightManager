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
        //смених начина по който се достига до текстовият файл, като промених свойствата на flights.txt по-долу обяснени
        //(Build Action->Content ; Copy to Output Directory->Copy if newer)
    }
}
