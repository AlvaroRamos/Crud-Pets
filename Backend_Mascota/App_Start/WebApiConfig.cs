using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Backend_Mascota
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // habilitamos las cors
            config.EnableCors();
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //XML a Json Formatter
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings
                .Add(new System.Net.Http.Formatting.RequestHeaderMapping("Accept",
                    "text/html", StringComparison.InvariantCultureIgnoreCase,true,
                        "application/json")
            );
        }
    }
}
