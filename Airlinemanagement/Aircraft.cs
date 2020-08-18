using System;

namespace Airlinemanagement
{

    public class Aircraft
    {
        //instance variables or parameters
        public int capacity;
        public string registrationNumber;
        public string type;
        public string name;
        public Aircraft(string name, string type, int capacity, string registrationNumber) //constructor is a method used to instantiate the object , has the same name as the class
        {
            //(this) is a special keyword and a reference to the current instance of the class
            this.name = name; 
            this.type = type;
            this.capacity = capacity;
            this.registrationNumber = registrationNumber;
        }

        internal static Aircraft Parse(string line)
        {
            var props = line.Split('\t');
            int capacity = int.Parse(props[2]);
            return new Aircraft(props[0], props[1], capacity, props[3]);
        }

        public override string ToString()
        {
            return $"{name}\t{type}\t{capacity}\t{registrationNumber}";
        }
    }
}
