using System;
using System.Collections.Generic;
using AutoMapper;
using TravelAgency.BusinessLogic.Interfaces;
using TravelAgency.BusinessLogic.Models;
using TravelAgency.DataAccess.Interfaces;
using TravelAgency.DataAccess.Models;
using System.Linq;
using TravelAgency.Models;
using TourState = TravelAgency.DataAccess.Models.TourState;

namespace TravelAgency.BusinessLogic.Service
{
    public class TourService : ITourService
    {
        private readonly IRepository<Tour> _tourRepository;
        private readonly IRepository<Hotel> _hotelRepository;
        private readonly IRepository<HotelType> _hotelTypeRepository;
        private readonly IRepository<TourType> _tourTypeRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Settings> _settingsRepository;

        private readonly Mapper _mapper;

        public TourService(IRepository<Tour> tourRepository, Mapper mapper, IRepository<Hotel> hotelRepository, IRepository<TourType> tourTypeRepository, IRepository<HotelType> hotelTypeRepository, IRepository<User> userRepository, IRepository<Settings> settingsRepository)
        {
            _tourRepository = tourRepository;
            _mapper = mapper;
            _hotelRepository = hotelRepository;
            _tourTypeRepository = tourTypeRepository;
            _hotelTypeRepository = hotelTypeRepository;
            _userRepository = userRepository;
            _settingsRepository = settingsRepository;
        }

        public IEnumerable<TourBL> GetTours()
        {
            var tours = _tourRepository.GetAll();
            var mapTours = _mapper.Map<IEnumerable<Tour>, IEnumerable<TourBL>>(tours);

            return mapTours;
        }

        public TourBL AddTour(CreateTourBL tourBL)
        {
            var mapTour = _mapper.Map<CreateTourBL, Tour>(tourBL);
            mapTour.TourTypeId = tourBL.TourTypeId;
            mapTour.HotelId = tourBL.HotelId;

            return _mapper.Map<Tour, TourBL>(_tourRepository.Add(mapTour));

        }

        public TourBL GetTour(int id)
        {
            var tour = _tourRepository.GetById(id);
            var mapTour = _mapper.Map<Tour, TourBL>(tour);

            return mapTour;
        }

        public IEnumerable<TourBL> GetHotTours()
        {
            var tours = _tourRepository.GetMany(o => o.Hot);
            var mapHotTours = _mapper.Map<IEnumerable<Tour>, IEnumerable<TourBL>>(tours);
            return mapHotTours;

        }

        public DataCreateTourBL GetDateCreateTour()
        {
            var tourtypes = _mapper.Map<IEnumerable<TourType>, IEnumerable<TourTypeBL>>(_tourTypeRepository.GetAll());
            var hotels = _mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelBL>>(_hotelRepository.GetAll());
            return new DataCreateTourBL()
            {
                TourTypes = tourtypes,
                Hotels = hotels
            };

        }

        public IEnumerable<TourBL> GetSearchTour(DataFilterBL searchBl)
        {
            var tours = _tourRepository.GetMany(o => (o.Price <= searchBl.Price) && (o.PeopleCount == searchBl.PeopleCount) && (o.TourTypeId == searchBl.TourTypeId) && (o.HotelId == searchBl.HotelTypeId));
            var mapHotTours = _mapper.Map<IEnumerable<Tour>, IEnumerable<TourBL>>(tours);
            return mapHotTours;
        }

        public DataSearchBL GetDataSearch()
        {
            var tourtypes = _mapper.Map<IEnumerable<TourType>, IEnumerable<TourTypeBL>>(_tourTypeRepository.GetAll());
            var hotelType = _mapper.Map<IEnumerable<HotelType>, IEnumerable<HotelTypeBL>>(_hotelTypeRepository.GetAll());
            var peopleCount = _tourRepository.GetAll().Select(x => x.PeopleCount).ToList();
            var minCountPeople = peopleCount.Min();
            var maxCountPeople = peopleCount.Max();
            var priceList = _tourRepository.GetAll().Select(x => x.Price).ToList();
            var minPrice = priceList.Min();
            var maxPrice = priceList.Max();
            return new DataSearchBL()
            {
                TourTypes = tourtypes,
                HotelTypes = hotelType,
                PeopleCountMax = maxCountPeople,
                PeopleCountMin = minCountPeople,
                PriceMax = maxPrice,
                PriceMin = minPrice

            };

        }

        public void DeleteTour(int id)
        {
            _tourRepository.Delete(id);

        }

        public void Update(CreateTourBL tour)
        {
            var tourDB = _tourRepository.GetById(tour.Id);
            tourDB.Hot = tour.Hot;
            tourDB.ArrivalDate = tour.ArrivalDate;
            tourDB.DepartureData = tour.DepartureData;
            tourDB.Name = tour.Name;
            tourDB.PeopleCount = tour.PeopleCount;
            tourDB.Price = tour.Price;
            tourDB.TourTypeId = tour.TourTypeId;
            tourDB.HotelId = tour.HotelId;

            _tourRepository.Update(tourDB);
        }

        public void BookTour(int tourId, int userId)
        {
            var tour = _tourRepository.GetById(tourId);
            if (tour == null)
            {
                throw new ArgumentException("Tour not found");
            }
            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            if (tour.BookedById != null)
            {
                throw new ArgumentException("Tour has been booked");
            }

            tour.BookedBy = user;
            tour.TourState = TourState.Registered;
            _tourRepository.Update(tour);
        }

        public void Paid(int id)
        {
            var tour = _tourRepository.GetById(id);
            var maxUserDiscount = _settingsRepository.GetById(1).MaxUserDiscount;
            tour.TourState = TourState.Paid;
            if (maxUserDiscount<tour.Discount+tour.BookedBy.Discount)
            {
                tour.BookedBy.Discount = maxUserDiscount;
            }
            else
            {
                tour.BookedBy.Discount += tour.Discount;
            }
            _userRepository.Update(tour.BookedBy);
            _tourRepository.Update(tour);

        }

        public void Canceled(int id)
        {
            var tour = _tourRepository.GetById(id);
            tour.TourState = TourState.Canceled;
            _tourRepository.Update(tour);
        }

        public IEnumerable<TourBL> GetAllRegistered()
        {

            var tours = _tourRepository.GetMany(o => o.TourState!=TourState.Active);
            var mapTours = _mapper.Map<IEnumerable<Tour>, IEnumerable<TourBL>>(tours);
            return mapTours;

        }
    }
}