using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using TravelAgency.BusinessLogic.Interfaces;
using TravelAgency.BusinessLogic.Models;
using TravelAgency.DataAccess.Models;
using TravelAgency.Models.Model;
using TravelAgency.Models.UserModel;

namespace TravelAgency.Controllers
{
    [Authorize(Roles = nameof(UserType.Admin))]
    public class AdministratorController : Controller
    {
        private readonly ITourService _tourService;
        private readonly IUserService _userService;
        private readonly Mapper _mapper;
        public AdministratorController(ITourService tourService, Mapper mapper, IUserService userService)
        {
            _tourService = tourService;
            _mapper = mapper;
            _userService = userService;
        }
        
        public ActionResult DeleteTour()
        {
            var countTour = _tourService.GetTours().Count();

            return View(new DataDeleteTourVM
            { CountTour = countTour });
        }

        [HttpPost]
        public ActionResult DeleteTour(DataDeleteTourVM deleteTourVm)
        {

            if (ModelState.IsValid)
            {
                _tourService.DeleteTour(deleteTourVm.Id);
            }
            var countTour = _tourService.GetTours().Count();
            return View(new DataDeleteTourVM
            { CountTour = countTour });
        }

        public ActionResult ModificationTour()
        {
            var countTour = _tourService.GetTours().Count();

            return View(new ModificationTourVM()
            { CountTour = countTour });
        }

        [HttpPost]
        public ActionResult ModificationTour(ModificationTourVM modificationTourVm)
        {

            if (modificationTourVm.Id > 0)
            {
                var tour = _mapper.Map<TourBL, TourVM>(_tourService.GetTour(modificationTourVm.Id));

                if (tour != null)
                {
                    var dataCreateTour = _tourService.GetDateCreateTour();
                    var mapData = _mapper.Map<DataCreateTourBL, DataCreatTourVM>(dataCreateTour);
                    return View("UpdateTour", new ModificationTourVM()
                    {
                        TourVm = tour,
                        DataCreated = mapData,
                        Id = modificationTourVm.Id
                    });
                }

            }

            var countTour = _tourService.GetTours().Count();

            return View(new ModificationTourVM()
            { CountTour = countTour });
        }
        
        [HttpPost]
        public ActionResult UpdateTour(ModificationTourVM modificationTourVm)
        {
            var tour = _mapper.Map<CreateTourVM, CreateTourBL>(modificationTourVm.DataCreated.Tour);
            tour.Id = modificationTourVm.Id;
            _tourService.Update(tour);

            return RedirectToAction("MoreDetailsATour", "Home", tour);
        }

        public ActionResult AllUser()
        {
            var users=_mapper.Map<IEnumerable<UserBL>,IEnumerable<UserVM>>(_userService.GetUsers());

            return View(new UsersVM(){Users = users});
        }

        [HttpGet]
        public ActionResult Block(int id)
        {
            _userService.Block(id);
            return RedirectToAction("AllUser");
        }

        [HttpGet]
        public ActionResult Unblock(int id)
        {
            _userService.Unblock(id);

            return RedirectToAction("AllUser");
        }
    }
}