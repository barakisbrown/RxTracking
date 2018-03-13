using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Models;
using DAL.Services;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace DBDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            var doctor = new Doctor
            {
                Name = "Dr. Irvin",
                PhoneNumber = "5122889244",
                Primary = true
            };

            var script = new Script
            {
                Number = "410448",
                Name = "Lisinopril",
                DoseType = "TAB",
                DoseAmount = "40MG",
                Ndc = "68180-0517-01",
                Qty = 30.0,
                Supply = 30.0,
                FillDate = new DateTime(2013,1,28),
                RefillsLeft = 4.0
            };

            var user = new User
            {
                FirstName = "Matthew",
                LastName = "Brown",
                Address = "700 Louis Henna Blvd Apt #531",
                City = "Round Rock",
                State = "TX",
                ZipCode = "78664",
                PhoneNumber = "5128289081",
                Email = "matthew@lokislayer.com"
            };

            var login = new Login {Name = "Barakis", FirstLogged = DateTime.Now, LastLogged = DateTime.Now};
            // Section is for the password hashing and storage
            byte[] hash;
            byte[] salt;
            PasswordService.SaltedHash("Matthew", out hash, out salt);
            login.Hash = hash;
            login.Salt = salt;
            login.User = user;

            // user
            user.Scripts = new Collection<Script>();
            user.Doctors = new Collection<Doctor>();
            // doctor
            doctor.Scripts = new Collection<Script>();
            doctor.Users = new Collection<User>();
            // scripts
            script.Users = user;
            script.Doctors = doctor;
            // lets add them to the proper collections
            user.Scripts.Add(script);
            user.Doctors.Add(doctor);
            doctor.Scripts.Add(script);
            doctor.Users.Add(user);

            



            var connectionString = "server=lokislayer.com;database=rxstore;uid=BARAKIS;password=BarakisMJB48;persistsecurityinfo=True;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (var db = new DbContext(connection, false))
                {
                    db.Database.CreateIfNotExists();
                }

                connection.Open();
                MySqlTransaction trans = connection.BeginTransaction();
                try
                {
                    using (var db = new DbContext(connection, false))
                    {
                        db.Database.UseTransaction(trans);
                        db.Users.Add(user);
                        db.SaveChanges();

                    }
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }

            Console.ReadKey();
        }      
    }
}
