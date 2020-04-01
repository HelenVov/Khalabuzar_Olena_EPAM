using System.Collections.Generic;
using TravelAgency.BusinessLogic.Models;

namespace TravelAgency.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserBL> GetUsers();

        UserBL GetUser(int id);

        void AddUser(UserBL userBl);

        void Block(int id);

        void Unblock(int id);


        void CreateUser(UserBL user);
    }
}