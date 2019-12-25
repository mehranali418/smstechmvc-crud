using SMSTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSTech.Controllers
{
    public class AcademicClassRoutineController : Controller
    {
        SMST4MEntities1 db = new SMST4MEntities1();
        // GET: AcademicClassRoutine
        public ActionResult Index()
        {
            ViewBag.SectionID = new SelectList(db.Students, "ID", "Name");
            ViewBag.UserID = new SelectList(db.Students, "ID", "Name");
            
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Academic_ClassRoutine data)
        {
            Academic_ClassRoutine AcademiclassRoutine = new Academic_ClassRoutine();
            
            AcademiclassRoutine.SectionID= data.SectionID;
            AcademiclassRoutine.UserID = data.UserID;
            AcademiclassRoutine.SubjectID = data.SubjectID;
            AcademiclassRoutine.PeriodID = data.PeriodID;
            AcademiclassRoutine.Status = data.Status;
            db.Academic_ClassRoutine.Add(AcademiclassRoutine);
            db.SaveChanges();
            db.Entry(AcademiclassRoutine).State = System.Data.Entity.EntityState.Modified;
            return Json("Saved Successfully");

        }
    }
}