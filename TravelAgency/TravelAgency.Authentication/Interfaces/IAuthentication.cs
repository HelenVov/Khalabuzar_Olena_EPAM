using System.Security.Principal;
using System.Web;
using TravelAgency.DataAccess.Models;

namespace TravelAgency.Authentication.Interfaces
{
    public interface IAuthentication
    {
        User User { get; }

        IPrincipal CurrentUser { get; }

        HttpContext Context { get; set; }

        User Login(string login, string password, bool stayLogged);

        void Logout();
    }
}