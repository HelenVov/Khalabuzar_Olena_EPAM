using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelAgency.Models.Model;

namespace TravelAgency.Models.UserModel
{
    public class UserVM
    {
        [RegularExpression("[А-Я]{1}[а-я]{2,10}",
            ErrorMessage = "Имя должно начинаться с заглавной буквы, длина-мин. 3 символа, длина-макс. 10 символов.")]
        public string FirstName { get; set; }

        [RegularExpression("[А-Я]{1}[а-я]{2,10}",
            ErrorMessage = "Фамилия должна начинаться с заглавной буквы, длина-мин. 3 символа, длина-макс. 10 символов.")]
        public string LastName { get; set; }

        public string Login { get; set; }

        public bool Block { get; set; }

        public int Id { get; set; }

        public int Discount { get; set; }

        public string MobilePhone { get; set; }

        public virtual ICollection<TourVM> Tours { get; set; }
    }
}