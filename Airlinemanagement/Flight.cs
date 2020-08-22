using System;
using System.Collections.Generic;
using System.Text;

namespace Airlinemanagement
{
    public class Flight
    {
        private int id;
        private int flightNumber;
        private string registrationNumber;
        private string takeOfPoint;
        private DateTime takeOfTime;
        private DateTime landingTime;
        private string destination;
        private decimal flightPrice;
        public Flight(int id, string registrationNumber, int flightNumber, string takeOfPoint, DateTime takeOfTime, DateTime landingTime, string destination, decimal flightPrice)
        {
            this.id = id;
            this.flightNumber = flightNumber;
            this.registrationNumber = registrationNumber;
            this.takeOfPoint = takeOfPoint;
            this.takeOfTime = takeOfTime;
            this.landingTime = landingTime;
            this.destination = destination;
            this.flightPrice = flightPrice;
        }
        public void setId(int id)
        {
            this.id = id;
        }
        public int getId()
        {
            return id;
        }

        public void setFlightNumber(int flightNumber)
        {
            this.flightNumber = flightNumber;
        }
        public int getFlightNumber()
        {
            return flightNumber;
        }

        public void setRegistrationNumber(string registrationNumber)
        {
            this.registrationNumber = registrationNumber;
        }
        public string getRegistrationNumber()
        {
            return registrationNumber;
        }


        public void setTakeOfPoint(string takeOfPoint)
        {
            this.takeOfPoint = takeOfPoint;
        }
        public string getTakeOfPoint()
        {
            return takeOfPoint;
        }

        public void setTakeOfTime(DateTime takeOfTime)
        {
            this.takeOfTime = takeOfTime;
        }
        public DateTime getTakeOfTime()
        {
            return takeOfTime;
        }

        public void setLandingTime(DateTime landingTime)
        {
            this.landingTime = landingTime;
        }
        public DateTime getLandingTime()
        {
            return landingTime;
        }

        public void setDestination(string destination)
        {
            this.destination = destination;
        }
        public string getDestination()
        {
            return destination;
        }

        public void setFlightPrice(decimal flightPrice)
        {
            this.flightPrice = flightPrice;
        }
        public decimal getFlightPrice()
        {
            return flightPrice;
        }

        public override string ToString()
        {
            return $"{id}\t{registrationNumber}\t{flightNumber}\t{takeOfPoint}\t{takeOfTime}\t{landingTime}\t{destination}\t{flightPrice}";
        }

        /*internal static Flight Parse(string line)
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
            return $"{registrationNumber}\t{flightNumber}\t{takeOfPoint}\t{destination}\t{takeOfTime:HH:mm:ss}\t{landingTime:HH:mm:ss}\t{flightPrice}";
        }*/
    }
}
