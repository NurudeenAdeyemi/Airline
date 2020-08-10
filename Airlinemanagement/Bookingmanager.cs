using System;
using System.Collections.Generic;
using System.Text;


namespace Airlinemanagement
{
    public class Bookingmanager
    {
        static List<Booking> bookings = new List<Booking>();
        Flightmanager flightmanager = new Flightmanager();
        public void show(Booking a)
        {
            Console.WriteLine($"{a.bookingNumber} {a.flight.flightNumber} {a.bookingPassenger} {a.bookingDate.ToString("dd-MM-yyyy")} {a.bookingType} {a.seatNumber}");
        }
        public void list()
        {
            foreach (Booking a in bookings)
            {
                show(a);
            }
        }
        public void create(int bookingNumber, int flightno, string bookingPassenger, DateTime bookingDate, string bookingType, int seatNumber)
        {
            Flight flight = flightmanager.find(flightno);
            if (flight == null)
            {
                Console.WriteLine($"{flightno}");
                return;
            }
            Booking a = new Booking(bookingNumber, flight, bookingPassenger, bookingDate, bookingType, seatNumber);
            bookings.Add(a);
        }
        public void update(int bookingNumber, int flightno, string bookingPassenger, DateTime bookingDate, string bookingType, int seatNumber)
        {
            var a = bookings.Find(p => p.bookingNumber == bookingNumber);
            var flight = flightmanager.find(flightno);
            if (flight == null)
            {
                Console.WriteLine();
                return;
            }
            a.bookingPassenger = bookingPassenger;
            a.bookingDate = bookingDate;
            a.bookingType = bookingType;
            a.seatNumber = seatNumber;
        }
        public void remove(int bookingNumber, int flightno, string bookingPassenger, string bookingflight, DateTime bookingDate, string bookingType, int seatNumber)
        {
            var a = bookings.Find(p => p.bookingNumber == bookingNumber);
            bookings.Remove(a);
        }
        public Booking find(int bookingNumber)
        {
            return bookings.Find(p => p.bookingNumber == bookingNumber);
        }

        public void bookingRequest(string destination, DateTime time, int seatnumber, string passengerName, string bookingType)
        {
            Flight flight = flightmanager.find(destination, time);
            if(flight == null)
            {
                Console.WriteLine("No flight available for the destination at the requested time");
                return;
            }
            else
            {
                Console.WriteLine($"Flight found with number {flight.flightNumber} with price of {flight.ticketPrice} . Kindly make payment");
                var amountPaid = decimal.Parse(Console.ReadLine());
                if(amountPaid >= flight.ticketPrice)
                {
                    var bookingNumber = new Random().Next(10, 99);
                    create(bookingNumber, flight.flightNumber, passengerName, DateTime.Now, bookingType, seatnumber);
                    Console.WriteLine($"Booking Successful. Your ticket number is {bookingNumber}");
                }
                else
                {
                    Console.WriteLine("Invalid amount paid");
                }
            }
        }

        public int getAvailableSeats(int flightNumber)
        {
           var flight=  flightmanager.find(flightNumber);
            if(flight == null)
            {
                Console.WriteLine("No flight found");
                return 0;
            }
            else
            {
               var flightBookings = bookings.FindAll(b => b.flight.flightNumber == flightNumber);
                var totalBookings = flightBookings.Count;
                var availableSeats = flight.aircraft.capacity - totalBookings;
                Console.WriteLine($"Available number of seats is {availableSeats}");
                return availableSeats;
            }
        }
    }
}
