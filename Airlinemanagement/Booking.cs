using System;
using System.Collections.Generic;
using System.Text;


namespace Airlinemanagement
{
    public class Booking
    {
        public int bookingNumber;
        public int flightNumber;
        //public string bookingPassenger;
        public DateTime bookingDate;
        public string bookingType;
        public int seatNumber;

        public Booking(int bookingNumber, int flightNumber, DateTime bookingDate, string bookingType, int seatNumber)
        {
            this.bookingNumber = bookingNumber;
            this.flightNumber = flightNumber;
            //this.bookingPassenger = bookingPassenger;
            this.bookingDate = bookingDate;
            this.bookingType = bookingType;
            this.seatNumber = seatNumber;
        }

        internal static Booking Parse(string line)
        {
            var props = line.Split('\t');
            int bookingNumber = int.Parse(props[0]);
            int flightNumber = int.Parse(props[1]);
            DateTime bookingDate= DateTime.Parse(props[2]);
            int seatNumber = int.Parse(props[4]);
            return new Booking(bookingNumber, flightNumber, bookingDate, props[3], seatNumber);
        }

        public override string ToString()
        {
            return $"{bookingNumber}\t{flightNumber}\t{bookingDate.ToShortDateString()}\t{bookingType}\t{seatNumber}";
        }
    }
}
