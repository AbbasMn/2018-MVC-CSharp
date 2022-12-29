using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using MVC.ViewModels;
using System.Runtime.Caching;

namespace MVC.Controllers
{
    public class EntertainmentsController : Controller
    {


        private ApplicationDbContext _context;

        public EntertainmentsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }




        // MVC: GET: Entertainment
        public ActionResult Index()
        {
            // MVC: Data Cache -> only after have done performance profiling and just for displaying data not modifying data.
            if(MemoryCache.Default["Entertainments"] == null)
            {  
                MemoryCache.Default["Entertainments"] = GetEntertainmentFromDatabase();
            }

            EntertainmentListViewModel allIntert = new EntertainmentListViewModel();
            //allIntert.AllEntertainments = GetEntertainmentFromDatabase(); 
            allIntert.AllEntertainments = MemoryCache.Default["Entertainments"] as List<Entertainment>;  //IEnumerable<Entertainment>;

            return View(allIntert);
        }


        private List<Entertainment> GetEntertainmentFromDatabase()
        {
            // MVC: EF goes to database and Ececute Immediately
            var entr = _context.Entertainments.ToList(); 
            return entr;
        }

        public ActionResult Entertainment(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();
            else {
                var enter = _context.Entertainments.SingleOrDefault(e => e.Id==id);
                if (enter == null)
                    return HttpNotFound();
                else
                    return View(enter);
            }
        }

        public ActionResult NewEntertainment()
        {
            return View();
        }
    }
}