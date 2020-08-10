using System;
using System.Collections.Generic;

namespace Airlinemanagement
{
    public class Aircraftmanager
    {

        public static List<Aircraft> aircrafts = new List<Aircraft>();
        public void show(Aircraft a)
        {
            Console.WriteLine($"{a.capacity} {a.registrationNumber} {a.type} {a.name}");
        }
        public void list()
        {
            foreach (Aircraft a in aircrafts)
            {
                show(a);
            }
        }
        public void create(int capacity, string registrationNumber, string type, string name)
        {
            Aircraft a = new Aircraft(capacity, registrationNumber, type, name);
            aircrafts.Add(a);
        }
        public void update(int capacity, string registrationNumber, string type, string name)
        {
            var a = aircrafts.Find(p => p.registrationNumber == registrationNumber);
            a.capacity = capacity;
            a.type = type;
            a.name = name;
        }
        public void remove(string registrationNumber)
        {
            var a = aircrafts.Find(p => p.registrationNumber == registrationNumber);
            aircrafts.Remove(a);
        }
        public Aircraft find(string registrationNumber)
        {
            return aircrafts.Find(p => p.registrationNumber == registrationNumber);
        }
        public void findAircraft(string registrationNumber)
        {
            var a = aircrafts.Find(p => p.registrationNumber == registrationNumber);
            aircrafts.Contains(a);
            if (registrationNumber == null)
            {
                Console.WriteLine($"There is no aircraft with the registration Number {registrationNumber}");
                return;
            }
        }
}
}
