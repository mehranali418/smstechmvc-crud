using SMSTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSTech.Controllers
{
    public class AcademicCourseController : Controller
    {
        SMST4MEntities1 db = new SMST4MEntities1();
        // GET: AcademicCourse
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Academic_Courses data)
        {
            Academic_Courses AcademicCourse = new Academic_Courses();
            AcademicCourse.Name = data.Name;
            AcademicCourse.Duration = data.Duration;
            AcademicCourse.StandardFee = data.StandardFee;
            AcademicCourse.Operator_id = data.Operator_id;
            AcademicCourse.Is_deleted = data.Is_deleted;
            db.Academic_Courses.Add(AcademicCourse);
            db.SaveChanges();
            db.Entry(AcademicCourse).State = System.Data.Entity.EntityState.Modified;
            return Json("Saved Successfully");

        }
    }
}