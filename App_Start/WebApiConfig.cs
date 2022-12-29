using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Serialization;    // MVC: 
using Newtonsoft.Json;                  // MVC: 

namespace MVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // MVC: config web api to return json object using camel notation. 
            var jsonSetting = config.Formatters.JsonFormatter.SerializerSettings;
            jsonSetting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonSetting.Formatting = Formatting.Indented;
            

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
