using System.Data.Entity.ModelConfiguration;
using DAL.Models;

namespace DAL.Context.Configurations
{
    /// <summary>
    /// Entity Configuration for the User Model
    /// </summary>
    public class UserEntityConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            ToTable("Users");

            HasKey(u => u.UserId);

            #region REQUIRED PROPERRTIES
            Property(u => u.FirstName).IsRequired();
            Property(u => u.LastName).IsRequired();
            Property(u => u.Address).IsRequired();
            Property(u => u.City).IsRequired();
            Property(u => u.State).IsRequired();
            Property(u => u.ZipCode).IsRequired();
            Property(u => u.PhoneNumber).IsRequired();
            #endregion

            // MANY TO MANY RELATIONSHIP
            HasMany<Doctor>(u => u.Doctors)
                .WithMany(d => d.Users)
                .Map(du =>
                {
                    du.MapLeftKey("UserRefId");
                    du.MapRightKey("DoctorRefId");
                    du.ToTable("UserDoctors");
                });

            // 1 TO M SCRIPTS
            HasRequired<Script>(s => s.Scripts).WithMany(u => u.Users).HasForeignKey(s => s.UserId);
        }
    }
}