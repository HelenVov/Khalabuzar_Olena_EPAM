using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Models;

namespace TravelAgency.BusinessLogic.Models
{
   public class DataCreateTourBL
    {
        public IEnumerable<HotelBL> Hotels { get; set; }

        public IEnumerable<TourTypeBL> TourTypes { get; set; }
    }
}
