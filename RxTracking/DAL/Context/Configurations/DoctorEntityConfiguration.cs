using System.Data.Entity.ModelConfiguration;
using DAL.Models;

namespace DAL.Context.Configurations
{
    /// <summary>
    /// Entity Configuration for the Doctor Model
    /// </summary>
    public class DoctorEntityConfiguration : EntityTypeConfiguration<Doctor>
    {
        public DoctorEntityConfiguration()
        {            
            ToTable("Doctors");

            HasKey(d => d.DoctorId);

            #region REQUIRED PROPERTIES
            Property(d => d.Name).IsRequired();
            Property(d => d.PhoneNumber).IsRequired();
            Property(d => d.Primary).IsRequired();
            Property(d => d.Specialist).IsRequired();
            #endregion

            // 1 TO M SCRIPTS
            HasRequired<Script>(d => d.Scripts).WithMany(s => s.Doctors).HasForeignKey(d => d.DoctorId);

        }
    }
}