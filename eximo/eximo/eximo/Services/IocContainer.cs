using CommonServiceLocator;
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
        }

        private static void RegisterServices(UnityContainer iocContainer)
        {
            //iocContainer.RegisterType<InterfaceHere, ClassImplementingInterface>();


            //set service locator provider       
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(iocContainer));
        }
    }
}
