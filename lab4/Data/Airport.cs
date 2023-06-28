using System;

namespace Airport
{
    public class Airport
    {
        public string AirportCode { get; set; }
        public string AirportName { get; set; }

        public Airport()
        {

        }

        public Airport(string airportCode, string airportName)
        {
            AirportCode = airportCode;
            AirportName = airportName;
        }

        public static Airport FromString(string airportData)
        {
            string[] attributes = airportData.Split(',');

            string airportCode = attributes[0];
            string airportName = attributes[1];

            return new Airport(airportCode, airportName);
        }
        public static Airport[] ReadAirportFromFile(string filePath)
        {
            string filePath = "airports.csv";
            string[] lines = File.ReadAllLines(filePath);
            Airport[] airport = new Airport[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                airport[i] = Airport.FromString(lines[i]);
            }

            return airport;
        }

    }
}
