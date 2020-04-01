using System.Linq;
using System.Security.Principal;
using TravelAgency.DataAccess.Interfaces;
using TravelAgency.DataAccess.Models;

namespace TravelAgency.Authentication
{
    public class UserIdentity : IIdentity
    {
        public User User { get; set; }

        public int? Id => User?.Id;
        public string Name => User == null ? "N/A" : $"{User.FirstName} {User.LastName}";

        public string AuthenticationType => "Custom";

        public bool IsAuthenticated => User != null;

        /// <summary>
        /// For empty User
        /// </summary>
        public UserIdentity()
        {

        }

        /// <summary>
        /// Try to authorize
        /// </summary>
        /// <param name="login"></param>
        /// <param name="userRepository"></param>
        public UserIdentity(string login, IRepository<User> userRepository)
        {
            if (string.IsNullOrEmpty(login))
                return;
            User = userRepository.GetMany(u => u.Login == login).First();
        }
    }
}
