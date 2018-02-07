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
        /// This is where i define all properties and mapping between tables.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();

            // USER ENTITY
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<User>().Property(u => u.FirstName).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.LastName).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Address).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.City).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.State).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.ZipCode).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.PhoneNumber).IsRequired();

            // LOGIN ENTITY
            modelBuilder.Entity<Login>().ToTable("Logins");
            modelBuilder.Entity<Login>().HasKey(l => l.LoginId);
            modelBuilder.Entity<Login>().Property(l => l.Name).IsRequired();
            modelBuilder.Entity<Login>().Property(l => l.Hash).IsRequired();
            modelBuilder.Entity<Login>().Property(l => l.Salt).IsRequired();

            // DOCTOR ENTITY
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<Doctor>().HasKey(d => d.DoctorId);
            modelBuilder.Entity<Doctor>().Property(d => d.Name).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.PhoneNumber).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.Primary).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.Specialist).IsRequired();

            // 1 to 1 RELATIONSHIP
            modelBuilder.Entity<Login>()
                .HasRequired(l => l.User)
                .WithRequiredPrincipal(u => u.Login);

            // MANY TO MANY RELATIONSHIP
            modelBuilder.Entity<User>()
                .HasMany<Doctor>(u => u.Doctors)
                .WithMany(d => d.Users)
                .Map(du =>
                {
                    du.MapLeftKey("UserRefId");
                    du.MapRightKey("DoctorRefId");
                    du.ToTable("UserDoctors");
                });
        }
           
        // TABLES AKA DbSet      
        public DbSet<User> Users { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
    }
}