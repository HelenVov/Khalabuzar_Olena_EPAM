using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Models.Model
{
    public class DataFilterVM
    {
        public int HotelTypeId { get; set; }

        public int TourTypeId { get; set; }

        [RegularExpression("\\d{1,4}|1000",
            ErrorMessage = "Цена от 1 до 9999.")]
        public double Price { get; set; }

        [RegularExpression("^([1-9]|1[0-2])$",
        ErrorMessage = "Количество людей от 1-12.")]
        public int PeopleCount { get; set; }
    }
}