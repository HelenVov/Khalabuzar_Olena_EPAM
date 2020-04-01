using System;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using TravelAgency.Authentication.Interfaces;
using TravelAgency.DataAccess.Interfaces;
using TravelAgency.DataAccess.Models;

namespace TravelAgency.Authentication
{
    public class Authentication : IAuthentication
    {
        private const string CookieName = "__AUTH_COOKIE";

        private IPrincipal _currentUser;

        private readonly IRepository<User> _userRepository;

        public Authentication(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User User => ((UserIdentity)CurrentUser.Identity).User;
        public HttpContext Context { get; set; }

        public IPrincipal CurrentUser
        {
            get
            {
                var authCookie = Context?.Request.Cookies.Get(CookieName);

                if (string.IsNullOrEmpty(authCookie?.Value))
                {
                    _currentUser = new UserProvider();
                    return _currentUser;
                }

                try
                {
                    var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                    _currentUser = new UserProvider(ticket.Name, _userRepository);
                }
                catch
                {
                    _currentUser = new UserProvider();
                }

                return _currentUser;
            }
        }

        public User Login(string login, string password, bool stayLogged)
        {
            var users = _userRepository.GetAll();
            User user = null;
            try
            {
                user = users.First(f => string.Compare(f?.Login, login, StringComparison.OrdinalIgnoreCase) == 0);
            }
            catch
            {
                return null;
            }

            if (user == null || password != user.Password ||user.Block)
                return null;

            //Set up cookie ***************
            var ticket = new FormsAuthenticationTicket(
                version: 1,
                name: user.Login,
                issueDate: Context.Timestamp.ToUniversalTime(),
                expiration: Context.Timestamp.ToUniversalTime().Add(FormsAuthentication.Timeout),
                isPersistent: stayLogged,
                userData: "",
                cookiePath: FormsAuthentication.FormsCookiePath);

            var authCookie = new HttpCookie(CookieName)
            {
                Value = FormsAuthentication.Encrypt(ticket),
                Expires = ticket.Expiration
            };

            Context.Response.Cookies.Add(authCookie);
            //end setup ******************
            _currentUser = new UserProvider(user.Login, _userRepository);

            return user;
        }

        public void Logout()
        {
            var authCookie = Context.Response.Cookies[CookieName];
            if (authCookie != null)
                authCookie.Value = string.Empty;
        }
    }
}