using System;

namespace TravelAgency.BusinessLogic.Models
{
    public class TourBL
    {
        public int Id { get; set; }

        public string Name { get; set; }

       public DateTime DepartureData { get; set; }

        public DateTime ArrivalDate { get; set; }

        public int PeopleCount { get; set; }

        public  string TourType { get; set; }

        public HotelBL Hotel { get; set; }

        public double Price { get; set; }

        public bool Hot { get; set; }

        public UserBL BookedBy { get; set; }

        public TourState TourState { get; set; } = TourState.Active;


        public int Discount { get; set; }

    }
}
