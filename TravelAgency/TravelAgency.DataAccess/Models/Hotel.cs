
namespace TravelAgency.DataAccess.Models
{
    public class Hotel : BaseEntity
    {
        public string Name { get; set; }

        public virtual HotelType HotelType { get; set; }

        public virtual HotelAddress HotelAddress { get; set; }
    }
}