using System;
using System.Linq;
using System.Security.Principal;
using TravelAgency.DataAccess.Interfaces;
using TravelAgency.DataAccess.Models;

namespace TravelAgency.Authentication
{
    internal class UserProvider : IPrincipal
    {
        private UserIdentity UserIdentity { get; }

        public IIdentity Identity => UserIdentity;

        public UserProvider()
        {
            UserIdentity = new UserIdentity();
        }

        public UserProvider(string name, IRepository<User> userRepository)
        {
            UserIdentity = new UserIdentity(name, userRepository);
        }

        public bool IsInRole(string role)
        {
            if (UserIdentity.User == null || string.IsNullOrWhiteSpace(role))
                return false;

            var roles = role.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries);

            var enums = Enum.GetValues(typeof(UserType)).Cast<UserType>().ToList();
          
            return roles.Contains(UserIdentity.User.UserType.ToString());
        }
    }
}