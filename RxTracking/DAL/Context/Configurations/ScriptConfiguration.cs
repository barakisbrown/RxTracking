using DAL.Models;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Context.Configurations
{
    /// <summary>
    /// Entity Configuration for the Script Model
    /// </summary>
    public class ScriptConfiguration : EntityTypeConfiguration<Script>
    {
        public ScriptConfiguration()
        {
            ToTable("RxScripts");

            HasKey(s => s.ScriptId);

            #region REQUIRED PROPERTIES
            Property(s => s.Name).IsRequired();
            Property(s => s.Number).IsRequired();
            Property(s => s.Number).IsRequired();
            Property(s => s.DoseType).IsRequired();
            Property(s => s.DoseAmount).IsRequired();
            Property(s => s.Ndc).IsRequired();
            Property(s => s.Qty).IsRequired();
            Property(s => s.Supply).IsRequired();
            Property(s => s.RefillsLeft).IsRequired();
            Property(s => s.FillDate).IsRequired();
            #endregion 
        }
    }
}