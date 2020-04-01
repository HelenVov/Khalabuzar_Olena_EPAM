using System.Collections.Generic;
using AutoMapper;
using TravelAgency.BusinessLogic.Models;
using TravelAgency.DataAccess.Interfaces;
using TravelAgency.DataAccess.Models;

namespace TravelAgency.BusinessLogic.Interfaces
{
    public interface IHotelService
    {
         IEnumerable<HotelBL> GetHotels();

         Hotel GetHotel(int id);

    }
}