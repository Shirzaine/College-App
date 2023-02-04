using System;
using System.Collections.Generic;
using ContosoUniversity.ViewModels;
using ContosoUniversity.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.Data;

namespace ContosoUniversity.Controllers
{
    public class HomeController : Controller
    {
        private ContosoUniversityContext db = new ContosoUniversityContext();   

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            IQueryable<EnrollmentDateGroup> data = from student in db.Students
                                                   group student by student.EnrollmentDate into dateGroup
                                                   select new EnrollmentDateGroup()
                                                   {
                                                       EnrollmentDate = dateGroup.Key,
                                                       StudentCount = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }
        protected override void Dispose (bool disposing)
        {
            db.Dispose();
            base.Dispose (disposing);
        }
    }
    
}