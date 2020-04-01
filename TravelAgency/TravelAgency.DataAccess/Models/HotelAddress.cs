namespace TravelAgency.DataAccess.Models
{
    public class HotelAddress : BaseEntity
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }
    }
}