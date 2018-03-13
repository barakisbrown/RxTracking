using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using DAL.Models;

namespace DAL.Context.Configurations
{
    /// <summary>
    /// Entity Configuration for the Login Model
    /// </summary>
    public class LoginEntityConfiguration : EntityTypeConfiguration<Login>
    {
        public LoginEntityConfiguration()
        {
            ToTable("Logins");

            HasKey(l => l.LoginId);
            Property(l => l.LoginId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            #region REQUIRED PROPERITES
            Property(l => l.Name).IsRequired();
            Property(l => l.Hash).IsRequired();
            Property(l => l.Salt).IsRequired();
            #endregion

            // 1 to 1 RELATIONSHIP            
            HasRequired(l => l.User).WithRequiredPrincipal(u => u.Login);
        }
    }
}