using Bumptech.Glide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Data
{
    public class ReservationManager
    {
        private List<Reservation> reservations;
        private string flightFilePath;
        private string reservationFilePath;

        public ReservationManager(string reservationDataFilePath, string flightDataFilePath)
        {
            reservationFilePath = reservationDataFilePath;
            flightFilePath = flightDataFilePath;
            LoadReservations();
        }
        public List<Reservation> FindReservations(string reservationCode, string airline, string travelerName)
        {
            var query = reservations.AsQueryable();

            if (!string.IsNullOrEmpty(reservationCode))
            {
                query = query.Where(r => r.ReservationCode.Equals(reservationCode, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(airline))
            {
                query = query.Where(r => r.Airline.Equals(airline, StringComparison.OrdinalIgnoreCase));
            }
            if (string.IsNullOrEmpty(travelerName))
            {
                query = query.Where(r => r.Name.Contains(travelerName, StringComparison.OrdinalIgnoreCase));
            }

            return query.ToList();
        }
        public Reservation MakeReservation(Flight flight, string travelerName, string citizenship)
        {
            if (flight == null)
            {
                throw new ArgumentException("Invalid flight.");
            }
            if (string.IsNullOrEmpty(travelerName))
            {
                throw new ArgumentException("Traveler name cannot be empty");
            }
            if (string.IsNullOrEmpty(citizenship))
            {
                throw new ArgumentException("Citizenship cannot be empty");
            }
            if (flight.IsFullyBooked())
            {
                throw new ArgumentException("Flight is fully booked.");
            }

            string reservationCode = GenerateReservationCode();
            Reservation reservation = new Reservation
            {
                ReservationCode = reservationCode,
                FlightCode = flight.FlightCode,
                Airline = flight.AirlineName,
                Cost = flight.Price,
                Citizenship = citizenship,
                IsActive = true
            };
            reservations.Add(reservation);
            flight.BookSeat();
            PersistReservations();
            return reservation;
        }
        public void UpdateReservation(Reservation reservation, string newName, string newCitizenship, bool newStatus)
        {
            if (reservation == null)
            {
                throw new ArgumentException("Invalid reservation");
            }
            if (string.IsNullOrEmpty(newName))
            {
                throw new ArgumentException("New name cannot be empty");
            }
            if (string.IsNullOrEmpty(newCitizenship))
            {
                throw new ArgumentException("New citizenship cannot be empty");
            }
            reservation.Name = newName;
            reservation.Citizenship = newCitizenship;
            reservation.IsActive = newStatus;

            PersistReservations();
        }
        private void LoadReservations()
        {
            reservations = new List<Reservation>();
            if (File.Exists(reservationFilePath))
            {
                try
                {
                    string[] reservationLines = File.ReadAllLines(reservationFilePath);

                    foreach (string line in reservationLines)
                    {
                        string[] reservationData = line.Split(',');
                        if (reservationData.Length == 7)
                        {
                            Reservation reservation = new Reservation
                            {
                                ReservationCode = reservationData[0],
                                FlightCode = reservationData[1],
                                Airline = reservationData[2],
                                Cost = decimal.Parse(reservationData[3]),
                                Name = reservationData[4],
                                Citizenship = reservationData[5],
                                IsActive = bool.Parse(reservationData[6])
                            };
                            reservations.Add(reservation);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading reservations: {ex.Message}");
                }
            }
        }
        private string GenerateReservationCode()
        {
            Random random = new Random();
            char letter = (char)random.Next('A', 'Z' + 1);
            int number = random.Next(10000);

            string reservationCode = $"{letter}{number:D4}";

            return reservationCode;
        }
        private void PersistReservations()
        {
            try
            {
                string[] reservationLines = reservations.Select(r => $"{r.ReservationCode},{r.FlightCode},{r.Airline},{r.Cost},{r.Name},{r.Citizenship},{r.IsActive}").ToArray();
                File.WriteAllLines(reservationFilePath, reservationLines);
            }
            catch ( Exception ex )
            {
                Console.WriteLine($"Error persisting reservations: {ex.Message}");
            }
        }
    }
}
