using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace Airlinemanagement
{
    class DBPassengerManager : IPassengerManager
    {
        MySqlConnection connection;
        IBookingManager bookingManager;
        public DBPassengerManager(MySqlConnection connection)
        {
            this.connection = connection;
            bookingManager = new DBBookingManager(connection);
        }
        public List<Passenger> getAll()
        {
            List<Passenger> passengers = new List<Passenger>();
            try
            {

                connection.Open();
                string sql = "SELECT id,name,bookingNumber,address,phoneNumber,email, gender, dateOfBirth from passengers";

                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    {

                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int bookingNumber = reader.GetInt32(2);
                        string address = reader.GetString(3);
                        double phoneNumber = reader.GetDouble(4);
                        string email = reader.GetString(5);
                        string gender = reader.GetString(6);
                        DateTime dateOfBirth = reader.GetDateTime(7);
                        Passenger passenger = new Passenger(id, name, bookingNumber, address, phoneNumber, email, gender, dateOfBirth);
                        passengers.Add(passenger);

                    }
                    Console.WriteLine(reader[0] + " -- " + reader[1]);
                }
                reader.Close();

                connection.Close();
                Console.WriteLine("Done.");

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return passengers;
        }

        public bool create(string name, int bookingNumber, string address, double phoneNumber, string email, string gender, DateTime dateOfBirth)
        {
            Booking booking = bookingManager.find(bookingNumber);
            if (booking == null)
            {
                Console.WriteLine($"Booking with {bookingNumber} could not be found");
                return false;
            }
            try
            {
                connection.Open();
                string sql = "insert into passengers (name,bookingNumber,address,phoneNumber,email, gender, dateOfBirth)values ('" + name + "','" + bookingNumber + "','" + address + "','" + phoneNumber + "','" + email + "', +'" + gender + "','" + dateOfBirth.ToString("yyyy-MM-dd") + "')";
                MySqlCommand command = new MySqlCommand(sql, connection);
                int count = command.ExecuteNonQuery();
                if (count > 0)
                {
                    connection.Close();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return false;
        }

        public bool update(string name, int bookingNumber, string address, double phoneNumber, string email, string gender, DateTime dateOfBirth)
        {
            Booking booking = bookingManager.find(bookingNumber);
            if (booking == null)
            {
                Console.WriteLine($"Booking with {bookingNumber} could not be found");
                return false;
            }
            try
            {
                connection.Open();
                var sql = "update passengers set bookingNumber ='" + bookingNumber + "',address='" + address + "', phoneNumber='" + phoneNumber + "', email='" + email + "', gender='" + gender + "', dateOfBirth='" + dateOfBirth.ToString("yyyy-MM-dd") + "' where name='" + name + "'";
                MySqlCommand command = new MySqlCommand(sql, connection);
                int count = command.ExecuteNonQuery();
                if (count > 0)
                {
                    connection.Close();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return false;
        }

        public bool remove(string name)
        {

            try
            {
                connection.Open();
                var sql = "delete from passengers where name='" + name + "'";
                MySqlCommand command = new MySqlCommand(sql, connection);

                int count = command.ExecuteNonQuery();
                if (count > 0)
                {
                    connection.Close();
                    return true;
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return false;
        }

        public Passenger find(string name)
        {
            Passenger passenger = null;
            try
            {
                connection.Open();
                var sql = "select id, name,bookingNumber,address,phoneNumber,email, gender, dateOfBirth from passengers where name = '" + name + "'";
                MySqlCommand command = new MySqlCommand(sql, connection);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    int bookingNumber = reader.GetInt32(2);
                    string address = reader.GetString(3);
                    double phoneNumber = reader.GetDouble(4);
                    string email = reader.GetString(5);
                    string gender = reader.GetString(6);
                    DateTime dateOfBirth = reader.GetDateTime(7);
                    passenger = new Passenger(id, name, bookingNumber, address, phoneNumber, email, gender, dateOfBirth);
                }
                Console.WriteLine(reader[0] + " -- " + reader[1]);
                //Console.WriteLine($"{passenger.getId()}, {passenger.getName()}, {passenger.getBookingNumber()}, {passenger.getAddress()}, {passenger.getPhoneNumber()}, {passenger.getEmail()},  {passenger.getGender()}, {passenger.getDateOfBirth()}");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return passenger;
        }

        public void displayAll()
        {
            List<Passenger> passengers = getAll();
            foreach (Passenger passenger in passengers)
            {
                Console.WriteLine($"{passenger.getId()}, {passenger.getName()}, {passenger.getBookingNumber()}, {passenger.getAddress()}, {passenger.getPhoneNumber()}, {passenger.getEmail()},  {passenger.getGender()}, {passenger.getDateOfBirth()}");
            }
        }
    }
}
