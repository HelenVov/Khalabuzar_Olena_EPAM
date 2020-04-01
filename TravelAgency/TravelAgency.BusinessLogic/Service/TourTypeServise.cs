using System.Collections.Generic;
using AutoMapper;
using TravelAgency.BusinessLogic.Interfaces;
using TravelAgency.BusinessLogic.Models;
using TravelAgency.DataAccess.Interfaces;
using TravelAgency.DataAccess.Models;
using System.Linq;
using TravelAgency.Models;

namespace TravelAgency.BusinessLogic.Service
{
    public class TourTypeServise : ITourTypeService
    {
        private readonly IRepository<TourType> _repository;
        private readonly Mapper _mapper;

        public TourTypeServise(IRepository<TourType> repository, Mapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //public TourType GetTourType(int id)
        //{
        //   return _repository.GetById(id);
        //}

        //public IEnumerable<TourTypeBL> GetTourTypes()
        //{
        //    var tourType = _repository.GetAll();
        //    var mapTours = _mapper.Map<IEnumerable<TourType>, IEnumerable<TourTypeBL>>(tourType);

        //    return mapTours;
        //}
    
    }
}