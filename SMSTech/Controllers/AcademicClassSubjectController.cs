using SMSTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSTech.Controllers
{
    public class AcademicClassSubjectController : Controller
    {
        SMST4MEntities1 db = new SMST4MEntities1();
        // GET: AcademicClassSubject
        public ActionResult Index()
        {
            ViewBag.SectionID = new SelectList(db.Students, "ID", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Academic_ClassSubjects data)
        {
            Academic_ClassSubjects Academicclasssubjects = new Academic_ClassSubjects();
            Academicclasssubjects.SectionID = data.SectionID;
            Academicclasssubjects.SubjectID = data.SubjectID;
            Academicclasssubjects.SubjectNumber = data.SubjectNumber;         
            Academicclasssubjects.TotalMarks = data.TotalMarks;
            Academicclasssubjects.PassingMarks = data.PassingMarks;
            db.Academic_ClassSubjects.Add(Academicclasssubjects);
            db.SaveChanges();
            db.Entry(Academicclasssubjects).State = System.Data.Entity.EntityState.Modified;
            return Json("Saved Successfully");

        }
    }
}