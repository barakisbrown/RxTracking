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

            // BEGIN TESTS
            Console.WriteLine(CheckPassword() ? "Password test passed" : "Password test failed");
            Console.WriteLine("Dispalying all scripts");
            DisplayScripts();
            // Console.WriteLine("Adding Script Two");
            // AddScriptTwo();
            // Console.WriteLine("Dispalying all scripts");
            // DisplayScripts();
            // Console.WriteLine("Adding Dummy Doctor");
            // AddNewDoctor();
            // AddScriptThreeFrom2ndDoctor();
            Console.WriteLine("Display scripts from Doctor [Dr. Irvin]");
            DispalyScriptsFromDoctor("Dr. Irvin");
            Console.WriteLine("Display scripts from Doctor [Random Doctor]");
            DispalyScriptsFromDoctor("Random Doctor");
            // Use the new function[TestScriptService]
            TestScriptService();
            // ENDING TESTS
            Console.ReadKey();
        }

        private static void DisplayScripts()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                using (var db = new DbContext(conn, false))
                {
                    var S = db.Scripts.Take(5);

                    foreach (Script rx in S)
                    {
                        Console.WriteLine("RxNumber = {0}    Name = {1}  FillDate = {2}",rx.Number, rx.Number, rx.FillDate);
                    }
                }
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

        private static void AddScriptTwo()
        {
            using (var con = new MySqlConnection(connectionString))
            {
                using (var db = new DbContext(con, false))
                {
                    // DOCTOR
                    var D = db.Doctors.FirstOrDefault(d => d.Name == "Dr. Irvin");
                    var U = db.Users.FirstOrDefault(u => u.PhoneNumber == "5128289081");

                    var S = new Script()
                    {
                        Number = "420627",
                        Name = "SERTRALINE",
                        DoseType = "TAB",
                        DoseAmount = "50MG",
                        Ndc = "68180-0352-09",
                        Qty = 30.0,
                        Supply = 30.0,
                        FillDate = new DateTime(2013, 3,20),
                        RefillsLeft = 1.0                        
                    };

                    S.Users = U;
                    S.Doctors = D;
                    db.Scripts.Add(S);
                    db.SaveChanges();
                }
            }
        }

        private static void AddNewDoctor()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                using (var db = new DbContext(conn, false))
                {
                    var D = new Doctor
                    {
                        Name = "Random Doctor",
                        PhoneNumber = "5129999999",
                        Notes = "This is dummy doctor to test to see if I am able to do an insert",
                        Primary = false
                    };

                    db.Doctors.Add(D);
                    db.SaveChanges();
                }
            }
        }

        private static void AddScriptThreeFrom2ndDoctor()
        {
            using (var con = new MySqlConnection(connectionString))
            {
                using (var db = new DbContext(con,false))
                {
                    var D = db.Doctors.FirstOrDefault(d => d.Name == "Random Doctor");
                    var U = db.Users.FirstOrDefault(u => u.PhoneNumber == "5128289081");

                    var S = new Script()
                    {
                        Number = "420627",
                        Name = "SERTRALINE",
                        DoseType = "TAB",
                        DoseAmount = "50MG",
                        Ndc = "68180-0352-09",
                        Qty = 30.0,
                        Supply = 30.0,
                        FillDate = new DateTime(2013, 3, 20),
                        RefillsLeft = 1.0
                    };

                    // TIE SCRIPT TO Doctor who ordered and the user who it belongs too
                    S.Doctors = D;
                    S.Users = U;

                    // Add to table and save the table
                    db.Scripts.Add(S);
                    db.SaveChanges();

                }
            }
        }

        private static void DispalyScriptsFromDoctor(string name)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                using (var db = new DbContext(conn, false))
                {
                    var D = db.Doctors.FirstOrDefault(d => d.Name == name);
                    var S = db.Scripts.Take(5).Where(s => s.DoctorId == D.DoctorId);

                    foreach (Script rx in S)
                    {
                        Console.WriteLine("RxNumber = {0}    Name = {1}  FillDate = {2}", rx.Number, rx.Number, rx.FillDate);
                    }
                }
            }
        }

        private static void TestScriptService()
        {
            ScriptService _service = ScriptService.GetInstance();
            Console.WriteLine("Number of Entrties in this table is =: {0}", _service.Count());
            // ITERATE THROUGH SCRIPT DB
            foreach (Script rx in _service.GetAll())
            {
                Console.WriteLine("RxNumber = {0}    Name = {1}  FillDate = {2}    RxId = {3}", rx.Number, rx.Number, rx.FillDate, rx.ScriptId);
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
