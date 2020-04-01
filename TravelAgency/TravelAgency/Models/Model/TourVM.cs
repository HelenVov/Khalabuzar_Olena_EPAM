using System;
using TravelAgency.Models.UserModel;

namespace TravelAgency.Models.Model
{
    public class TourVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DepartureData { get; set; }

        public DateTime ArrivalDate { get; set; }

        public int PeopleCount { get; set; }

        public string TourType { get; set; }

        public HotelVM Hotel { get; set; }

        public double Price { get; set; }

        public bool Hot { get; set; }

        public UserVM BookedBy { get; set; }

        public TourState TourState { get; set; } = TourState.Active;

        public int Discount { get; set; }

    }
}
