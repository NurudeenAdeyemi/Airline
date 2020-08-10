using System;
using System.Collections.Generic;
using System.Text;

namespace Airlinemanagement
{
    class Passengermanager
    {
        static List<Passenger> passengers = new List<Passenger>();
        Bookingmanager bookingmanager = new Bookingmanager();
        public void show(Passenger a)
        {
            Console.WriteLine($"{a.booking.bookingNumber} {a.name} {a.address} {a.phoneNumber} {a.email} {a.gender} {a.dateOfBirth:dd:MM:yyyy}");
        }
        public void list()
        {
            foreach (Passenger a in passengers)
            {
                show(a);
            }
        }
        public void create(int bookingno, string name, string address, double phoneNumber, string email, string gender, DateTime dateOfBirth)
        {
            Booking booking = bookingmanager.find(bookingno);
            if (booking == null)
            {
                Console.WriteLine($"{bookingno}");
                return;
            }
            Passenger a = new Passenger(booking, name, address, phoneNumber, email, gender, dateOfBirth);
            passengers.Add(a);
        }
        public void update(int bookingno, string name, string address, double phoneNumber, string email, string gender, DateTime dateOfBirth)
        {
            var a = passengers.Find(p => p.name == name);
            var booking = bookingmanager.find(bookingno);
            if (booking == null)
            {
                Console.WriteLine();
                return;
            }
            a.address = address;
            a.phoneNumber = phoneNumber;
            a.email = email;
            a.gender = gender;
            a.dateOfBirth= dateOfBirth;
        }
        public void remove(string name, string address, double phoneNumber, string email, string gender, DateTime dateOfBirth)
        {
            var a = passengers.Find(p => p.name == name);
            passengers.Remove(a);
        }
        public Passenger find(string name)
        {
            return passengers.Find(p => p.name == name);
        }
    }
}
