using System;
using System.Collections.Generic;
using System.Text;

namespace Airlinemanagement
{
    public class Passenger
    {
        //public int iD;
        public int bookingNum;
        public string nameOfPassenger;
        public string address;
        public double phoneNumber;
        public string email;
        public string gender;
        public DateTime dateOfBirth;
        public Passenger(string nameOfPassenger, int bookingNum, string address, double phoneNumber, string email, string gender, DateTime dateOfBirth)
        {
            //this.iD = iD;
            this.nameOfPassenger = nameOfPassenger;
            this.bookingNum = bookingNum;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
        }

        internal static Passenger Parse(string line)
        {
            var props = line.Split('\t');
            int bookingNum = int.Parse(props[1]);
            double phoneNumber = double.Parse(props[3]);
            DateTime dateOfBirth = DateTime.Parse(props[6]);
            return new Passenger(props[0], bookingNum, props[2], phoneNumber, props[4], props[5], dateOfBirth);
        }

        public override string ToString()
        {
            return $"{nameOfPassenger}\t{bookingNum}\t{address}\t{phoneNumber}\t{email}\t{gender}\t{dateOfBirth.ToShortDateString()}";
        }
    }
}
