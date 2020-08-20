using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Airlinemanagement
{
    public class Bookingmanager
    {
        static List<Booking> bookings;
        //Flightmanager flightmanager = new Flightmanager();
        Flightmanager flightmanager;
        public Bookingmanager(Flightmanager flightmanager)
        {
            this.flightmanager = flightmanager;
            bookings = new List<Booking>();

            try
            {
                var lines = File.ReadAllLines("booking.txt");
                foreach (var line in lines)
                {
                    var booking = Booking.Parse(line);
                    bookings.Add(booking);
                }
            }
            catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
        }

        public void show(Booking a)
        {
            Console.WriteLine($"{a.bookingNumber} {a.flightNumber} {a.bookingDate.ToShortDateString()} {a.bookingType} {a.seatNumber}");
        }
        public void list()
        {
            foreach (Booking a in bookings)
            {
                show(a);
            }
        }
        public void create(int bookingNumber, int flightNumber, DateTime bookingDate, string bookingType, int seatNumber)
        {
            Flight flight = flightmanager.find(flightNumber);
            if (flight == null)
            {
                Console.WriteLine($"{flightNumber}");
                return;
            }
            Booking a = new Booking(bookingNumber, flightNumber, bookingDate, bookingType, seatNumber);
            bookings.Add(a);
            TextWriter writer = new StreamWriter("booking.txt", true);
            writer.WriteLine(a.ToString());
            writer.Close();
        }
        public void update(int bookingNumber, int flightNumber, DateTime bookingDate, string bookingType, int seatNumber)
        {
            var a = bookings.Find(p => p.bookingNumber == bookingNumber);
            var flight = flightmanager.find(flightNumber);
            if (flight == null)
            {
                Console.WriteLine();
                return;
            }
           // a.bookingPassenger = bookingPassenger;
            a.bookingDate = bookingDate;
            a.bookingType = bookingType;
            a.seatNumber = seatNumber;
            RefreshFile();
        }

        private void RefreshFile()
        {
            TextWriter writer = new StreamWriter("booking.txt");
            foreach (var booking in bookings)
            {
                writer.WriteLine(booking);
            }
            writer.Flush();
            writer.Close();
        }
        public void remove(int bookingNumber)
        {
            var a = bookings.Find(p => p.bookingNumber == bookingNumber);
            bookings.Remove(a);
            RefreshFile();
        }
        public Booking find(int bookingNumber)
        {
            return bookings.Find(p => p.bookingNumber == bookingNumber);
        }

        /*public void bookingRequest(string destination, DateTime time, int seatnumber, string passengerName, string bookingType)
        {
            Flight flight = flightmanager.find(destination, time);
            if (flight == null)
            {
                Console.WriteLine("No flight available for the destination at the requested time");
                return;
            }
            else
            {
                Console.WriteLine($"Flight found with number {flight.flightNumber} with price of {flight.flightPrice} . Kindly make payment");
                var amountPaid = decimal.Parse(Console.ReadLine());
                if (amountPaid >= flight.flightPrice)
                {
                    var bookingNumber = new Random().Next(10, 99);
                    create(bookingNumber, flight.flightNumber, DateTime.Now, bookingType, seatnumber);
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
            var flight = flightmanager.find(flightNumber);
            if (flight == null)
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
        }*/
    }
}
