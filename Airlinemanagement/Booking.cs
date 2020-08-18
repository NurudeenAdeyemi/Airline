using System;
using System.Collections.Generic;
using System.Text;


namespace Airlinemanagement
{
    public class Booking
    {
        public int bookingNumber;
        public int flightNum;
        //public string bookingPassenger;
        public DateTime bookingDate;
        public string bookingType;
        public int seatNumber;

        public Booking(int bookingNumber, int flightNum, DateTime bookingDate, string bookingType, int seatNumber)
        {
            this.bookingNumber = bookingNumber;
            this.flightNum = flightNum;
            //this.bookingPassenger = bookingPassenger;
            this.bookingDate = bookingDate;
            this.bookingType = bookingType;
            this.seatNumber = seatNumber;
        }

        internal static Booking Parse(string line)
        {
            var props = line.Split('\t');
            int bookingNumber = int.Parse(props[0]);
            int flightNum = int.Parse(props[1]);
            DateTime bookingDate= DateTime.Parse(props[2]);
            int seatNumber = int.Parse(props[4]);
            return new Booking(bookingNumber, flightNum, bookingDate, props[3], seatNumber);
        }

        public override string ToString()
        {
            return $"{bookingNumber}\t{flightNum}\t{bookingDate.ToShortDateString()}\t{bookingType}\t{seatNumber}";
        }
    }
}
