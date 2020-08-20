using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
//using System.Linq;
//using System.Threading.Tasks;

namespace Airlinemanagement
{
    public class AirlineManagementSystem
    {
        static Aircraftmanager aircraftmanager = new Aircraftmanager();
        static Flightmanager flightmanager = new Flightmanager(aircraftmanager);
        static Bookingmanager bookingmanager = new Bookingmanager(flightmanager);
        static Passengermanager passengermanager = new Passengermanager(bookingmanager);
        public static void main()
        {
            Boolean flag = true;
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
                aircraftmanager.list();
            }
            else if (action.Equals("2"))
            //try
            //{
            {
                //Aircraftmanager aircraftmanager = new Aircraftmanager();
                Console.WriteLine("Enter the Aircraft registration Number");
                string registrationNumber = Console.ReadLine();
                Console.WriteLine("Enter the Aircraft name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the Aircraft type");
                string type = Console.ReadLine();
                Console.WriteLine("Enter the Aircraft capacity");
                int capacity = int.Parse(Console.ReadLine());
                Console.ReadLine();
                aircraftmanager.create(name, type, capacity, registrationNumber);
            }
            //}
            // catch (Exception e)
            //   {
            //Console.WriteLine(e.Message);
            // }
            else if (action.Equals("3"))
            {
                // Aircraftmanager aircraftmanager = new Aircraftmanager();
                Console.WriteLine("Enter the Aircraft registration Number");
                string registrationNumber = Console.ReadLine();
                var aircraft = aircraftmanager.find(registrationNumber);
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
                    aircraftmanager.update(name, type, capacity, registrationNumber);
                }

            }
            else if (action.Equals("4"))
            {
                // Aircraftmanager aircraftmanager = new Aircraftmanager();
                Console.WriteLine("Enter the Aircraft registration Number");
                string registrationNumber = Console.ReadLine();
                var aircraft = aircraftmanager.find(registrationNumber);
                if (aircraft == null)
                {
                    Console.WriteLine($"There is no aircraft with the registration Number {registrationNumber}");
                }
                else
                {
                    aircraftmanager.remove(registrationNumber);
                }

            }
            else if (action.Equals("5"))
            {
                // Aircraftmanager aircraftmanager = new Aircraftmanager();
                Console.WriteLine("Enter the Aircraft registration Number");
                string registrationNumber = Console.ReadLine();
                var aircraft = aircraftmanager.find(registrationNumber);
                if (aircraft == null)
                {
                    Console.WriteLine($"There is no aircraft with the registration Number {registrationNumber}");
                }
                else
                {
                    aircraftmanager.show(aircraft);
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
                flightmanager.list();
            }
            else if (action.Equals("2"))
            {
                Console.WriteLine("Enter the Aircraft Flight Number");
                int flightNumber = int.Parse(Console.ReadLine());
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
                flightmanager.create(registrationNumber, flightNumber, takeOfPoint, destination, takeOfTime, landingTime, ticketPrice);
            }
            else if (action.Equals("3"))
            {
                Console.WriteLine("Enter the Aircraft Flight Number");
                int flightNumber = int.Parse(Console.ReadLine());
                var flight = flightmanager.find(flightNumber);
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
                    flightmanager.update(registrationNumber, flightNumber, takeOfPoint, destination, takeOfTime, landingTime, ticketPrice);
                }

            }
            else if (action.Equals("4"))
            {
                Console.WriteLine("Enter the Aircraft Flight Number");
                int flightNumber = int.Parse(Console.ReadLine());
                var flight = flightmanager.find(flightNumber);
                if (flight == null)
                {
                    Console.WriteLine($"There is no flight with the flight Number {flightNumber}");
                }
                else
                {
                    flightmanager.remove(flightNumber);
                }
            }
            else if (action.Equals("5"))
            {
                Console.WriteLine("Enter the Aircraft Flight Number");
                int flightNumber = int.Parse(Console.ReadLine());
                var flight = flightmanager.find(flightNumber);
                if (flight == null)
                {
                    Console.WriteLine($"There is no flight with the flight Number {flightNumber}");
                }
                else
                {
                    flightmanager.show(flight);
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
                bookingmanager.list();
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
                bookingmanager.create(bookingNumber, flightNumber, bookingDate, bookingType, seatNumber);
            }
            else if (action.Equals("3"))
            {
                Console.WriteLine("Enter the Booking Number");
                int bookingNumber = int.Parse(Console.ReadLine());
                var booking = bookingmanager.find(bookingNumber);
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
                    bookingmanager.update(bookingNumber, flightNumber, bookingDate, bookingType, seatNumber);
                }
            }
            else if (action.Equals("4"))
            {
                Console.WriteLine("Enter the Booking Number");
                int bookingNumber = int.Parse(Console.ReadLine());
                var booking = bookingmanager.find(bookingNumber);
                if (booking == null)
                {
                    Console.WriteLine($"There is no booking with the booking Number {bookingNumber}");
                }
                else
                {
                    bookingmanager.remove(bookingNumber);
                }
            }
            else if (action.Equals("5"))
            {
                Console.WriteLine("Enter the Booking Number");
                int bookingNumber = int.Parse(Console.ReadLine());
                var booking = bookingmanager.find(bookingNumber);
                if (booking == null)
                {
                    Console.WriteLine($"There is no booking with the booking Number {bookingNumber}");
                }
                else
                {
                    bookingmanager.show(booking);
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
                passengermanager.list();
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
                passengermanager.create(name, bookingNumber, address, phoneNumber, email, gender, dateOfBirth);
            }
            else if (action.Equals("3"))
            {
                Console.WriteLine("Enter the Passenger Name");
                string name = Console.ReadLine();
                var passenger = passengermanager.find(name);
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
                    passengermanager.update(name, bookingNumber, address, phoneNumber, email, gender, dateOfBirth);
                }
            }
            else if (action.Equals("4"))
            {
                Console.WriteLine("Enter the Passenger Name");
                string name = Console.ReadLine();
                var passenger = passengermanager.find(name);
                if (passenger == null)
                {
                    Console.WriteLine($"There is no passenger with the name {name}");
                }
                else
                {
                    passengermanager.remove(name);
                }
            }
            else if (action.Equals("5"))
            {
                Console.WriteLine("Enter the Passenger Name");
                string name = Console.ReadLine();
                var passenger = passengermanager.find(name);
                if (passenger == null)
                {
                    Console.WriteLine($"There is no passenger with the name {name}");
                }
                else
                {
                    passengermanager.show(passenger);
                }
            }
        }
    }
}
