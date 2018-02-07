using System;
using System.Collections.Generic;
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
            var doctor = new Doctors
            {
                Name = "Dr. Irvin",
                PhoneNumber = "5122889244",
                Primary = true
            };

            var user = new UserInfo
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

            // Save the infor to the database
            user.Login = new Logins {Name = "Barakis"};
            user.Doctors.Add(doctor);
            // Section is for the password hashing and storage
            byte[] hash;
            byte[] salt;
            PasswordService.SaltedHash("Matthew", out hash, out salt);
            user.Login.Hash = hash;
            user.Login.SaltValue = salt;

            var connectionString = "server=lokislayer.com;database=rxstore;uid=BARAKIS;password=BarakisMJB48;";

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
