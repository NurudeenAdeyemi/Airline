using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

using MySql;
using MySql.Data.MySqlClient;

namespace Airlinemanagement
{
    public class Program
    {
        static string connStr = "server=localhost;user=root;database=airlinemanagement;port=3306;password=loveforall1990";
        static MySqlConnection conn = new MySqlConnection(connStr);
        static IAircraftManager aircraftManager = new DBAircraftManager(conn);
        static IFlightManager flightManager = new DBFlightManager(conn);
        static IBookingManager bookingManager = new DBBookingManager(conn);
        static IPassengerManager passengerManager = new DBPassengerManager(conn);

        public static void Main(string[] args)
        {
            /*aircraftManager.create("DANA", "JETBOOING", "NG555", 4000);
            //aircraftManager.remove("DANA");
            aircraftManager.displayAll();*/
            bool flag = true;
            while (flag)
            {
                showMainMenu();
                string option = Console.ReadLine();
                if (option.Equals("0"))
                {
                    flag = false;
                }
                else
                {
                    showSubMenu(option);
                }

            }

        }

        public static void showMainMenu()
        {
            Console.WriteLine("Enter 0 to exit");
            Console.WriteLine("Enter 1 to manage Aircrafts");
            Console.WriteLine("Enter 2 to manage Flights");
            Console.WriteLine("Enter 3 to manage Bookings");
            Console.WriteLine("Enter 4 to manage Passengers");
        }

        public static void showSubMenu(string option)
        {
            if (option.Equals("1"))
            {
                showManageAircraftsMenu();
                string subOption = Console.ReadLine();
                handleManageAirCraftsAction(subOption);
            }
            else if (option.Equals("2"))
            {
                showManageFlightsMenu();
                string subOption = Console.ReadLine();
                handleManageFlightsAction(subOption);
            }
            else if (option.Equals("3"))
            {
                showManageBookingsMenu();
                string subOption = Console.ReadLine();
                handleManageBookingsAction(subOption);
            }
            else if (option.Equals("4"))
            {
                showManagePassengersMenu();
                string subOption = Console.ReadLine();
                handleManagePassengersAction(subOption);
            }
            else
            {
                showSubMenu(option);
            }

        }

        public static void showManageAircraftsMenu()
        {
            Console.WriteLine("Enter 0 to return to Main menu");
            Console.WriteLine("Enter 1 to list Aircrafts");
            Console.WriteLine("Enter 2 to create Aircrafts");
            Console.WriteLine("Enter 3 to update Aircrafts");
            Console.WriteLine("Enter 4 to remove Aircrafts");
            Console.WriteLine("Enter 5 to find Aircrafts");
        }

        public static void handleManageAirCraftsAction(string action)
        {
            if (action.Equals("0"))
            {
                //showMainMenu();
                return;
            }
            else if (action.Equals("1"))
            {
                aircraftManager.displayAll();
            }
            else if (action.Equals("2"))
            {
                Console.WriteLine("Enter the Aircraft registration Number");
                string registrationNumber = Console.ReadLine();
                Console.WriteLine("Enter the Aircraft name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the Aircraft type");
                string type = Console.ReadLine();
                Console.WriteLine("Enter the Aircraft capacity");
                int capacity = int.Parse(Console.ReadLine());
                Console.ReadLine();
                aircraftManager.create(name, type, registrationNumber, capacity);
            }
            else if (action.Equals("3"))
            {
                Console.WriteLine("Enter the Aircraft registration Number");
                string registrationNumber = Console.ReadLine();
                var aircraft = aircraftManager.find(registrationNumber);
                if (aircraft == null)
                {
                    Console.WriteLine($"There is no aircraft with the registration Number {registrationNumber}");
                }
                else
                {
                    Console.WriteLine("Enter the Aircraft name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the Aircraft type");
                    string type = Console.ReadLine();
                    Console.WriteLine("Enter the Aircraft capacity");
                    int capacity = int.Parse(Console.ReadLine());
                    Console.ReadLine();
                    aircraftManager.update(name, type, registrationNumber, capacity);
                }

            }
            else if (action.Equals("4"))
            {
                Console.WriteLine("Enter the Aircraft registration Number");
                string registrationNumber = Console.ReadLine();
                var aircraft = aircraftManager.find(registrationNumber);
                if (aircraft == null)
                {
                    Console.WriteLine($"There is no aircraft with the registration Number {registrationNumber}");
                }
                else
                {
                    aircraftManager.remove(registrationNumber);
                }

            }
            else if (action.Equals("5"))
            {
                Console.WriteLine("Enter the Aircraft registration Number");
                string registrationNumber = Console.ReadLine();
                var aircraft = aircraftManager.find(registrationNumber);
                if (aircraft == null)
                {
                    Console.WriteLine($"There is no aircraft with the registration Number {registrationNumber}");
                }
                else
                {
                    aircraftManager.find(registrationNumber);
                }
            }
            else
            {
                Console.WriteLine("Invalid Entry");
            }
        }

        public static void showManageFlightsMenu()
        {
            Console.WriteLine("Enter 0 to return to Main menu");
            Console.WriteLine("Enter 1 to list Flights");
            Console.WriteLine("Enter 2 to create Flights");
            Console.WriteLine("Enter 3 to update Flights");
            Console.WriteLine("Enter 4 to remove Flights");
            Console.WriteLine("Enter 5 to find Flights");
        }

        public static void handleManageFlightsAction(string action)
        {
            if (action.Equals("0"))
            {
                showMainMenu();
            }
            else if (action.Equals("1"))
            {
                flightManager.displayAll();
            }
            else if (action.Equals("2"))
            {
                Console.WriteLine("Enter the Flight Number");
                int flightNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Aircraft regNumber");
                string registrationNumber = Console.ReadLine();
                Console.WriteLine("Enter the takeOfairport");
                string takeOfPoint = Console.ReadLine();
                Console.WriteLine("Enter the takeOfTime");
                DateTime takeOfTime = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Landing Time");
                DateTime landingTime = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Destination");
                string destination = Console.ReadLine();
                Console.WriteLine("Enter the Ticket price");
                decimal ticketPrice = decimal.Parse(Console.ReadLine());
                Console.ReadLine();
                flightManager.create(registrationNumber, flightNumber, takeOfPoint, takeOfTime, landingTime, destination, ticketPrice);
            }
            else if (action.Equals("3"))
            {
                Console.WriteLine("Enter the Aircraft Flight Number");
                int flightNumber = int.Parse(Console.ReadLine());
                var flight = flightManager.find(flightNumber);
                if (flight == null)
                {
                    Console.WriteLine($"There is no flight with the flight Number {flightNumber}");
                }
                else
                {
                    Console.WriteLine("Enter the Aircraft");
                    string registrationNumber = Console.ReadLine();
                    Console.WriteLine("Enter the takeOfairport");
                    string takeOfPoint = Console.ReadLine();
                    Console.WriteLine("Enter the takeOfTime");
                    DateTime takeOfTime = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the Landing Time");
                    DateTime landingTime = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the Destination");
                    string destination = Console.ReadLine();
                    Console.WriteLine("Enter the Ticket price");
                    decimal ticketPrice = decimal.Parse(Console.ReadLine());
                    Console.ReadLine();
                    flightManager.update(registrationNumber, flightNumber, takeOfPoint, takeOfTime, landingTime, destination, ticketPrice);
                }

            }
            else if (action.Equals("4"))
            {
                Console.WriteLine("Enter the Aircraft Flight Number");
                int flightNumber = int.Parse(Console.ReadLine());
                var flight = flightManager.find(flightNumber);
                if (flight == null)
                {
                    Console.WriteLine($"There is no flight with the flight Number {flightNumber}");
                }
                else
                {
                    flightManager.remove(flightNumber);
                }
            }
            else if (action.Equals("5"))
            {
                Console.WriteLine("Enter the Aircraft Flight Number");
                int flightNumber = int.Parse(Console.ReadLine());
                var flight = flightManager.find(flightNumber);
                if (flight == null)
                {
                    Console.WriteLine($"There is no flight with the flight Number {flightNumber}");
                }
                else
                {
                    flightManager.find(flightNumber);
                }
            }
        }

        public static void showManageBookingsMenu()
        {
            Console.WriteLine("Enter 0 to return to Main menu");
            Console.WriteLine("Enter 1 to list Bookings");
            Console.WriteLine("Enter 2 to create Bookings");
            Console.WriteLine("Enter 3 to update Bookings");
            Console.WriteLine("Enter 4 to remove Bookings");
            Console.WriteLine("Enter 5 to find Bookings");
        }

        public static void handleManageBookingsAction(string action)
        {
            if (action.Equals("0"))
            {
                showMainMenu();
            }
            else if (action.Equals("1"))
            {
                bookingManager.displayAll();
            }
            else if (action.Equals("2"))
            {
                Console.WriteLine("Enter the Booking Number");
                int bookingNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Flight Number");
                int flightNumber = int.Parse(Console.ReadLine());
                //Console.WriteLine("Enter the Passenger Name");
                //string bookingPassenger = Console.ReadLine();
                Console.WriteLine("Enter the Booking Date");
                DateTime bookingDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Booking Type");
                string bookingType = Console.ReadLine();
                Console.WriteLine("Enter the Seat Number");
                int seatNumber = int.Parse(Console.ReadLine());
                Console.ReadLine();
                bookingManager.create(bookingNumber, flightNumber, bookingDate, bookingType, seatNumber);
            }
            else if (action.Equals("3"))
            {
                Console.WriteLine("Enter the Booking Number");
                int bookingNumber = int.Parse(Console.ReadLine());
                var booking = bookingManager.find(bookingNumber);
                if (booking == null)
                {
                    Console.WriteLine($"There is no booking with the booking Number {bookingNumber}");
                }
                else
                {
                    Console.WriteLine("Enter the Flight Number");
                    int flightNumber = int.Parse(Console.ReadLine());
                    //Console.WriteLine("Enter the Passenger Name");
                    //string bookingPassenger = Console.ReadLine();
                    Console.WriteLine("Enter the Booking Date");
                    DateTime bookingDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the Booking Type");
                    string bookingType = Console.ReadLine();
                    Console.WriteLine("Enter the Seat Number");
                    int seatNumber = int.Parse(Console.ReadLine());
                    Console.ReadLine();
                    bookingManager.update(bookingNumber, flightNumber, bookingDate, bookingType, seatNumber);
                }
            }
            else if (action.Equals("4"))
            {
                Console.WriteLine("Enter the Booking Number");
                int bookingNumber = int.Parse(Console.ReadLine());
                var booking = bookingManager.find(bookingNumber);
                if (booking == null)
                {
                    Console.WriteLine($"There is no booking with the booking Number {bookingNumber}");
                }
                else
                {
                    bookingManager.remove(bookingNumber);
                }
            }
            else if (action.Equals("5"))
            {
                Console.WriteLine("Enter the Booking Number");
                int bookingNumber = int.Parse(Console.ReadLine());
                var booking = bookingManager.find(bookingNumber);
                if (booking == null)
                {
                    Console.WriteLine($"There is no booking with the booking Number {bookingNumber}");
                }
                else
                {
                    bookingManager.find(bookingNumber);
                }
            }
        }

        public static void showManagePassengersMenu()
        {
            Console.WriteLine("Enter 0 to return to Main menu");
            Console.WriteLine("Enter 1 to list Passengers");
            Console.WriteLine("Enter 2 to create Passengers");
            Console.WriteLine("Enter 3 to update Passengers");
            Console.WriteLine("Enter 4 to remove Passengers");
            Console.WriteLine("Enter 5 to find Passengers");
        }
        public static void handleManagePassengersAction(string action)
        {
            if (action.Equals("0"))
            {
                showMainMenu();
            }
            else if (action.Equals("1"))
            {
                passengerManager.displayAll();
            }
            else if (action.Equals("2"))
            {
                Console.WriteLine("Enter the Name of the Passenger");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the Booking Number");
                int bookingNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Passenger Address");
                string address = Console.ReadLine();
                Console.WriteLine("Enter the Phone Number");
                Double phoneNumber = Double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Email");
                string email = Console.ReadLine();
                Console.WriteLine("Enter the Gender");
                string gender = Console.ReadLine();
                Console.WriteLine("Enter the date of birth");
                DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
                Console.ReadLine();
                passengerManager.create(name, bookingNumber, address, phoneNumber, email, gender, dateOfBirth);
            }
            else if (action.Equals("3"))
            {
                Console.WriteLine("Enter the Passenger Name");
                string name = Console.ReadLine();
                var passenger = passengerManager.find(name);
                if (passenger == null)
                {
                    Console.WriteLine($"There is no passenger with the name {name}");
                }
                else
                {
                    Console.WriteLine("Enter the Booking Number");
                    int bookingNumber = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the Passenger Address");
                    string address = Console.ReadLine();
                    Console.WriteLine("Enter the Phone Number");
                    Double phoneNumber = Double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the Email");
                    string email = Console.ReadLine();
                    Console.WriteLine("Enter the Gender");
                    string gender = Console.ReadLine();
                    Console.WriteLine("Enter the date of birth");
                    DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
                    Console.ReadLine();
                    passengerManager.update(name, bookingNumber, address, phoneNumber, email, gender, dateOfBirth);
                }
            }
            else if (action.Equals("4"))
            {
                Console.WriteLine("Enter the Passenger Name");
                string name = Console.ReadLine();
                var passenger = passengerManager.find(name);
                if (passenger == null)
                {
                    Console.WriteLine($"There is no passenger with the name {name}");
                }
                else
                {
                    passengerManager.remove(name);
                }
            }
            else if (action.Equals("5"))
            {
                Console.WriteLine("Enter the Passenger Name");
                string name = Console.ReadLine();
                var passenger = passengerManager.find(name);
                if (passenger == null)
                {
                    Console.WriteLine($"There is no passenger with the name {name}");
                }
                else
                {
                    passengerManager.find(name);
                }
            }
        }
    }
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
