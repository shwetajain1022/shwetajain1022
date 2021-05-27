using AutoMapper;
using Newtonsoft.Json.Serialization;
using PatternMatching.ActionFilter;
using PatternMatching.App_Start;
using PatternMatching.DTO;
using PatternMatching.Extensions;
using PatternMatching.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PatternMatching
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            AutofacConfig.Register();

            config.Filters.Add(new ValidateModelStateFilter());

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
        }
    }
}
