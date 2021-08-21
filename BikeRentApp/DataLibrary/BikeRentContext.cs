namespace DataLibrary
{
    using DataLibrary.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Entity.Infrastructure;
    using System.Configuration;
    using DataLibrary.Mapping;

    public class BikeRentContext : DbContext
    {
        public BikeRentContext() : base(ConnectionName())
        {
        }

        static private string ConnectionName()
        {
            return "Server=DESKTOP-8DV7LR2;Database=DbBikeRent;User Id=sa;Password=1235;MultipleActiveResultSets=True;Persist Security Info=True;";
        }


        #region Models
        public DbSet<Rates> Rates { get; set; }
        public DbSet<Rent> Rent { get; set; }
        public DbSet<RentDetail> RentDetail { get; set; }
        #endregion

        #region Builder
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RatesMap());
            modelBuilder.Configurations.Add(new RentMap());
            modelBuilder.Configurations.Add(new RentDetailMap());
        }
        #endregion
    }
}
