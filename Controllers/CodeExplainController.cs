using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CodeExplainController : Controller
    {
        // GET: CodeExplain
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page send ViewBag.Message.";
            return View();
        }



        // GET: /CodeExplain/Browse?genre=Disco -> without Route-> Query string parameter: ?genre must has exactly the same 
        // parameter name defined inmethod: Browse(string genre)
        [Route("CodeExplain/Browse/{genre}")] // With Route-> http://localhost:53054/CodeExplain/Browse/dram
        public string Browse(string genre)
        {
            string message =
            HttpUtility.HtmlEncode("Store.Browse, Genre = " + genre);
            return message;
        }        
        //HTML Encoding User Input
        //We're using the HttpUtility.HtmlEncode utility method to
        //sanitize the user input.This prevents users from injecting
        //JavaScript code or HTML markup into our view with a link like
        ///Store/Browse? Genre =
        //< script > window.location = 'http://hacker.example.com' </ script >.

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////
        /// </summary>

        [Route("CodeExplain/ShowActionTypes")] //http://localhost:53054/CodeExplain/ShowActionTypes
        public ActionResult ActionTypes()
        {
            var ent = new Models.Entertainment() { Name = "Content", State = "Texas", City = "Austin", Description = "Content" };
            //return View(ent);
            //return Content("AAAAAAAAAAAAAAAA");
            return HttpNotFound("AAAAAAAAAAAAAAAA");
            //return new EmptyResult();
            //return RedirectToAction("Index","Home",new { page=1 , sortBy="name" });  // MVC: new { page=1 , sortBy="name" } is parametered in address bar
        }


        [Route("CodeExplain/EditSelectedEntertainment/{id?}")]
        public ActionResult EditEntertainment(int? id)
        {

            if (!id.HasValue)
                return Content("id is not entered");
            else
                return Content("id=" + id);

            // Parameter embeded in URL              // MVC: http://localhost:53054/CodeExplain/EditSelectedEntertainment/5

            // Parameter embeded in QueryString      // MVC: http://localhost:53054/CodeExplain/EditSelectedEntertainment?id=41  
        }

        // MVC: code snippet =>  type: mvcaction4 + Tab

        [Route("CodeExplain/ShowSelectedEntertainmentLocation/{state:alpha:minlength(2):maxlength(2)?}/{city?}")]
        public ActionResult ByAddress(string state, string city)  // MVC: Use Custom Route defined in App_Start Folder -> in RouteConfig.cs
        {

            string inState = "Unknown State", inCity = "nknown City";

            if (state != null)
                inState = state;

            if (city != null)
                inCity = city;

            return Content("Entertainment is Located in:" + inState + ", " + inCity);      // MVC: http://localhost:53054/CodeExplain/ShowSelectedEntertainmentLocation/TX/Austin  

        }


        [Route("CodeExplain/detected/{year:regex(\\d{4}):range(2000,2020)}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByDetectedDate(int year, byte month)
        {
            return Content("Build in: " + year + "/" + month);
            // MVC: http://localhost:53054/CodeExplain/detected/2019/05  
            // MVC: Constraint: 4 digit for year, 2 digit for month is defined in App_Start Folder -> in RouteConfig.cs
        }



        public ActionResult SendParameter(int? pageIndex, string sortBy)   // MVC: Define optional parameter with Nullable (?), string type is Nullable by default
        {

            if (!pageIndex.HasValue)
                pageIndex = -1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "is Null";
            return Content(string.Format("PageIndex={0} and sort by={1}", pageIndex, sortBy));

            // MVC: http://localhost:53054/CodeExplain/SendParameter
            // MVC: http://localhost:53054/CodeExplain/SendParameter?pageIndex=5
            // MVC: http://localhost:53054/CodeExplain/SendParameter?pageIndex=5&sortBy=Family

            // MVC: We can't embed parameters in url in this case, need to coustom route !!!
        }
    }
}