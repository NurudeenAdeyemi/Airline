using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Airlinemanagement
{
    public class Flightmanager
    {
        public List<Flight> flights;
        /*= new List<Flight>();
        Aircraftmanager aircraftmanager = new Aircraftmanager();*/
        Aircraftmanager aircraftmanager;
        public Flightmanager(Aircraftmanager aircraftmanager)
        {
            this.aircraftmanager = aircraftmanager;
            flights = new List<Flight>();

            try
            {
                var lines = File.ReadAllLines("flight.txt");
                foreach (var line in lines)
                {
                    
                    var flight = Flight.Parse(line);
                    flights.Add(flight);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void show(Flight a)
        {
            //Console.WriteLine($"{a.aircraft} {a.flightNumber} {a.takeOfPoint} {a.destination} {a.takeOfTime:HH:mm:ss} {a.landingTime:HH:mm:ss} {a.flightPrice}");
            Console.WriteLine($"{a.registrationNumber} {a.flightNumber} {a.takeOfPoint} {a.destination} {a.takeOfTime:HH:mm:ss} {a.landingTime:HH:mm:ss} {a.flightPrice}");
        }
        public void list()
        {
            foreach (Flight a in flights)
            {
                show(a);
            }
        }

        public void create(string registrationNumber, int flightNumber, string takeOfPoint, string destination, DateTime takeOfTime, DateTime landingTime, decimal flightPrice)
        {
            Aircraft aircraft = aircraftmanager.find(registrationNumber);
            if (aircraft == null)
            {
                Console.WriteLine($"Aircraft with {registrationNumber} could not be found");
                return;
            }
            Flight a = new Flight(registrationNumber, flightNumber, takeOfPoint, destination, takeOfTime, landingTime, flightPrice);
            flights.Add(a);
            TextWriter writer = new StreamWriter("flight.txt", true);
            writer.WriteLine(a.ToString());
            writer.Close();
        }
        public void update(string registrationNumber, int flightNumber, string takeOfPoint, string destination, DateTime takeOfTime, DateTime landingTime, decimal flightPrice)
        {
            var a = flights.Find(p => p.flightNumber == flightNumber);
            var aircraft = aircraftmanager.find(registrationNumber);
            if (aircraft == null)
            {
                Console.WriteLine();
                return;
            }
            a.registrationNumber = registrationNumber;
            a.takeOfPoint = takeOfPoint;
            a.takeOfTime = takeOfTime;
            a.landingTime = landingTime;
            a.destination = destination;
            a.flightPrice = flightPrice;
            RefreshFile();
        }

        private void RefreshFile()
        {
            TextWriter writer = new StreamWriter("flight.txt");
            foreach (var flight in flights)
            {
                writer.WriteLine(flight);
            }
            writer.Flush();
            writer.Close();
        }
        public void remove(int flightNumber)
        {
            var a = flights.Find(p => p.flightNumber == flightNumber);
            flights.Remove(a);
            RefreshFile();
        }
        public Flight find(int flightNumber)
        {
            return flights.Find(p => p.flightNumber == flightNumber);
        }

        public Flight find(string destination, DateTime time)
        {
            return flights.Find(f => f.destination == destination && f.takeOfTime.TimeOfDay == time.TimeOfDay);
        }

    }
}
