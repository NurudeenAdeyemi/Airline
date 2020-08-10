using System;
using System.Collections.Generic;
using System.Text;

namespace Airlinemanagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AirlineManagementSystem.main();
        }
            //public static void Main(string[] args)
            //{

            //    Aircraftmanager aircraftmanager = new Aircraftmanager();
            //    aircraftmanager.create(400, "NG475950", "A", "Booing");
            //    aircraftmanager.create(200, "NG475957", "B", "Chinco");
            //    aircraftmanager.create(500, "NG475955", "C", "German");
            //    aircraftmanager.list();
            //    aircraftmanager.update(1000, "NG475955", "A", "Boing200");
            //    aircraftmanager.list();
            //    aircraftmanager.remove(200, "NG475957", "B", "Chinco");
            //    aircraftmanager.list();



            //    Flightmanager flightmanager = new Flightmanager();
            //    flightmanager.create(1001, "NG475950", "Lagos", new DateTime(2020, 08, 6,13,45,40), new DateTime(2020, 08, 6, 16, 45, 40), "Abuja", 2000.00M);
            //    flightmanager.create(1002, "NG475955", "Abuja", new DateTime(2020, 08, 6, 8, 30, 34), new DateTime(2020, 08, 6, 13, 45, 40), "Lagos", 8000.00M);
            //    flightmanager.create(1003, "NG475955", "Porthacourt", new DateTime(2020, 08, 6, 11, 20, 40), new DateTime(2020, 08, 6, 20, 43, 40), "Abuja", 5000.00M);
            //    flightmanager.list();
            //    flightmanager.update(1003, "NG475955", "Porthacourt", new DateTime(2020, 08, 9, 11, 20, 40), new DateTime(2020, 08, 9, 20, 43, 40), "Abuja", 5000.00M);
            //    flightmanager.list();
            //    flightmanager.remove(1002, "NG475955", "Abuja", new DateTime(2020, 08, 6, 8, 30, 40), new DateTime(2020, 08, 6, 13, 45, 40), "Lagos", 8000.00M);
            //    flightmanager.list();

            //    Bookingmanager bookingmanager = new Bookingmanager();
            //    bookingmanager.create(1001, 001, "Adeyemi Olabode", "Nigerian Airway", DateTime.Parse("2020-08-07"), "Economic", 01);
            //    bookingmanager.create(1002, 001, "Olabanjo Kola", "American Airway", DateTime.Parse("2020-08-05"), "Commercial", 24);
            //    bookingmanager.create(1003, 002, "Obasanjo Femi", "Ethopia Airway", DateTime.Parse("2020-08-01"), "First Class", 05);
            //    bookingmanager.list();
            //    bookingmanager.update(1003, 003, "Obasanjo Femi", "Ethiopia Airway", DateTime.Parse("2020-08-01"), "Commercial", 030);
            //    bookingmanager.list();
            //    bookingmanager.remove(1002, 001, "Olabanjo Kola", "American Airway", DateTime.Parse("2020-08-05"), "Commercial", 24);
            //    bookingmanager.list();

            //    Passengermanager persengermanager = new Passengermanager();
            //    persengermanager.create(001, 002, "Adeyemi Nurudeen Olatunbosun", "Obantoko", 08031905878, "adeyemisworld@gmail.com,", "Male", new DateTime(1990, 08, 04));
            //    persengermanager.create(002, 003, "Olanrewaju Basit Ajoke", "Ojokoro", 07031905878, "basitajoke@gmail.com,", "Female", new DateTime(1960, 07, 6));
            //    persengermanager.create(003, 004, "Durojaye Fineboy Ayinde", "Osogbo", 09031905878, "fineboy@yahoo.com,", "Male", new DateTime(2005, 09, 6));
            //    persengermanager.list();
            //    persengermanager.update(001, 005, "Adeyemi Nurudeen Olatunbosun", "Ijebu Ode", 08031905878, "adeyemino@funaab.edu.ng", "Male", new DateTime(1991, 08, 6));
            //    persengermanager.list();
            //    persengermanager.remove(003, "Durojaye Fineboy Ayinde", "Osogbo", 09031905878, "fineboy@yahoo.com,", "Male", new DateTime(2005, 09, 6));
            //    persengermanager.list();
            //    persengermanager.find(002);
            //    Console.ReadKey();
            //}
        }
}
