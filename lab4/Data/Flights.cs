using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Data
{
    public class Flights
    {
        public string FlightCode { get; set; }
        public string Airline { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public decimal Cost { get; set; }
        public int SeatsAvailable { get; set; }
    }
}
