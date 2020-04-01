using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.BusinessLogic.Interfaces;
using TravelAgency.BusinessLogic.Models;
using TravelAgency.Models;
using TravelAgency.Models.Model;

namespace TravelAgency.Controllers
{
    public class SearchController : Controller
    {
        private readonly ITourService _tourService;
        private readonly Mapper _mapper;
        public SearchController(ITourService tourService, Mapper mapper)
        {
            _tourService = tourService;
            _mapper = mapper;
        }
        public ActionResult SearchTours()
        {
            var tours = _tourService.GetHotTours();
            var maptours = _mapper.Map<IEnumerable<TourBL>, IEnumerable<TourVM>>(tours);
            var mapFilter = _mapper.Map<DataSearchBL, FilterVM>(_tourService.GetDataSearch());
            return View(new DataSearchVM
            {
                Filter = mapFilter,
                Tours = new ToursVM
                {
                    Tours = maptours
                }
            });

    }

    [HttpPost]
    public ActionResult SearchTours(FilterVM searchVM)
    {
        var mapFilter = _mapper.Map<DataSearchBL, FilterVM>(_tourService.GetDataSearch());
        
        if (ModelState.IsValid)
        {
            var searchTours = _tourService.GetSearchTour(_mapper.Map<DataFilterVM, DataFilterBL >(searchVM.DataFilterVm));
            var mapSearchTours = _mapper.Map<IEnumerable<TourBL>, IEnumerable<TourVM>>(searchTours);
            return View(new DataSearchVM
            {
                Filter = mapFilter,
                Tours = new ToursVM
                {
                    Tours = mapSearchTours
                }
            });
        }

        var tours = _tourService.GetHotTours();
        var maptours = _mapper.Map<IEnumerable<TourBL>, IEnumerable<TourVM>>(tours);
        return View(new DataSearchVM
        {
            Filter = mapFilter,
            Tours = new ToursVM
            {
                Tours = maptours
            }
        });

        }
}
}