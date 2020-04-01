using System.Data.Entity;
using TravelAgency.DataAccess.Models;

namespace TravelAgency.DataAccess
{
    public class TravelAgencyContext : DbContext
    {
        public TravelAgencyContext(string connectionStringName):base(connectionStringName)
        {
            this.Configuration.LazyLoadingEnabled = true;

            System.Data.Entity.Database.SetInitializer(new TravelAgencyContextInitializer());

        }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Hotel>  Hotels { get; set; }

        public DbSet<HotelAddress> HotelAddresses { get; set; }

        public DbSet<HotelType> HotelTypes { get; set; }

        public DbSet<TourType> TourTypes { get; set; }

        public DbSet<Settings> Settings { get; set; }

    }
}