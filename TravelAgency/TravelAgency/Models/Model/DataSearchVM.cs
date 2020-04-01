using System.Collections.Generic;
using System.Web.Mvc;

namespace TravelAgency.Models.Model
{
    public class DataSearchVM
    {
        public ToursVM Tours { get; set; }

        public FilterVM Filter { get; set; }
    }
}