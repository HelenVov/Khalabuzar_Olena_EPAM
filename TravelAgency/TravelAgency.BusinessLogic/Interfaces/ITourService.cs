using System.Collections.Generic;
using TravelAgency.BusinessLogic.Models;
using TravelAgency.DataAccess.Models;

namespace TravelAgency.BusinessLogic.Interfaces
{
    public interface ITourService
    {
        IEnumerable<TourBL> GetTours();

        TourBL GetTour(int id);

        IEnumerable<TourBL> GetHotTours();

        TourBL AddTour(CreateTourBL tourBL);

        DataCreateTourBL GetDateCreateTour();

        DataSearchBL GetDataSearch();

        IEnumerable<TourBL> GetSearchTour(DataFilterBL searchBl);

        void DeleteTour(int id);

        void Update(CreateTourBL tour);
        void BookTour(int tourId, int userId);
        void Paid(int id);
        void Canceled(int id);
      IEnumerable<TourBL> GetAllRegistered();
    }
}