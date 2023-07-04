using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment2.Data
{
    abstract class Flights
    {
        public string flightCode { get; set; }
        public string airline { get; set; }
        public string leavingAirport { get; set; }
        public string destinationAirport { get; set; }
        public string dayOfweek { get; set; }
        public string time { get; set; }
        public string seatNumber { get; set; }
        public double price { get; set; }


        public Flights(string _flightCode, string _airline, string _leavingAirport, string _destinationAirport, string _dayOfWeek, string _time, string _seatNUmber, double _price)
        {
            this.flightCode = _flightCode;
            this.airline = _airline;
            this.leavingAirport = _leavingAirport;
            this.destinationAirport = _destinationAirport;
            this.dayOfweek = _dayOfWeek;
            this.time = _time;
            this.seatNumber = _seatNUmber;
            this.price = _price;
        }

        public override string ToString()
        {
            return ($"{flightCode},{airline},{leavingAirport},{destinationAirport},{dayOfweek},{time},{seatNumber},{price:C}");
        }
    }
   
    internal class Flights1 : Flights
    {
        public Flights1(string _flightNumber,
            string _airline,
            string _originAirport,
            string _destinationAirport,
            string _dayOfWeek,
            string _time,
            string _seatNUmber,
            double _price)
            : base(_flightNumber, _airline, _originAirport, _destinationAirport, _dayOfWeek, _time, _seatNUmber, _price)
        { }
    }
}