using System;

namespace TravelAgency.BusinessLogic.Models
{
    public class CreateTourBL
    {
        public int Id { get; set; }
      
        public string Name { get; set; }

        public DateTime DepartureData { get; set; }

        public DateTime ArrivalDate { get; set; }

        public int PeopleCount { get; set; }

        public int TourTypeId { get; set; }

        public int HotelId { get; set; }

        public double Price { get; set; }

        public bool Hot { get; set; }

        public int Discount { get; set; }

    }
}