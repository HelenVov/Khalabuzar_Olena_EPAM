using System.Collections.Generic;

namespace TravelAgency.BusinessLogic.Models
{
    public class DataFilterBL
    {
        public int HotelTypeId { get; set; }

        public int TourTypeId { get; set; }

        public double Price { get; set; }

        public int PeopleCount { get; set; }
    }
}