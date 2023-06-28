using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Data
{
    public class Reservation
    {
        public string ReservationCode { get; set; }
        public string FlightCode { get; set; }
        public string Airline { get; set; }
        public decimal Cost { get; set; }
        public string Name { get; set; }
        public string Citizenship { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            string status = IsActive ? "Active" : "Inactive";
            return $"Reservation Code: {ReservationCode}\n" +
                   $"Flight Code: {FlightCode}\n" +
                   $"Airline: {Airline}\n" +
                   $"Cost: {Cost}\n" +
                   $"Name: {Name}\n" +
                   $"Citizenship: {Citizenship}\n" +
                   $"Status: {status}";
        }
    }
}