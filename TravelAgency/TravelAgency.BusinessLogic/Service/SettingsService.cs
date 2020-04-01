using TravelAgency.BusinessLogic.Interfaces;
using TravelAgency.BusinessLogic.Models;
using TravelAgency.DataAccess.Interfaces;
using TravelAgency.DataAccess.Models;

namespace TravelAgency.BusinessLogic.Service
{
    public class SettingsService : ISettingsService
    {
        readonly private IRepository<Settings> _repository;

        public SettingsService(IRepository<Settings> repository)
        {
            _repository = repository;
        }

        public void Update(SettingsBL settingsBl)
        {
            var set = _repository.GetById(1);
            set.MaxUserDiscount=settingsBl.MaxDiscount;
            _repository.Update(set);

        }
    }
}