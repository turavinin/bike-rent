namespace DataLibrary.Mapping
{
    using DataLibrary.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RatesMap : EntityTypeConfiguration<Rates>
    {
        public RatesMap()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.Term).IsRequired().HasMaxLength(50);

            this.ToTable("Rates");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Term).HasColumnName("Term");
            this.Property(t => t.Price).HasColumnName("Price");
        }
    }
}
