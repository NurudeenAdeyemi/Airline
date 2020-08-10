using System;

namespace Airlinemanagement
{
    
    public class Aircraft
    {
        public int capacity;
        public string registrationNumber;
        public string type;
        public string name;
        public Aircraft(int capacity, string registrationNumber, string type, string name)
        {
            this.capacity = capacity;
            this.registrationNumber = registrationNumber;
            this.type = type;
            this.name = name;
        }
    }
}
