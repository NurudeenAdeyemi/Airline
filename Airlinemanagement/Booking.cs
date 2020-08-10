using System;
using System.Collections.Generic;
using System.Text;


namespace Airlinemanagement
{
    public class Booking
    {
        public int bookingNumber;
        public Flight flight;
        public string bookingPassenger;
        public DateTime bookingDate;
        public string bookingType;
        public int seatNumber;
         
        public Booking(int bookingNumber, Flight flight, string bookingPassenger, DateTime bookingDate, string bookingType, int seatNumber)
        {
            this.bookingNumber = bookingNumber;
            this.flight = flight;
            this.bookingPassenger = bookingPassenger;
            this.bookingDate = bookingDate;
            this.bookingType = bookingType;
            this.seatNumber = seatNumber;
        }
    }
}
