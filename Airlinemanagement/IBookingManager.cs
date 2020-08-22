using System;
using System.Collections.Generic;
using System.Text;

namespace Airlinemanagement
{
    public interface IBookingManager
    {
        public List<Booking> getAll();

        public bool create(int bookingNumber, int flightNumber, DateTime bookingDate, string bookingType, int seatNumber);

        public bool update(int bookingNumber, int flightNumber, DateTime bookingDate, string bookingType, int seatNumber);

        public bool remove(int bookingNumber);

        public Booking find(int bookingNumber);

        public void displayAll();
    }
}
