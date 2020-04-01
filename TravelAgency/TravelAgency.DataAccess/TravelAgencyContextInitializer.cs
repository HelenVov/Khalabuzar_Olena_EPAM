using System;
using System.Collections.Generic;
using System.Data.Entity;
using TravelAgency.DataAccess.Models;

namespace TravelAgency.DataAccess
{
    public class TravelAgencyContextInitializer : DropCreateDatabaseAlways<TravelAgencyContext>
    {
        protected override void Seed(TravelAgencyContext context)
        {
            var user = new User()
            {
                FirstName = "Elena",
                LastName = "Khalabuzar",
                Login = "admin",
                Password = "123",
                MobilePhone = "+380958972428",
                UserType = UserType.Admin
            };
            var user1 = new User()
            {
                FirstName = "Nata",
                LastName = "Khalabuzar",
                Login = "manager",
                Password = "123",
                MobilePhone = "+380958971111",
                UserType = UserType.Manager
            };
            var user2 = new User()
            {
                FirstName = "Vov",
                LastName = "Khalabuzar",
                Login = "client",
                Password = "123",
                MobilePhone = "+380958972222",
                UserType = UserType.Client
            };

            context.Users.Add(user);
            context.Users.Add(user1);
            context.Users.Add(user2);

            var hotelAddress = new HotelAddress
            {
                City = "Украина",
                Country = "Одесса",
                Street = "Набережна"
            }; 
            var hotelAddress1 = new HotelAddress
            {
                City = "Украина",
                Country = "Киев",
                Street = "Нижняя"
            }; 
            var hotelAddress2 = new HotelAddress
            {
                City = "Украина",
                Country = "Донецк",
                Street = "Мирная"
            }; 
            var hotelAddress3 = new HotelAddress
            {
                City = "Украина",
                Country = "Харьков",
                Street = "Университет"
            };

            hotelAddress = context.HotelAddresses.Add(hotelAddress);
            hotelAddress = context.HotelAddresses.Add(hotelAddress1);
            hotelAddress = context.HotelAddresses.Add(hotelAddress2);
            hotelAddress = context.HotelAddresses.Add(hotelAddress3);

            var hotelType = new HotelType
            {
                Name = "Хостел"
            };
            var hotelType2 = new HotelType
            {
                Name = "Отель"
            };
            var hotelType3 = new HotelType
            {
                Name = "Гостиница"
            };
            var hotelType4 = new HotelType
            {
                Name = "Апартаменты"
            };
            hotelType = context.HotelTypes.Add(hotelType);
            hotelType2 = context.HotelTypes.Add(hotelType2);
            hotelType3 = context.HotelTypes.Add(hotelType3);
            hotelType4 = context.HotelTypes.Add(hotelType4);


            var hotel = new Hotel
            {
                Name = "Звезда",
                HotelAddress = hotelAddress,
                HotelType = hotelType
            };

            var hotel2 = new Hotel
            {
                Name = "Солнце",
                HotelAddress = hotelAddress,
                HotelType = hotelType2
            };

            var hotel3 = new Hotel
            {
                Name = "Луна",
                HotelAddress = hotelAddress,
                HotelType = hotelType
            };

            var hotel4 = new Hotel
            {
                Name = "Земля",
                HotelAddress = hotelAddress,
                HotelType = hotelType2
            };

            hotel = context.Hotels.Add(hotel);
            hotel2 = context.Hotels.Add(hotel2);

            var tourType = new TourType
            {
                Name = "Шопинг"
            };

            var tourType1 = new TourType
            {
                Name = "Отдых"
            };

            var tourType2 = new TourType
            {
                Name = "Экскурсия"
            };

            var tourType3 = new TourType
            {
                Name = "Горнолыжный"
            };

            tourType = context.TourTypes.Add(tourType);
            tourType1 = context.TourTypes.Add(tourType1);
            tourType2 = context.TourTypes.Add(tourType2);
            tourType3 = context.TourTypes.Add(tourType3);


            var tour = new Tour
            {
                Name = "Звездная жизнь",
                ArrivalDate = new DateTime(2020, 6,10 ),
                DepartureData = new DateTime(2020, 6, 20),
                PeopleCount = 5,
                Price = 6000,
                TourType = tourType1,
                Hotel = hotel
            };
            var tour2 = new Tour
            {
                Name = "Любовь в моих глазах",
                ArrivalDate = new DateTime(2020, 7, 9),
                DepartureData = new DateTime(2020, 7, 15),
                PeopleCount = 2,
                Price = 5000,
                TourType = tourType,
                Hotel = hotel,
                Hot = true

            }; var tour3 = new Tour
            {
                Name = "Берег грая",
                ArrivalDate = new DateTime(2020, 8, 11),
                DepartureData = new DateTime(2020, 8, 20),
                PeopleCount = 7,
                Price = 2000,
                TourType = tourType3,
                Hotel = hotel3
            };
            var tour4 = new Tour
            {
                Name = "Весёлые каникулы",
                ArrivalDate = new DateTime(2020, 7, 1),
                DepartureData = new DateTime(2020, 7, 5),
                PeopleCount = 10,
                Price = 2000,
                TourType = tourType2,
                Hotel = hotel2,
                Hot = true

            };
            context.Tours.Add(tour);
            context.Tours.Add(tour2);
            context.Tours.Add(tour3);
            context.Tours.Add(tour4);

            var max = new Settings()
            {
                MaxUserDiscount = 20
            };

            context.Settings.Add(max);
            context.SaveChanges();




        }
    }
}