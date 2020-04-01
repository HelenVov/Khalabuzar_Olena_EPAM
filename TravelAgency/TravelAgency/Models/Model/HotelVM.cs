namespace TravelAgency.Models.Model
{
    public class HotelVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string HotelType { get; set; }

        public HotelAddressVM HotelAddress { get; set; }
    }
}