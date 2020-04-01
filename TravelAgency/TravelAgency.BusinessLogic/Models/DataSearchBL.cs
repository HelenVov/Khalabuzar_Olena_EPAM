using System.Collections.Generic;
using TravelAgency.Models;

namespace TravelAgency.BusinessLogic.Models
{
    public class DataSearchBL
    {
        public IEnumerable<TourTypeBL> TourTypes { get; set; }

        public IEnumerable<HotelTypeBL> HotelTypes { get; set; }
        
        public double PriceMax { get; set; }

        public double PriceMin { get; set; }

        public int PeopleCountMax { get; set; }

        public int PeopleCountMin { get; set; }
    }
}