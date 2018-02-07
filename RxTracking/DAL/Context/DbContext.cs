using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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

        }

        /// <summary>
        /// Used when the model is first build and then created/stored to the backend
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            // USER ENTITY
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<User>().HasRequired(u => u.FirstName);
            modelBuilder.Entity<User>().HasRequired(u => u.LastName);
            modelBuilder.Entity<User>().HasRequired(u => u.Address);
            modelBuilder.Entity<User>().HasRequired(u => u.City);
            modelBuilder.Entity<User>().HasRequired(u => u.State);
            modelBuilder.Entity<User>().HasRequired(u => u.ZipCode);
            modelBuilder.Entity<User>().HasRequired(u => u.PhoneNumber);

            // LOGIN ENTITY
            modelBuilder.Entity<Login>().ToTable("Logins");
            modelBuilder.Entity<Login>().HasKey(l => l.LoginId);
            modelBuilder.Entity<Login>().HasRequired(l => l.Name);
            modelBuilder.Entity<Login>().HasRequired(l => l.Hash);
            modelBuilder.Entity<Login>().HasRequired(l => l.Salt);

            // 1 to 1 RELATIONSHIP
            modelBuilder.Entity<Login>()
                .HasRequired(l => l.User)
                .WithRequiredPrincipal(u => u.Login);
        }
           
        // TABLES AKA DbSet      
        public DbSet<User> Users { get; set; }
        public DbSet<Login> Login { get; set; }
    }
}