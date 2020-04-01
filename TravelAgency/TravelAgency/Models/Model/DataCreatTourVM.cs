using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.BusinessLogic.Models;

namespace TravelAgency.Models.Model
{
    public class DataCreatTourVM
    {
        public CreateTourVM Tour { get; set; }

        public IEnumerable<HotelVM> Hotels { get; set; }

        public SelectList HotelsSelect
        {
            get
            {
                return new SelectList(Hotels, nameof(HotelVM.Id),nameof(HotelVM.Name));
            }
        }

        public IEnumerable<TourTypeVM> TourTypes { get; set; }

        public SelectList TourTypeSelect
        {
            get
            {
                return new SelectList(TourTypes, nameof(TourTypeVM.Id), nameof(TourTypeVM.Name));
            }
        }
    }
}