using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Airlinemanagement
{
    public class DBFlightManager : IFlightManager
        
    {
        MySqlConnection connection;
        IAircraftManager aircraftManager;
        public DBFlightManager(MySqlConnection connection)
        {
            this.connection = connection;
            aircraftManager = new DBAircraftManager(connection);
        }
        public List<Flight> getAll()
        {
            List<Flight> flights = new List<Flight>();
            try
            {

                connection.Open();
                string sql = "SELECT id,registrationNumber,flightNumber, takeOfPoint,takeOfTime,landingTime,destination,flightPrice from flights";

                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    {

                        int id = reader.GetInt32(0);
                        string registrationNumber = reader.GetString(1);
                        int flightNumber = reader.GetInt32(2);
                        string takeOfPoint = reader.GetString(3);
                        DateTime takeOfTime = reader.GetDateTime(4);
                        DateTime landingTime = reader.GetDateTime(5);
                        string destination = reader.GetString(6);
                        decimal flightPrice = reader.GetDecimal(7);
                        Flight flight = new Flight(id, registrationNumber, flightNumber, takeOfPoint, takeOfTime, landingTime, destination, flightPrice);
                        flights.Add(flight);

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
            return flights;
        }
        
        public bool create(string registrationNumber, int flightNumber, string takeOfPoint, DateTime takeOfTime, DateTime landingTime, string destination, decimal flightPrice)
        {
            Aircraft aircraft = aircraftManager.find(registrationNumber);
            if (aircraft == null)
            {
                Console.WriteLine($"Aircraft with {registrationNumber} could not be found");
                return false;
            }
            try
            {
                connection.Open();
                string sql = "insert into flights (registrationNumber,flightNumber, takeOfPoint,takeOfTime,landingTime,destination,flightPrice)values ('" + registrationNumber + "','" + flightNumber + "','" + takeOfPoint + "','" + takeOfTime.ToString("yyyy-MM-dd HH:mm:ss") + "', +'" + landingTime.ToString("yyyy-MM-dd HH:mm:ss") + "', + '" + destination + "', + '" + flightPrice + "')";
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

        public bool update(string registrationNumber, int flightNumber, string takeOfPoint, DateTime takeOfTime, DateTime landingTime, string destination, decimal flightPrice)
        {
            Aircraft aircraft = aircraftManager.find(registrationNumber);
            if (aircraft == null)
            {
                Console.WriteLine($"Aircraft with {registrationNumber} could not be found");
                return false;
            }
            try
            {
                connection.Open();
                var sql = "update flights set registrationNumber ='" + registrationNumber + "',takeOfPoint='" + takeOfPoint + "', takeOfTime='" + takeOfTime.ToString("yyyy-MM-dd HH:mm:ss") + "', landingTime='" + landingTime.ToString("yyyy-MM-dd HH:mm:ss") + "', destination='" + destination + "', flightPrice='" + flightPrice + "' where flightNumber = '" + flightNumber + "'";
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

        public bool remove(int flightNumber)
        {

            try
            {
                connection.Open();
                var sql = "delete from flights where flightNumber='" + flightNumber + "'";
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

        public Flight find(int flightNumber)
        {
            Flight flight = null;
            try
            {
                connection.Open();
                var sql = "select id, registrationNumber, flightNumber, takeOfPoint,takeOfTime,landingTime,destination,flightPrice from flights where flightNumber = '" + flightNumber + "'";
                MySqlCommand command = new MySqlCommand(sql, connection);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string registrationNumber = reader.GetString(2);
                    string takeOfPoint = reader.GetString(3);
                    DateTime takeOfTime = reader.GetDateTime(4);
                    DateTime landingTime = reader.GetDateTime(5);
                    string destination = reader.GetString(6);
                    decimal flightPrice = reader.GetDecimal(7);
                    flight = new Flight(id, registrationNumber, flightNumber, takeOfPoint, takeOfTime, landingTime, destination, flightPrice);
                }

                Console.WriteLine(reader[0] + " -- " + reader[1]);
                //Console.WriteLine($"{flight.getId()}, {flight.getRegistrationNumber()}, {flight.getFlightNumber()}, {flight.getTakeOfPoint()}, {flight.getTakeOfTime()}, {flight.getLandingTime()}, {flight.getDestination()}, {flight.getFlightPrice()}");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return flight;
        }
        
        public void displayAll()
        {
            List<Flight> flights = getAll();
            foreach (Flight flight in flights)
            {
                Console.WriteLine($"{flight.getId()}, {flight.getRegistrationNumber()}, {flight.getFlightNumber()}, {flight.getTakeOfPoint()}, {flight.getTakeOfTime()}, {flight.getLandingTime()}, {flight.getDestination()}, {flight.getFlightPrice()}");
            }
        }
    }
}
