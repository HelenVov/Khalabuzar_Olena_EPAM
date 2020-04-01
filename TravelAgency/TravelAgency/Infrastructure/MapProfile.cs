using AutoMapper;
using TravelAgency.BusinessLogic.Models;
using TravelAgency.DataAccess.Models;
using TravelAgency.Models;
using TravelAgency.Models.Model;
using TravelAgency.Models.UserModel;

namespace TravelAgency.Infrastructure
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<SettingsBL, SettingsVM>()
                .ForMember(dest => dest.MaxDiscount, opt => opt.MapFrom(srt => srt.MaxDiscount));
            CreateMap<SettingsVM, SettingsBL>()
                .ForMember(dest => dest.MaxDiscount, opt => opt.MapFrom(srt => srt.MaxDiscount));

            CreateMap<RegistrationData, UserBL>()
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(srt => srt.Lastname))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(srt => srt.Firstname))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(srt => srt.Login))
                .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(srt => srt.MobilePhone))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(srt => srt.Password));


            CreateMap<UserBL, UserVM>()
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(srt => srt.LastName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(srt => srt.FirstName))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(srt => srt.Login))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(srt => srt.Id))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
                .ForMember(dest => dest.Block, opt => opt.MapFrom(srt => srt.Block))
                .ForMember(dest => dest.MobilePhone, opt => opt.MapFrom(srt => srt.MobilePhone));


            CreateMap<DataFilterVM, DataFilterBL>()
                .ForMember(dest => dest.TourTypeId, opt => opt.MapFrom(srt => srt.TourTypeId))
                .ForMember(dest => dest.HotelTypeId, opt => opt.MapFrom(srt => srt.HotelTypeId))
                .ForMember(dest => dest.PeopleCount, opt => opt.MapFrom(srt => srt.PeopleCount))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(srt => srt.Price));


            CreateMap<DataSearchBL, FilterVM>()
                .ForMember(dest => dest.HotelTypes, opt => opt.MapFrom(srt => srt.HotelTypes))
                .ForMember(dest => dest.PriceMin, opt => opt.MapFrom(srt => srt.PriceMin))
                .ForMember(dest => dest.PriceMax, opt => opt.MapFrom(srt => srt.PriceMax))
                .ForMember(dest => dest.PeopleCountMin, opt => opt.MapFrom(srt => srt.PeopleCountMin))
                .ForMember(dest => dest.PeopleCountMax, opt => opt.MapFrom(srt => srt.PeopleCountMax))
                .ForMember(dest => dest.TourTypes, opt => opt.MapFrom(srt => srt.TourTypes));


            CreateMap<HotelTypeBL, HotelTypeVM>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(srt => srt.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(srt => srt.Id));


            CreateMap<CreateTourVM, CreateTourBL>()
                .ForMember(dest => dest.TourTypeId, opt => opt.MapFrom(src => src.TourTypeId))
                .ForMember(dest => dest.HotelId, opt => opt.MapFrom(src => src.HotelId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ArrivalDate, opt => opt.MapFrom(src => src.ArrivalDate))
                .ForMember(dest => dest.DepartureData, opt => opt.MapFrom(src => src.DepartureData))
                .ForMember(dest => dest.PeopleCount, opt => opt.MapFrom(src => src.PeopleCount))
                .ForMember(dest => dest.Hot, opt => opt.MapFrom(src => src.Hot))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount));

            CreateMap<TourTypeBL, TourTypeVM>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(srt => srt.Name))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(srt => srt.Id));

            CreateMap<DataCreateTourBL, DataCreatTourVM>()
                .ForMember(dest => dest.Hotels, opt => opt.MapFrom(str => str.Hotels))
                .ForMember(dest => dest.TourTypes, opt => opt.MapFrom(srt => srt.TourTypes));

            CreateMap<HotelAddressBL, HotelAddressVM>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(srt => srt.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(srt => srt.Street))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(srt => srt.Country));     

            CreateMap<HotelBL, HotelVM>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.HotelAddress, opt => opt.MapFrom(src => src.HotelAddress))
                .ForMember(dest => dest.HotelType, opt => opt.MapFrom(src => src.HotelType))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<TourVM, TourBL>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ArrivalDate, opt => opt.MapFrom(src => src.ArrivalDate))
                .ForMember(dest => dest.DepartureData, opt => opt.MapFrom(src => src.DepartureData))
                .ForMember(dest => dest.PeopleCount, opt => opt.MapFrom(src => src.PeopleCount))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.TourType, opt => opt.MapFrom(src => src.TourType))
                .ForMember(dest => dest.Hot, opt => opt.MapFrom(src => src.Hot))
                .ForMember(dest => dest.Hotel, opt => opt.MapFrom(src => src.Hotel))
                .ForMember(dest => dest.BookedBy, opt => opt.MapFrom(src => src.BookedBy))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
                .ForMember(dest => dest.TourState, opt => opt.MapFrom(src => src.TourState));

            CreateMap<HotelAddressVM, HotelAddressBL>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(srt => srt.City))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(srt => srt.Street))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(srt => srt.Country));

            CreateMap<HotelVM, HotelBL>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.HotelAddress, opt => opt.MapFrom(src => src.HotelAddress))
                .ForMember(dest => dest.HotelType, opt => opt.MapFrom(src => src.HotelType));

            CreateMap<TourBL, TourVM>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ArrivalDate, opt => opt.MapFrom(src => src.ArrivalDate))
                .ForMember(dest => dest.DepartureData, opt => opt.MapFrom(src => src.DepartureData))
                .ForMember(dest => dest.PeopleCount, opt => opt.MapFrom(src => src.PeopleCount))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.TourType, opt => opt.MapFrom(src => src.TourType))
                .ForMember(dest => dest.Hot, opt => opt.MapFrom(src => src.Hot))
                .ForMember(dest => dest.Hotel, opt => opt.MapFrom(src => src.Hotel))
                .ForMember(dest => dest.BookedBy, opt => opt.MapFrom(src => src.BookedBy))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
                .ForMember(dest => dest.TourState, opt => opt.MapFrom(src => src.TourState));

        }
    }
}