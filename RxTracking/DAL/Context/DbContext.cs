using System.Data.Common;
using System.Data.Entity;
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
            base.OnModelCreating(modelBuilder);
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