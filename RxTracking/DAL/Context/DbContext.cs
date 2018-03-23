using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DAL.Context.Configurations;
using DAL.Models;
using MySql.Data.Entity;
using GalaSoft.MvvmLight.Ioc;

namespace DAL.Context
{
    /// <summary>
    /// My Context for the DAL part of RxTracking
    /// </summary>
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DbContext : System.Data.Entity.DbContext
    {
        /// <summary>
        /// Created a connection 
        /// </summary>
        [PreferredConstructor]
        public DbContext() : base("MyConnectionString")
        {
             
        }

        /// <summary>
        /// Using an existing connection and created a DbContext from it or simply returns it.
        /// </summary>
        /// <param name="existingConnection"></param>
        /// <param name="contextOwnConnection"></param>
        public DbContext(DbConnection existingConnection, bool contextOwnConnection)
            : base(existingConnection, contextOwnConnection)
        {
            // Database.SetInitializer(new DropCreateDatabaseAlways<DbContext>());
        }

        /// <summary>
        /// Used when the model is first build and then created/stored to the backend
        /// This is where i define all properties and mapping between tables.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            // LOADING FROM CONFIG FILES
            modelBuilder.Configurations.Add(new UserEntityConfiguration());
            modelBuilder.Configurations.Add(new LoginEntityConfiguration());
            modelBuilder.Configurations.Add(new DoctorEntityConfiguration());
            modelBuilder.Configurations.Add(new ScriptConfiguration());
        }
           
        // TABLES AKA DbSet      
        public DbSet<User> Users { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Script> Scripts { get; set; }
    }
}