using System;
using System.Collections.Generic;
using System.Text;

namespace Airlinemanagement
{
    public class AirlineManagementSystem
    {
        static Aircraftmanager aircraftmanager = new Aircraftmanager();
        static Flightmanager flightmanager = new Flightmanager();
        static Bookingmanager bookingmanager = new Bookingmanager();
        static Passengermanager passengermanager = new Passengermanager();
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
            Console.WriteLine("Enter 3 to remove Aircrafts");
            Console.WriteLine("Enter 4 to find Aircrafts");
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
                aircraftmanager.create(capacity, registrationNumber, type, name);
            }
            else if(action.Equals("3"))
            {
                Console.WriteLine("Enter the Aircraft registration Number");
                string registrationNumber = Console.ReadLine();
                aircraftmanager.remove(registrationNumber);
            }
            else if(action.Equals("4"))
            {
                Console.WriteLine("Enter the Aircraft registration Number");
                string registrationNumber = Console.ReadLine();
                aircraftmanager.findAircraft(registrationNumber);
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
                string aircraft = Console.ReadLine();
                Console.WriteLine("Enter the takeOfairport");
                string takeOfairport = Console.ReadLine();
                Console.WriteLine("Enter the takeOfTime");
                DateTime takeOfTime = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Landing Time");
                DateTime landingTime = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Destination");
                string destination = Console.ReadLine();
                Console.WriteLine("Enter the Ticket price");
                decimal ticketPrice = decimal.Parse(Console.ReadLine());
                Console.ReadLine();
                flightmanager.create(flightNumber, aircraft, takeOfairport, takeOfTime, landingTime, destination, ticketPrice);
            }
        }

        public static void showManageBookingsMenu()
        {
            Console.WriteLine("Enter 0 to return to Main menu");
            Console.WriteLine("Enter 1 to list Bookings");
            Console.WriteLine("Enter 2 to create Bookings");
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
                int flight = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Passenger Name");
                string bookingPassenger = Console.ReadLine();
                Console.WriteLine("Enter the Booking Date");
                DateTime bookingDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Booking Type");
                string bookingType = Console.ReadLine();
                Console.WriteLine("Enter the Seat Number");
                int seatNumber = int.Parse(Console.ReadLine());
                Console.ReadLine();
                bookingmanager.create(bookingNumber, flight, bookingPassenger, bookingDate, bookingType, seatNumber);
            }
        }

        public static void showManagePassengersMenu()
        {
            Console.WriteLine("Enter 0 to return to Main menu");
            Console.WriteLine("Enter 1 to list Passengers");
            Console.WriteLine("Enter 2 to create Passengers");
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
                Console.WriteLine("Enter the Passenger Name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the Booking Number");
                int booking = int.Parse(Console.ReadLine());
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
                passengermanager.create(booking, name, address, phoneNumber, email, gender, dateOfBirth);
            }
        }
    }
}
