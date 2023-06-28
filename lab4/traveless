using System;

namespace Traveless;

public class Flight
{
    public string FlightCode { get; set; }
    public string AirlineName { get; set; }
    public string LeavingAirport { get; set; }
    public string DestinationAirport { get; set; }
    public string Day { get; set; }
    public string Time { get; set; }
    public int PassengerAmount { get; set; }
    public int Price { get; set; }

    public Flight()
    {
    }

    public Flight(string flightCode, string airlineName, string leavingAirport, string destinationAirport,
        string day, string time, int passengerAmount, int price)
    {
        FlightCode = flightCode;
        AirlineName = airlineName;
        LeavingAirport = leavingAirport;
        DestinationAirport = destinationAirport;
        Day = day;
        Time = time;
        PassengerAmount = passengerAmount;
        Price = price;
    }

    public static Flight FromString(string flightData)
    {
        string[] attributes = flightData.Split(',');

        string airlineCode = attributes[0];
        string airlineName = attributes[1];
        string leavingAirport = attributes[2];
        string destinationAirport = attributes[3];
        string day = attributes[4];
        string time = attributes[5];
        int passengerAmount = int.Parse(attributes[6]);
        int price = int.Parse(attributes[7]);

        return new Flight(airlineCode, airlineName, leavingAirport, destinationAirport, day, time,
            passengerAmount, price);
    }
    public static Flight[] ReadFlightsFromFile(string filePath)
    {
        string filePath = "flights.csv";
        string[] lines = File.ReadAllLines(filePath);
        Flight[] flights = new Flight[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            flights[i] = Flight.FromString(lines[i]);
        }

        return flights;
    }
}
