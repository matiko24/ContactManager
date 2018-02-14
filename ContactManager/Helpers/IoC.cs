using Autofac;
using Autofac.Extras.DynamicProxy;
using ContactManager.Interceptors;
using ContactManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Helpers
{
    public static class IoC
    {
        private static ContainerBuilder builder;

        public static IContainer Container { get; private set; }

        public static void Setup()
        {
            builder = new ContainerBuilder();
            RegisterInterceptors();
            RegisterViewModels();
            Container = builder.Build();
        }

        private static void RegisterViewModels()
        {
            builder.RegisterType<MainViewModel>().EnableClassInterceptors().InterceptedBy(typeof(LoggerInterceptor));
        }

        private static void RegisterInterceptors()
        {
            builder.RegisterType<LoggerInterceptor>();
        }
    }
}
