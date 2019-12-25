using SMSTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSTech.Controllers
{
    public class AcademicCourseStudentController : Controller
    {
        SMST4MEntities1 db = new SMST4MEntities1();
        // GET: AcademicCourseStudent
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Academic_CourseStudents data)
        {
            Academic_CourseStudents AcademicCourseStudents = new Academic_CourseStudents();
            AcademicCourseStudents.Student_id = data.Student_id;
            AcademicCourseStudents.Course_id = data.Course_id;
            AcademicCourseStudents.DecidedFee = data.DecidedFee;
            AcademicCourseStudents.StartDate = data.StartDate;
            AcademicCourseStudents.Duration = data.Duration;
            db.Academic_CourseStudents.Add(AcademicCourseStudents);
            db.SaveChanges();
            db.Entry(AcademicCourseStudents).State = System.Data.Entity.EntityState.Modified;
            return Json("Saved Successfully");
        }
    }
}