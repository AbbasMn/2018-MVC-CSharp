using System.Web;
using System.Web.Mvc;

namespace MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // MVC: Apply authorization globally on all project
            filters.Add(new AuthorizeAttribute());


            // MVC: web site just available on https channel and no more available on http address (channel)
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
