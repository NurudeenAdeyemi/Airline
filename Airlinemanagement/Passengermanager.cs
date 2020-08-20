using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Airlinemanagement
{
    class Passengermanager
    {
        //static List<Passenger> passengers = new List<Passenger>();
        static List<Passenger> passengers;
        //Bookingmanager bookingmanager = new Bookingmanager();
        Bookingmanager bookingmanager;
        public Passengermanager(Bookingmanager bookingmanager)
        {
            this.bookingmanager = bookingmanager;
            passengers = new List<Passenger>();

            try
            {
                var lines = File.ReadAllLines("passenger.txt");
                foreach (var line in lines)
                {
                    var passenger = Passenger.Parse(line);
                    passengers.Add(passenger);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void show(Passenger a)
        {
            Console.WriteLine($"{a.name} {a.bookingNumber} {a.address} {a.phoneNumber} {a.email} {a.gender} {a.dateOfBirth.ToShortDateString()}");
        }
        public void list()
        {
            foreach (Passenger a in passengers)
            {
                show(a);
            }
        }
        public void create(string name, int bookingNumber, string address, double phoneNumber, string email, string gender, DateTime dateOfBirth)
        {
            Booking booking = bookingmanager.find(bookingNumber);
            if (booking == null)
            {
                Console.WriteLine($"{bookingNumber}");
                return;
            }
            Passenger a = new Passenger(name, bookingNumber, address, phoneNumber, email, gender, dateOfBirth);
            passengers.Add(a);
            TextWriter writer = new StreamWriter("passenger.txt", true);
            writer.WriteLine(a.ToString());
            writer.Close();
        }
        public void update(string name, int bookingNumber, string address, double phoneNumber, string email, string gender, DateTime dateOfBirth)
        {
            var a = passengers.Find(p => p.name == name);
            var booking = bookingmanager.find(bookingNumber);
            if (booking == null)
            {
                Console.WriteLine();
                return;
            }
            a.address = address;
            a.phoneNumber = phoneNumber;
            a.email = email;
            a.gender = gender;
            a.dateOfBirth = dateOfBirth;
            RefreshFile();
        }

        private void RefreshFile()
        {
            TextWriter writer = new StreamWriter("passenger.txt");
            foreach (var passenger in passengers)
            {
                writer.WriteLine(passenger);
            }
            writer.Flush();
            writer.Close();
        }
    
        public void remove(string name)
        {
            var a = passengers.Find(p => p.name == name);
            passengers.Remove(a);
            RefreshFile();
        }
        public Passenger find(string name)
        {
            return passengers.Find(p => p.name == name);
        }
    }
}
