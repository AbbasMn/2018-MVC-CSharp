using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // MVC: Disable Cache Page to prevent steal data from be displayed to the user (New added user not shown with caching)      
        [OutputCache(Duration = 0, VaryByParam ="*", NoStore = true)]
        public ActionResult Index()
        {
            return View();
        }


        // MVC: Cache Page
        // VMC: VaryByParam = "EntertainmentType"
        // MVC: VaryByParam ="*" for any combinations of this parameters we have a different version in the cache
        [OutputCache(Duration = 3, Location = System.Web.UI.OutputCacheLocation.Server, VaryByParam = "*")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}