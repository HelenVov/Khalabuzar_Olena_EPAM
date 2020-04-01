using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using TravelAgency.Authentication;
using TravelAgency.Authentication.Interfaces;
using TravelAgency.BusinessLogic.Interfaces;
using TravelAgency.BusinessLogic.Models;
using TravelAgency.DataAccess.Interfaces;
using TravelAgency.Models.UserModel;

namespace TravelAgency.Controllers
{

    public class UserController : Controller
    {
        private readonly IAuthentication _authentication;
        private readonly IUserService _userService;
        private readonly Mapper _mapper;


        public UserController(IAuthentication authentication, IUserService userService, Mapper mapper)
        {
            _authentication = authentication;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationData registrationData)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<RegistrationData, UserBL>(registrationData);

                try
                {
                    _userService.CreateUser(user);
                }
                catch (ArgumentException e)
                {
                    ModelState.AddModelError(nameof(registrationData.Login), e.Message);
                }
                return RedirectToAction("Login", "User");
            }


            return View();

        }
        [HttpPost]
        public ActionResult Login(LoginData loginData)
        {
            var result = _authentication.Login(loginData.Login, loginData.Password, true);
            if (result == null)
            {
                ModelState.AddModelError(nameof(loginData.Login), "there is no such combination");
                return View();
            }
            return RedirectToAction("Profile", "User");
        }

        [Authorize]
        public ActionResult Profile()
        {
            var userId = ((UserIdentity)User.Identity).Id.Value;
            var user = _mapper.Map<UserBL, UserVM>(_userService.GetUser(userId));
            return View(user);
        }
        [Authorize]
        public ActionResult Logout()
        {
            _authentication.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}