using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.BusinessLogic.Models
{
    public class UserBL
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public bool Block { get; set; }

        public string MobilePhone { get; set; }
        public string Password { get; set; }
        public virtual ICollection<TourBL> Tours { get; set; }

        public int Discount { get; set; }
    }
}
