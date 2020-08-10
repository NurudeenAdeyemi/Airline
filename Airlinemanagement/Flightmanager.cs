using System;
using System.Collections.Generic;
using System.Text;

namespace Airlinemanagement
{
    public class Flightmanager
    {
        static List<Flight> flights = new List<Flight>();
        Aircraftmanager aircraftmanager = new Aircraftmanager(); 
        public void show(Flight a)
        {
            Console.WriteLine($"{a.flightNumber} {a.aircraft.registrationNumber} {a.takeOfairport} {a.takeOfTime:HH:mm:ss} {a.landingTime:HH:mm:ss} {a.destination} {a.ticketPrice}");
        }
        public void list()
        {
            foreach (Flight a in flights)
            {
                show(a);
            }
        }

        public void create(int flighNumber, string aircraftno, string takeOfairport, DateTime takeOfTime, DateTime landingTime, string destination, decimal ticketPrice)
        {
            Aircraft aircraft= aircraftmanager.find(aircraftno);
            if (aircraft == null)
            {
                Console.WriteLine($"{aircraftno}");
                return;
            }
            Flight a = new Flight(flighNumber, aircraft, takeOfairport, takeOfTime, landingTime, destination, ticketPrice);
            flights.Add(a);
        }
        public void update(int flightNumber, string aircraftno, string takeOfairport, DateTime takeOfTime, DateTime landingTime, string destination, decimal ticketPrice)
        {
            var a = flights.Find(p => p.flightNumber == flightNumber);
            var aircraft= aircraftmanager.find(aircraftno);
            if (aircraft == null)
            {
                Console.WriteLine();
                return;
            }
            a.aircraft = aircraft;
            a.takeOfairport = takeOfairport;
            a.takeOfTime = takeOfTime;
            a.landingTime = landingTime;
            a.destination = destination;
            a.ticketPrice = ticketPrice;
        }
        public void remove(int flighNumber, string aircraft, string takeOfairport, DateTime takeOfTime, DateTime landingTime, string destination, decimal ticketPrice)
        {
            var a = flights.Find(p => p.flightNumber == flighNumber);
            flights.Remove(a);
        }
        public Flight find(int flightNumber)
        {
            return flights.Find(p => p.flightNumber == flightNumber);
        }

        public Flight find(string destination, DateTime time)
        {
           return  flights.Find(f => f.destination == destination && f.takeOfTime.TimeOfDay == time.TimeOfDay);
        }

    }
}
