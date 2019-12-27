using CommonServiceLocator;
using eximo.data;
using eximo.data.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.ServiceLocation;

namespace eximo.Services
{
    public class IocContainer
    {

        public IocContainer()
        {
        }


        public static void Initialize()
        {
            //init unity container
            UnityContainer iocContainer = new UnityContainer();
            RegisterServices(iocContainer);
            ResolveServices(iocContainer);
        }

        private static void RegisterServices(UnityContainer iocContainer)
        {
            //register IUserservice for db context
            iocContainer.RegisterType<IUserService, UserService>();
            iocContainer.RegisterType<IPlanService, PlanService>();
            iocContainer.RegisterSingleton<IEncryptionService, EncryptionService>();

            //set service locator provider       
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(iocContainer));
        }

        private static void ResolveServices(UnityContainer iocContainer)
        {
            //reslove classes that are injected
        }
    }
}
