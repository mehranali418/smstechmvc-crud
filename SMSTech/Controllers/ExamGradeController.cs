using SMSTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSTech.Controllers
{
    public class ExamGradeController : Controller
    {
        SMST4MEntities1 db = new SMST4MEntities1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Insert(string Percentage_from,string Percentage_to, string Grade_letters, string Level_id)
        {
            Exams_Grade examgrade = new Exams_Grade();

            examgrade.Percentage_from = Convert.ToInt32(Percentage_from);
            examgrade.Percentage_to = Convert.ToInt32(Percentage_to);
            examgrade.Grade_letters = Grade_letters;
            examgrade.Level_id = Convert.ToInt32(Level_id);
            db.Exams_Grade.Add(examgrade);
            db.SaveChanges();
            return Json("Save Successfully", JsonRequestBehavior.AllowGet);
        }
    }
}