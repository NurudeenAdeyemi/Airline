using System;

namespace Airlinemanagement
{

    public class Aircraft
    {
        //instance variables or parameters
        private int id;
        private int capacity;
        private string registrationNumber;
        private string type;
        private string name;
        public Aircraft(int id, string name, string type, string registrationNumber, int capacity) //constructor is a method used to instantiate the object , has the same name as the class
        {
            //(this) is a special keyword and a reference to the current instance of the class
            this.id = id;
            this.name = name; 
            this.type = type;
            this.capacity = capacity;
            this.registrationNumber = registrationNumber;
        }


        public void setId(int id)
        {
            this.id = id;
        }
        public int getId()
        {
            return id;
        }

        public void setCapacity(int capacity)
        {
            this.capacity = capacity;
        }
        public int getCapacity()
        {
            return capacity;
        }

        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return name;
        }


        public void setType(string type)
        {
            this.type = type;
        }
        public string getType()
        {
            return type;
        }

        public void setRegistrationNumber(string registrationNumber)
        {
            this.registrationNumber = registrationNumber;
        }
        public string getRegistrationNumber()
        {
            return registrationNumber;
        }

        public override string ToString()
        {
            return $"{id}\t{registrationNumber}\t{name}\t{type}\t{capacity}";
        }

        

        /* internal static Aircraft Parse(string line)
         {
             var props = line.Split('\t');
             int capacity = int.Parse(props[2]);
             return new Aircraft(props[0], props[1], capacity, props[3]);
         }

         public override string ToString()
         {
             return $"{name}\t{type}\t{capacity}\t{registrationNumber}";
         }*/
    }
}
