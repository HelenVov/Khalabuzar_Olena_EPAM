using System;
using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Models.Model
{
    public class CreateTourVM
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression("[А-Я]{1}[а-я]{2,10}",
            ErrorMessage = "Имя должно начинаться с заглавной буквы, длина-мин. 3 символа, длина-макс. 10 символов.")]
        public string Name { get; set; }
        [Required]
        public DateTime DepartureData { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }

        [Required]
        [RegularExpression("^([1-9]|1[0-2])$",
            ErrorMessage = "Количество людей от 1-12.")]
        public int PeopleCount { get; set; }
        [Required]
        public int TourTypeId { get; set; }
        [Required]
        public int HotelId { get; set; }

        [Required]
        [RegularExpression("\\d{1,4}|1000",
            ErrorMessage = "Цена от 1 до 9999.")]
        public double Price { get; set; }

        [Required]
        public bool Hot { get; set; }

        public int Discount { get; set; }
    }
}