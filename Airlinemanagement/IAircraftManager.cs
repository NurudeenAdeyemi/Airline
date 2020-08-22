using System;
using System.Collections.Generic;
using System.Text;

namespace Airlinemanagement
{
    public interface IAircraftManager
    {
        public List<Aircraft> getAll();

        public bool create(string name, string type, string registrationNumber, int capacity);

        public bool update(string name, string type, string registrationNumber, int capacity);

        public bool remove(string registrationNumber);

        public Aircraft find(string registrationNumber);

        public void displayAll();


    }
}

