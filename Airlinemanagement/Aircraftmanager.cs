using System;
using System.IO;
using System.Collections.Generic;

namespace Airlinemanagement
{
    public class Aircraftmanager
    {
        public List<Aircraft> aircrafts;
       // private TextWriter writer;
        public Aircraftmanager()
        {
            aircrafts = new List<Aircraft>();
           
            try
            {
                var lines = File.ReadAllLines("aircraft.txt");
                foreach (var line in lines)
                {
                    var aircraft = Aircraft.Parse(line);
                    aircrafts.Add(aircraft);
                }
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void show(Aircraft a)
        {
            Console.WriteLine($"{a.name} {a.type} {a.capacity} {a.registrationNumber}"); // using member access operator(.) to reference its accessible members
        }

        public void list()
        {
            foreach (Aircraft a in aircrafts)
            {
                show(a);
            }
        }
        public void create(string name, string type, int capacity, string registrationNumber)//Defining a method CREATE
        {
            Aircraft a = new Aircraft(name, type, capacity, registrationNumber); //Creating and instance of of the class (Aircraft) to call the method CREATE
            aircrafts.Add(a);
           TextWriter writer= new StreamWriter("aircraft.txt", true);
            writer.WriteLine(a.ToString());
            writer.Close();
        }
        public void update(string name, string type, int capacity, string registrationNumber)
        {
            var a = aircrafts.Find(p => p.registrationNumber == registrationNumber);
            a.capacity = capacity;
            a.type = type;
            a.name = name;
            RefreshFile();
        }

        private void RefreshFile()
        {
            TextWriter writer = new StreamWriter("aircraft.txt");
            foreach (var aircraft in aircrafts)
            {
                writer.WriteLine(aircraft);
            }
            writer.Flush();
            writer.Close();
        }
        public void remove(string registrationNumber)
        {
            var a = aircrafts.Find(p => p.registrationNumber == registrationNumber);
            aircrafts.Remove(a);
            RefreshFile();
        }
        public Aircraft find(string registrationNumber)
        {
            return aircrafts.Find(p => p.registrationNumber == registrationNumber);
        }

    }
}
