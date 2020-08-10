using System;
using System.Collections.Generic;
using System.Text;

namespace Airlinemanagement
{
    public class Passenger
    {
        //public int iD;
        public Booking booking;
        public string name;
        public string address;
        public double phoneNumber;
        public string email;
        public string gender;
        public DateTime dateOfBirth;
        public Passenger(Booking booking, string name, string address, double phoneNumber, string email, string gender, DateTime dateOfBirth)
        {
            //this.iD = iD;
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
        }
    }
}
