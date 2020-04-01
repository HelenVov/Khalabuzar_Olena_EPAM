
namespace TravelAgency.BusinessLogic.Models
{
    public class HotelBL
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string HotelType { get; set; }

        public HotelAddressBL HotelAddress { get; set; }
    }
}