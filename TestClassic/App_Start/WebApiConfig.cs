using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TestClassic
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.UseXmlSerializer = true;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
