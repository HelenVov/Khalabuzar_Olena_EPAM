namespace TravelAgency.Models.Model
{
    public class ModificationTourVM
    {
        public DataCreatTourVM DataCreated { get; set; }

        public TourVM TourVm { get; set; }

        public int Id { get; set; }

        public int CountTour { get; set; }
    }
}