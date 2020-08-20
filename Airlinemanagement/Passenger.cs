using System;
using System.Collections.Generic;
using System.Text;

namespace Airlinemanagement
{
    public class Passenger
    {
        //public int iD;
        public int bookingNumber;
        public string name;
        public string address;
        public double phoneNumber;
        public string email;
        public string gender;
        public DateTime dateOfBirth;
        public Passenger(string name, int bookingNumber, string address, double phoneNumber, string email, string gender, DateTime dateOfBirth)
        {
            //this.iD = iD;
            this.name = name;
            this.bookingNumber = bookingNumber;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
        }

        internal static Passenger Parse(string line)
        {
            var props = line.Split('\t');
            int bookingNumber = int.Parse(props[1]);
            double phoneNumber = double.Parse(props[3]);
            DateTime dateOfBirth = DateTime.Parse(props[6]);
            return new Passenger(props[0], bookingNumber, props[2], phoneNumber, props[4], props[5], dateOfBirth);
        }

        public override string ToString()
        {
            return $"{name}\t{bookingNumber}\t{address}\t{phoneNumber}\t{email}\t{gender}\t{dateOfBirth.ToShortDateString()}";
        }
    }
}
