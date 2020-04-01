using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using TravelAgency.Authentication;
using TravelAgency.BusinessLogic.Interfaces;
using TravelAgency.BusinessLogic.Models;
using TravelAgency.DataAccess.Models;
using TravelAgency.Models;
using TravelAgency.Models.Model;

namespace TravelAgency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITourService _tourService;
        private readonly Mapper _mapper;
        public HomeController(ITourService tourService, Mapper mapper)
        {
            _tourService = tourService;
            _mapper = mapper;
        }
        
        public ActionResult Index()
        {
           var tours= _tourService.GetHotTours();
           var mapTours=_mapper.Map<IEnumerable<TourBL>, IEnumerable<TourVM>>(tours);

            return View(new ToursVM {
            Tours=mapTours});
        }

        public ActionResult MoreDetailsATour(int? id)
        {

            if (!id.HasValue)
            {
                return View("Error");
            }
            else
            {
                var tour = _tourService.GetTour(id.Value);
                var maptour = _mapper.Map<TourBL, TourVM>(tour);

                return View(maptour);
            }
        }
        [Authorize]
        public ActionResult Book(int idTour)
        {
            try
            {
                _tourService.BookTour(idTour, ((UserIdentity)User.Identity).Id.Value);
            }
            catch (ArgumentException e)
            {
                return HttpNotFound();
            }
            
            return RedirectToAction("Profile","User");

        }
    }
}