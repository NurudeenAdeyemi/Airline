using System;
using System.Collections.Generic;
using System.Text;

namespace Airlinemanagement
{
    public class Flight
    {
        public int flightNumber;
        public string aircraftNum;
        public string takeOfPoint;
        public DateTime takeOfTime;
        public DateTime landingTime;
        public string destination;
        public decimal flightPrice;
        public Flight(string aircraftNum, int flightNumber, string takeOfPoint, string destination, DateTime takeOfTime, DateTime landingTime,  decimal flightPrice)
        {
            this.flightNumber = flightNumber;
            this.aircraftNum = aircraftNum;
            this.takeOfPoint = takeOfPoint;
            this.takeOfTime = takeOfTime;
            this.landingTime = landingTime;
            this.destination = destination;
            this.flightPrice = flightPrice;
        }

        internal static Flight Parse(string line)
        {
            var props = line.Split('\t');
            int flightNumber = int.Parse(props[1]);
            DateTime takeOfTime= DateTime.Parse(props[4]);
            DateTime landingTime = DateTime.Parse(props[5]);
            decimal flightPrice = int.Parse(props[6]);
            
            return new Flight(props[0], flightNumber, props[2], props[3], takeOfTime, landingTime, flightPrice);
        }

        public override string ToString()
        {
            return $"{aircraftNum}\t{flightNumber}\t{takeOfPoint}\t{destination}\t{takeOfTime:HH:mm:ss}\t{landingTime:HH:mm:ss}\t{flightPrice}";
        }
    }
}
