using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgency.BusinessLogic.Interfaces;
using TravelAgency.BusinessLogic.Models;
using TravelAgency.DataAccess.Models;
using TravelAgency.Models;
using TravelAgency.Models.Model;

namespace TravelAgency.Controllers
{
    [Authorize(Roles ="Admin,Manager")]
    public class ManagerController : Controller
    {
        private readonly ITourService _tourService;
        private readonly ISettingsService _settingsService;
        private readonly Mapper _mapper;
        public ManagerController(ITourService tourService, Mapper mapper, ISettingsService settingsService)
        {
            _tourService = tourService;
            _mapper = mapper;
            _settingsService = settingsService;
        }
        public ActionResult CreateTour()
        {
            var dataCreateTour = _tourService.GetDateCreateTour();
            var mapData = _mapper.Map<DataCreateTourBL, DataCreatTourVM>(dataCreateTour);
            return View(mapData);
            
        }

        [HttpPost]
        public ActionResult CreateTour(DataCreatTourVM createTourVm) {

            if (ModelState.IsValid)
            {
               var tour= _tourService.AddTour(_mapper.Map<CreateTourVM,CreateTourBL>(createTourVm.Tour));

                return RedirectToAction("MoreDetailsATour","Home", tour);
            }

            var dataCreateTour = _tourService.GetDateCreateTour();
            var mapData = _mapper.Map<DataCreateTourBL, DataCreatTourVM>(dataCreateTour);
            return View(mapData);

        }

        [HttpGet]
        public ActionResult Paid(int id)
        {
            _tourService.Paid(id);

            return RedirectToAction("Booking");
        }
        [HttpGet]
        public ActionResult Canceled(int id)
        {
            _tourService.Canceled(id);
            return RedirectToAction("Booking");
        }

        public ActionResult Booking()
        {
          var tours= _mapper.Map<IEnumerable<TourBL>,IEnumerable<TourVM>>( _tourService.GetAllRegistered());

            return View(new ToursVM(){
                 Tours = tours});
        }
        [HttpGet]
        public ActionResult GlobalSettings()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GlobalSettings(SettingsVM settingsVm)
        {
            _settingsService.Update(_mapper.Map<SettingsVM,SettingsBL>(settingsVm));
            return RedirectToAction("Index","Home");
        }
    }
}