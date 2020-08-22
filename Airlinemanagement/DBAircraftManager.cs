using System;
using System.IO;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Airlinemanagement
{
    public class DBAircraftManager : IAircraftManager
    {
        MySqlConnection connection;
        public DBAircraftManager(MySqlConnection connection)
        {
            this.connection = connection;
        }
        public List<Aircraft> getAll()
        {
            List<Aircraft> aircrafts = new List<Aircraft>();
            try
            {

                connection.Open();
                string sql = "SELECT id,registrationNumber,name, type,capacity from aircrafts";

                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    {

                        int id = reader.GetInt32(0);
                        string registrationNumber = reader.GetString(1);
                        string name = reader.GetString(2);
                        string type = reader.GetString(3);
                        int capacity = reader.GetInt32(4);
                        Aircraft aircraft = new Aircraft(id, name, type, registrationNumber, capacity);
                        aircrafts.Add(aircraft);

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
            return aircrafts;
        }
       /* public List<Aircraft> aircrafts;
       // private TextWriter writer;
        public DBAircraftManager()
        {
            aircrafts = new List<Aircraft>();
           
            try
            {
                var lines = File.ReadAllLines("aircraft.txt");
                foreach (var line in lines)
                {
                    var aircraft = Aircraft.Parse(line);
                    aircrafts.Add(aircraft);
                }
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void show(Aircraft a)
        {
            Console.WriteLine($"{a.name} {a.type} {a.capacity} {a.registrationNumber}"); // using member access operator(.) to reference its accessible members
        }

        public void list()
        {
            foreach (Aircraft a in aircrafts)
            {
                show(a);
            }
        }*/
        public bool create(string name, string type, string registrationNumber, int capacity)
        {
            try
            {
                connection.Open();
                string sql = "insert into aircrafts (registrationNumber,name,type,capacity)values ('" + registrationNumber + "','" + name + "','" + type + "','" + capacity + "')";
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
       /* {
            Aircraft a = new Aircraft(name, type, capacity, registrationNumber); //Creating and instance of of the class (Aircraft) to call the method CREATE
            aircrafts.Add(a);
           TextWriter writer= new StreamWriter("aircraft.txt", true);
            writer.WriteLine(a.ToString());
            writer.Close();
        }*/

        public bool update(string name, string type, string registrationNumber, int capacity)
        {
            try
            {
                connection.Open();
                var sql = "update aircrafts set name ='" + name + "',type='" + type + "',capacity='" + capacity + "' where registrationNumber='" + registrationNumber + "'";
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
        /*{
            var a = aircrafts.Find(p => p.registrationNumber == registrationNumber);
            a.capacity = capacity;
            a.type = type;
            a.name = name;
            RefreshFile();
        }

        private void RefreshFile()
        {
            TextWriter writer = new StreamWriter("aircraft.txt");
            foreach (var aircraft in aircrafts)
            {
                writer.WriteLine(aircraft);
            }
            writer.Flush();
            writer.Close();
        }*/

        public bool remove(string registrationNumber)
        {

            try
            {
                connection.Open();
                var sql = "delete from aircrafts where registrationNumber='" + registrationNumber + "'";
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
        /*{
            var a = aircrafts.Find(p => p.registrationNumber == registrationNumber);
            aircrafts.Remove(a);
            RefreshFile();*/
        
        public Aircraft find(string registrationNumber)
        {
            Aircraft aircraft = null;
            try
            {
                connection.Open();
                var sql = "select id, registrationNumber, name, type, capacity from aircrafts where registrationNumber = '" + registrationNumber + "'";
                MySqlCommand command = new MySqlCommand(sql, connection);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    int id = reader.GetInt32(0);
                    string name = reader.GetString(2);
                    string type = reader.GetString(3);
                    int capacity = reader.GetInt32(4);
                    aircraft = new Aircraft(id, name, type, registrationNumber, capacity);

                }
                  Console.WriteLine(reader[0] + " -- " + reader[1]);

                //Console.WriteLine($"{aircraft.getId()}, {aircraft.getRegistrationNumber()}, {aircraft.getName()}, {aircraft.getType()}, {aircraft.getCapacity()}");
                //reader.Close();
                //connection.Close();
            }

            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return aircraft;

        }
        /*{
            return aircrafts.Find(p => p.registrationNumber == registrationNumber);
        }*/
        public void displayAll()
        {
            List<Aircraft> aircrafts = getAll();
            foreach (Aircraft aircraft in aircrafts)
            {
                Console.WriteLine($"{aircraft.getId()}, {aircraft.getRegistrationNumber()}, {aircraft.getName()}, {aircraft.getType()}, {aircraft.getCapacity()}");
            }
        }




    }
}
