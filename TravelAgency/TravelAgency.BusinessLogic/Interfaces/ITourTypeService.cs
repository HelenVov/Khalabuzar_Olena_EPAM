using System.Collections.Generic;
using TravelAgency.DataAccess.Models;

namespace TravelAgency.Models
{
    public interface ITourTypeService
    {
        IEnumerable<TourTypeBL> GetTourTypes();

        TourType GetTourType(int id);
    }
}
