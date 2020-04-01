using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Models.UserModel
{
    public class LoginData
    {
        [Required]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}