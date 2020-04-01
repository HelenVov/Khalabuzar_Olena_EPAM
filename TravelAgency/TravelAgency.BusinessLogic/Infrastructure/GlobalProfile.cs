using AutoMapper;
using TravelAgency.BusinessLogic.Models;
using TravelAgency.DataAccess.Models;
using TravelAgency.Models;

namespace TravelAgency.BusinessLogic.Infrastructure
{
    public class GlobalProfile : Profile
    {
        public GlobalProfile()
        {
            CreateMap<Settings, SettingsBL>()
                .ForMember(dest => dest.MaxDiscount, opt => opt.MapFrom(srt => srt.MaxUserDiscount));



            CreateMap<User, UserBL>()
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(srt => srt.LastName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(srt => srt.FirstName))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(srt => srt.Login))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(srt => srt.Id))
                .ForMember(dest => dest.Block, opt => opt.MapFrom(srt => srt.Block))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
                .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(srt => srt.MobilePhone));
         
            CreateMap<UserBL, User>()
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(srt => srt.LastName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(srt => srt.FirstName))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(srt => srt.Login))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(srt => srt.Id))
                .ForMember(dest => dest.Block, opt => opt.MapFrom(srt => srt.Block))
                .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(srt => srt.MobilePhone))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(srt => srt.Password));



            CreateMap<HotelType, HotelTypeBL>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(srt => srt.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(srt => srt.Id));


            CreateMap<CreateTourBL, Tour>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ArrivalDate, opt => opt.MapFrom(src => src.ArrivalDate))
                .ForMember(dest => dest.DepartureData, opt => opt.MapFrom(src => src.DepartureData))
                .ForMember(dest => dest.PeopleCount, opt => opt.MapFrom(src => src.PeopleCount))
                .ForMember(dest => dest.Hot, opt => opt.MapFrom(src => src.Hot))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            CreateMap<TourType, TourTypeBL>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(srt => srt.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(srt => srt.Id));


            CreateMap<HotelAddress, HotelAddressBL>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(srt => srt.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(srt => srt.Street))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(srt => srt.Country));
            
            CreateMap<Hotel, HotelBL>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.HotelAddress, opt => opt.MapFrom(src => src.HotelAddress))
                .ForMember(dest => dest.HotelType, opt => opt.MapFrom(src => src.HotelType.Name));

            CreateMap<Tour, TourBL>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ArrivalDate, opt => opt.MapFrom(src => src.ArrivalDate))
                .ForMember(dest => dest.DepartureData, opt => opt.MapFrom(src => src.DepartureData))
                .ForMember(dest => dest.PeopleCount, opt => opt.MapFrom(src => src.PeopleCount))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.TourType, opt => opt.MapFrom(src => src.TourType.Name))
                .ForMember(dest => dest.Hotel, opt => opt.MapFrom(src => src.Hotel))
                .ForMember(dest => dest.Hot, opt => opt.MapFrom(src => src.Hot))
                .ForMember(dest => dest.BookedBy, opt => opt.MapFrom(src => src.BookedBy))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
                .ForMember(dest => dest.TourState, opt => opt.MapFrom(src => src.TourState));
           
            CreateMap<TourTypeBL, TourType>()
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(srt => srt.Name));


            CreateMap<HotelAddressBL, HotelAddress>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(srt => srt.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(srt => srt.Street))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(srt => srt.Country));

            CreateMap<HotelBL, Hotel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.HotelAddress, opt => opt.MapFrom(src => src.HotelAddress))
                .ForPath(dest => dest.HotelType.Name, opt => opt.MapFrom(src => src.HotelType));

            CreateMap<TourBL, Tour>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ArrivalDate, opt => opt.MapFrom(src => src.ArrivalDate))
                .ForMember(dest => dest.DepartureData, opt => opt.MapFrom(src => src.DepartureData))
                .ForMember(dest => dest.PeopleCount, opt => opt.MapFrom(src => src.PeopleCount))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForPath(dest => dest.TourType.Name, opt => opt.MapFrom(src => src.TourType))
                .ForPath(dest => dest.Hot, opt => opt.MapFrom(src => src.Hot))
                .ForMember(dest => dest.Hotel, opt => opt.MapFrom(src => src.Hotel))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
                .ForMember(dest => dest.TourState, opt => opt.MapFrom(src => src.TourState));

        }
    }
}