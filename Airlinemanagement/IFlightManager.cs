using System;
using System.Collections.Generic;
using System.Text;

namespace Airlinemanagement
{
    public interface IFlightManager
    {
        public List<Flight> getAll();

        public bool create(string registrationNumber, int flightNumber, string takeOfPoint, DateTime takeOfTime, DateTime landingTime, string destination, decimal flightPrice);

        public bool update(string registrationNumber, int flightNumber, string takeOfPoint, DateTime takeOfTime, DateTime landingTime, string destination, decimal flightPrice);

        public bool remove(int flightNumber);

        public Flight find(int flightNumber);

        public void displayAll();
    }
}
