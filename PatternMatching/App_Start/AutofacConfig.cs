using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using PatternMatching.AutoConfig;
using PatternMatching.Services;

namespace PatternMatching.App_Start
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var containerBuilder = new ContainerBuilder();
            var globalconfig = GlobalConfiguration.Configuration;
            containerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            RegisterServices(containerBuilder);
            containerBuilder.RegisterWebApiFilterProvider(globalconfig);
            containerBuilder.RegisterWebApiModelBinderProvider();
            var container = containerBuilder.Build();
            globalconfig.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterServices(ContainerBuilder containerBuilder)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MatchedPatternProfile());
            });

            containerBuilder.RegisterInstance(config.CreateMapper()).As<IMapper>().SingleInstance();
                        
            containerBuilder.RegisterType<PatternMatchService>()
              .As<IPatternMatchService>()
              .InstancePerRequest();
        }
    }
}