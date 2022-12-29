using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Activ Attribute Routing

            routes.MapMvcAttributeRoutes();

            #region DefineActionRoutes=>MoveThisCodeToControllerWithAttributeRoutes

            // MVC: Define routes from most specific to most generic !
            // routes.MapRoute(
            // "AttractionByAddress",
            // "attraction/location/{state}/{city}",
            // new { Controller="Attraction", Action= "ByAddress"},
            // new { state = @"TX|CA", city = @"Austin|Irvine" });        // MVC: http://localhost:53054/Attraction/location/Texas/Austin
            // MVC: Constraint: state should be TX or CA
            // MVC: Constraint: city should be Austin or Irvine

            // routes.MapRoute(
            // "AttractionByDitectedDate",
            // "attraction/detected/{year}/{month}",
            // new { Controller="Attraction", Action= "ByDetectedDate" },
            // new { year=@"\d{4}", month=@"\d{2}"});                            // MVC: http://localhost:53054/Attraction/detected/2019/5
            // MVC: Constraint: 4 digit for year, 2 digit for month

            #endregion



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
