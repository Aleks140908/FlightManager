using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace FlightManager
{
    public class Data
    {
        public List<Flight> Flights { get; private set; }

        private StreamReader reader;
        private StreamWriter writer;

        public Data()
        {
            LoadFlights();
        }

        public void Save()
        {
            using (StreamWriter writer = new StreamWriter(FilePath.FlightsFilePath))
            {
                string jsonData = JsonSerializer.Serialize(Flights);
                writer.Write(jsonData);
            }
        }

        public void LoadFlights()
        {
            Flights = new List<Flight>();

            if (!File.Exists(FilePath.FlightsFilePath))
                return;

            using (StreamReader reader = new StreamReader(FilePath.FlightsFilePath))
            {
                string jsonData = reader.ReadToEnd();
                if (!string.IsNullOrEmpty(jsonData))
                {
                    Flights = JsonSerializer.Deserialize<List<Flight>>(jsonData)!;
                }
            }
        }
    }
}
