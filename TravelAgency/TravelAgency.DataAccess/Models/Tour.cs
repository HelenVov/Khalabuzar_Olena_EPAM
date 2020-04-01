using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.DataAccess.Models
{
    public class Tour : BaseEntity
    {
        public string Name { get; set; }

        public DateTime DepartureData { get; set; }

        public DateTime ArrivalDate { get; set; }

        public int PeopleCount { get; set; }

        public virtual TourType TourType { get; set; }

        public virtual Hotel Hotel { get; set; }

        public double Price { get; set; }

        public bool Hot { get; set; }

        [ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }

        [ForeignKey(nameof(TourType))]
        public int  TourTypeId { get; set; }

        [ForeignKey(nameof(BookedBy))]
        public int? BookedById { get; set; }

        public virtual User BookedBy { get; set; }

        public TourState TourState { get; set; } = TourState.Active;

        public int Discount { get; set; }
    }
}
