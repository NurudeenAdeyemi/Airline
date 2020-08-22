using System;
using System.Collections.Generic;
using System.Text;

namespace Airlinemanagement
{
    public class Passenger
    {
        private int id;
        private int bookingNumber;
        private string name;
        private string address;
        private double phoneNumber;
        private string email;
        private string gender;
        private DateTime dateOfBirth;
        public Passenger(int id, string name, int bookingNumber, string address, double phoneNumber, string email, string gender, DateTime dateOfBirth)
        {
            this.id = id;
            this.name = name;
            this.bookingNumber = bookingNumber;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
        }

        public void setId(int id)
        {
            this.id = id;
        }
        public int getId()
        {
            return id;
        }

        public void setBookingNumber(int bookingNumber)
        {
            this.bookingNumber = bookingNumber;
        }
        public int getBookingNumber()
        {
            return bookingNumber;
        }

        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return name;
        }

        public void setAddress(string address)
        {
            this.address = address;
        }
        public string getAddress()
        {
            return address;
        }

        public void setPhoneNumber(double phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }
        public double getPhoneNumber()
        {
            return phoneNumber;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }
        public string getEmail()
        {
            return email;
        }

        public void setGender(string gender)
        {
            this.gender = gender;
        }
        public string getGender()
        {
            return gender;
        }

        public void setDateOfBirth(DateTime dateOfBirth)
        {
            this.dateOfBirth = dateOfBirth;
        }
        public DateTime getDateOfBirth()
        {
            return dateOfBirth;
        }

        public override string ToString()
        {
            return $"{id}\t{name}\t{bookingNumber}\t{phoneNumber}\t{address}\t{email}\t{gender}\t{dateOfBirth}";
        }
        /*internal static Passenger Parse(string line)
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
        }*/
    }
}
