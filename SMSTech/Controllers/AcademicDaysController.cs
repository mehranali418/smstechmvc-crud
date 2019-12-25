using SMSTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSTech.Controllers
{
    public class AcademicDaysController : Controller
    {
        SMST4MEntities1 db = new SMST4MEntities1();
        // GET: AcademicDays
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Academic_Days data)
        {
            Academic_Days AcademicDays = new Academic_Days();
            AcademicDays.Name = data.Name;
            AcademicDays.Holyday = data.Holyday;
            AcademicDays.DayNumber = data.DayNumber;         
            db.Academic_Days.Add(AcademicDays);
            db.SaveChanges();
            db.Entry(AcademicDays).State = System.Data.Entity.EntityState.Modified;
            return Json("Saved Successfully");
        }
    }
}