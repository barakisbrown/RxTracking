using DAL.Context;
using DAL.Models;
using DAL.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace DBDriver
{
    
    public class Program
    {
        private static string connectionString = "server=lokislayer.com;database=rxstore;uid=BARAKIS;password=BarakisMJB48;persistsecurityinfo=True;";

        static void Main(string[] args)
        {
            // InitializeDB();

            if (CheckPassword())
            {
                Console.WriteLine("Password test passed");
                Console.ReadKey();
            }
            else
            {
               Console.WriteLine("Password test failed");
               Console.ReadKey();
            }

           
        }

        private static bool CheckPassword()
        {
            using (var con = new MySqlConnection(connectionString))
            {
                using (var db = new DbContext(con, false))
                {
                    var userName = "Barakis";
                    var password = "Matthew";

                    var L = db.Login.FirstOrDefault(l => l.Name == userName);

                    string salt = Convert.ToBase64String(L.Salt);
                    string hash = Convert.ToBase64String(L.Hash);

                    return PasswordService.Verify(salt, hash, password);
                    
                }
            }
        }

        private static void InitializeDB()
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
                FillDate = new DateTime(2013, 1, 28),
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
                PhoneNumber = "5128289081"
            };

            var login = new Login { Name = "Barakis", FirstLogged = DateTime.Now, LastLogged = DateTime.Now };

            // Save the infor to the database
            user.Login = new Login {Name = "Barakis"};
            user.Doctors.Add(doctor);
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
            // lets add them to the proper collections
            user.Scripts.Add(script);
            user.Doctors.Add(doctor);
            doctor.Scripts.Add(script);
            doctor.Users.Add(user);

            user.Login.Hash = hash;
            user.Login.Salt = salt;

            var connectionString = "server=lokislayer.com;database=rxstore;uid=BARAKIS;password=BarakisMJB48;persistsecurityinfo=True;";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlTransaction trans = connection.BeginTransaction();
                try
                {
                    using (var db = new DbContext(connection, false))
                    {
                        db.Database.UseTransaction(trans);
                        db.Login.Add(login);
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
        }
    }
}
