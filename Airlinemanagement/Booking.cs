using System;
using System.Collections.Generic;
using System.Text;


namespace Airlinemanagement
{
    public class Booking
    {
        private int id;
        private int bookingNumber;
        private int flightNumber;
        private DateTime bookingDate;
        private string bookingType;
        private int seatNumber;

        public Booking(int id, int bookingNumber, int flightNumber, DateTime bookingDate, string bookingType, int seatNumber)
        {
            this.id = id;
            this.bookingNumber = bookingNumber;
            this.flightNumber = flightNumber;
            this.bookingDate = bookingDate;
            this.bookingType = bookingType;
            this.seatNumber = seatNumber;
        }

        public void setId(int id)
        {
            this.id = id;
        }
        public int getId()
        {
            return id;
        }

        public void setFlightNumber(int flightNumber)
        {
            this.flightNumber = flightNumber;
        }
        public int getFlightNumber()
        {
            return flightNumber;
        }

        public void setBookingNumber(int bookingNumber)
        {
            this.bookingNumber = bookingNumber;
        }
        public int getBookingNumber()
        {
            return bookingNumber;
        }


        public void setBookingDate(DateTime bookingDate)
        {
            this.bookingDate = bookingDate;
        }
        public DateTime getBookingDate()
        {
            return bookingDate;
        }

        public void setBookingType(string bookingType)
        {
            this.bookingType = bookingType;
        }
        public string getBookingType()
        {
            return bookingType;
        }

        public void setSeatNumbere(int seatNumber)
        {
            this.seatNumber = seatNumber;
        }
        public int getSeatNumber()
        {
            return seatNumber;
        }

        public override string ToString()
        {
            return $"{id}\t{bookingNumber}\t{flightNumber}\t{bookingDate}\t{bookingType}\t{seatNumber}";
        }
        /*internal static Booking Parse(string line)
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
        }*/
    }
}
