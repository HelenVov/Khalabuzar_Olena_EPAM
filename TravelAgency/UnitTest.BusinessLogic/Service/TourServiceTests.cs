using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Moq;
using NUnit.Framework;
using TravelAgency.BusinessLogic.Models;
using TravelAgency.BusinessLogic.Service;
using TravelAgency.DataAccess.Interfaces;
using TravelAgency.DataAccess.Models;

namespace UnitTest.BusinessLogic.Service
{
    [TestFixture]
    public class TourServiceTests
    {
        private TourService _tourService;
        private Mock<IRepository<Tour>> _tourRepositoryMock;
        private Mock<IRepository<Hotel>> _hotelRepositoryMock;
        private Mock< IRepository<HotelType>> _hotelTypeRepositoryMock;
        private Mock< IRepository<TourType>> _tourTypeRepositoryMock;
        private Mock< IRepository<User>> _userRepositoryMock;
        private Mock< IRepository<Settings>> _settingsRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void SetUp()
        {
            _tourRepositoryMock=new Mock<IRepository<Tour>>();
            _hotelRepositoryMock = new Mock<IRepository<Hotel>>();
             _hotelTypeRepositoryMock= new Mock<IRepository<HotelType>>();
            _tourTypeRepositoryMock= new Mock<IRepository<TourType>>(); 
           _userRepositoryMock= new Mock<IRepository<User>>(); 
           _settingsRepositoryMock= new Mock<IRepository<Settings>>(); 
           _mapperMock=new Mock<IMapper>();

         _tourService=new TourService(
             _tourRepositoryMock.Object,
             _mapperMock.Object,
             _hotelRepositoryMock.Object,
             _tourTypeRepositoryMock.Object,
             _hotelTypeRepositoryMock.Object,
             _userRepositoryMock.Object,
             _settingsRepositoryMock.Object);
         
            
        }

        [Test]
        public void GetTours_ShouldReturnAllTours()
        {
            _tourRepositoryMock.Setup(x=>x.GetAll(It.IsAny<int?>(),It.IsAny<int?>()))
                .Returns(new List<Tour>{new Tour(),new Tour()});
            _mapperMock.Setup(x => x.Map<IEnumerable<Tour>, IEnumerable<TourBL>>(It.IsAny<IEnumerable<Tour>>()))
                .Returns(new List<TourBL>{new TourBL(),new TourBL()});

            var result = _tourService.GetTours();

            Assert.AreEqual(2,result.Count());
        }


    }
}