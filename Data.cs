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
        // списък с всички полети, които само чете от файла
        public List<Flight> Flights { get; private set; }

        private StreamReader reader;//четец за файла
        private StreamWriter writer;//пише в файла

        public Data()//конструктор, който зарежда автоматично полетите
        {
            LoadFlights();
        }

        public void Save()//запазва всички полети във файлл в JSON формат
        {
            using (StreamWriter writer = new StreamWriter(FilePath.FlightsFilePath))
            {
                string jsonData = JsonSerializer.Serialize(Flights);// правим списъка в JSON
                writer.Write(jsonData);//записваме JSON-а във файла
            }
        }

        public void LoadFlights()//зарежда/показва всички полети от файла
        {
            Flights = new List<Flight>();//създаваме празен списък

            if (!File.Exists(FilePath.FlightsFilePath))
                return;//проверка ако няма файла, излизаме

            using (StreamReader reader = new StreamReader(FilePath.FlightsFilePath))
            {
                string jsonData = reader.ReadToEnd();//четем какво има във файла
                if (!string.IsNullOrEmpty(jsonData))
                {
                    Flights = JsonSerializer.Deserialize<List<Flight>>(jsonData)!;
                   //правим JSON текста обратно в списък от Flights
                }
            }
        }
    }
}
