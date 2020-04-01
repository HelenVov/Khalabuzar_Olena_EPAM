using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using TravelAgency.BusinessLogic.Interfaces;
using TravelAgency.BusinessLogic.Service;
using TravelAgency.DataAccess;
using TravelAgency.DataAccess.Interfaces;
using TravelAgency.DataAccess.Models;
using TravelAgency.DataAccess.Repository;
using TravelAgency.Models;

namespace TravelAgency.BusinessLogic.Infrastructure
{
    public class BLAutofacConfig
    {
        public BLAutofacConfig(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(TEntityRepository<>)).As(typeof(IRepository<>));

            builder.RegisterType<TravelAgencyContext>().AsSelf().WithParameter("connectionStringName", "TravelAgency").InstancePerRequest();


            builder.RegisterType<TourService>().As<ITourService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<SettingsService>().As<ISettingsService>();


        }
    }
}
