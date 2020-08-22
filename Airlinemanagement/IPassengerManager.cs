using System;
using System.Collections.Generic;
using System.Text;

namespace Airlinemanagement
{
    public interface IPassengerManager
    {
        public List<Passenger> getAll();

        public bool create(string name, int bookingNumber, string address, double phoneNumber, string email, string gender, DateTime dateOfBirth);

        public bool update(string name, int bookingNumber, string address, double phoneNumber, string email, string gender, DateTime dateOfBirth);

        public bool remove(string name);

        public Passenger find(string name);

        public void displayAll();
    }
}
