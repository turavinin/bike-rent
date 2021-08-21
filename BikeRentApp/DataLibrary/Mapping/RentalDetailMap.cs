namespace DataLibrary.Mapping
{
    using DataLibrary.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RentDetailMap : EntityTypeConfiguration<RentDetail>
    {
        public RentDetailMap()
        {
            this.HasKey(t => t.Id);


            this.ToTable("RentDetail");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdRent).HasColumnName("IdRent");
            this.Property(t => t.IdRate).HasColumnName("IdRate");
            this.Property(t => t.amountTerm).HasColumnName("amountTerm");
            this.Property(t => t.totalRents).HasColumnName("totalRents");


            HasRequired(t => t.Rental).WithMany(t => t.RentDetails).HasForeignKey(d => d.IdRent);


        }
    }
}
