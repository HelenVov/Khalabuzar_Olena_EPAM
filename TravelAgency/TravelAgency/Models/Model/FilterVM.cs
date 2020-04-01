using System.Collections.Generic;
using System.Web.Mvc;

namespace TravelAgency.Models.Model
{
    public class FilterVM
    {
        public IEnumerable<TourTypeVM> TourTypes { get; set; }

        public SelectList TourTypeSelect
        {
            get
            {
                return new SelectList(TourTypes, nameof(TourTypeVM.Id), nameof(TourTypeVM.Name));
            }
        }

        public IEnumerable<HotelTypeVM> HotelTypes { get; set; }

        public SelectList HotelTypeSelect
        {
            get
            {
                return new SelectList(HotelTypes, nameof(HotelTypeVM.Id), nameof(HotelTypeVM.Name));
            }
        }

        public DataFilterVM DataFilterVm { get; set; }

       public double PriceMax { get; set; }

        public double PriceMin { get; set; }

        public int PeopleCountMax { get; set; }

        public int PeopleCountMin { get; set; }

    }
}