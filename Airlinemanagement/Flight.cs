using System;
using System.Collections.Generic;
using System.Text;

namespace Airlinemanagement
{
   public class Flight
    {
        public int flightNumber;
        public Aircraft aircraft;
        public string takeOfairport;
        public DateTime takeOfTime;
        public DateTime landingTime;
        public string destination;
        public decimal ticketPrice;
        public Flight(int flightNumber, Aircraft aircraft, string takeOfairport, DateTime takeOfTime, DateTime landingTime, string destination, decimal ticketPrice)
        {
            this.flightNumber = flightNumber;
            this.aircraft = aircraft;
            this.takeOfairport = takeOfairport;
            this.takeOfTime = takeOfTime;
            this.landingTime = landingTime;
            this.destination = destination;
            this.ticketPrice = ticketPrice; 
        }
    }
}
