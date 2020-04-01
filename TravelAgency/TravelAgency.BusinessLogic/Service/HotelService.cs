
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TravelAgency.BusinessLogic.Interfaces;
using TravelAgency.BusinessLogic.Models;
using TravelAgency.DataAccess.Interfaces;
using TravelAgency.DataAccess.Models;

namespace TravelAgency.BusinessLogic.Service
{
    public class HotelService:IHotelService
    {
        
      private readonly IRepository<Hotel> _repository;
      private readonly Mapper _mapper;

      public HotelService(IRepository<Hotel> repository, Mapper mapper)
      {
          _repository = repository;
          _mapper = mapper;
      }

        public Hotel GetHotel(int id)
        {
           return _repository.GetById(id);
        }

        public IEnumerable<HotelBL> GetHotels()
      {
          var hotels = _repository.GetAll();
          var mapHotels = _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelBL>>(hotels);

          return mapHotels;
      }
    }
}