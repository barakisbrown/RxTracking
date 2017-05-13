using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DAL.Models;
using MySql.Data.Entity;

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
        public DbContext() : base("ConnectionString")
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
            // One-One Table Configurations
            // Logins <=> UserInfo
            modelBuilder.Entity<Logins>()
                .HasRequired(U => U.User).WithRequiredPrincipal(L => L.Login);

            // Orders to Scripts
            modelBuilder.Entity<Orders>()
                .HasRequired<Scripts>(s => s.Script).WithRequiredPrincipal(O => O.Order);

            // One to Many Table Configurations
            // UserInfo(1) to Orders(M)
            modelBuilder.Entity<Orders>()
                .HasRequired<UserInfo>(U => U.User).WithMany(o => o.Orders);

            // UserInfo(1) to Scripts(M)
            modelBuilder.Entity<Scripts>()
                .HasRequired<UserInfo>(U => U.User).WithMany(S => S.Scripts);
            
            // Orders(1) to Stores(M)
            modelBuilder.Entity<Stores>()
                .HasRequired<Orders>(O => O.Order).WithMany(S => S.Stores);

            // Doctors(1) to Scripts(M)
            modelBuilder.Entity<Scripts>()
                .HasRequired<Doctors>(D => D.Doctor).WithMany(S => S.Scripts);

            // MANY TO MANY TABLE CONFIGURATIONS
            modelBuilder.Entity<UserInfo>()
                .HasMany<Doctors>(D => D.Doctors)
                .WithMany(U => U.Users)
                .Map(UD =>
                {
                    UD.MapLeftKey("UsersId");
                    UD.MapRightKey("DoctorId");
                    UD.ToTable("UsersDoctors");
                });

        }

        // TABLES AKA DbSet<>
        public DbSet<Logins> Logins { get; set; }
        public DbSet<UserInfo> Users { get; set; }
        public DbSet<Stores> Stores { get; set; }
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Scripts> Scripts { get; set; }
    }
}