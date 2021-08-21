namespace DataLibrary.Mapping
{
    using DataLibrary.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RentMap : EntityTypeConfiguration<Rent>
    {

        public RentMap()
        {
            this.HasKey(t => t.Id);


            this.Property(t => t.ClientName).IsRequired().HasMaxLength(50);

            this.ToTable("Rent");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ClientName).HasColumnName("ClientName");
            this.Property(t => t.PartialCost).HasColumnName("PartialCost");
            this.Property(t => t.Discount).HasColumnName("Discount");
            this.Property(t => t.FinalCost).HasColumnName("FinalCost");

        }
    }
}
