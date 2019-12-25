using Newtonsoft.Json.Linq;
using SMSTech.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMSTech.Controllers
{
    public class ExamController : Controller
    {

        SMST4MEntities1 db = new SMST4MEntities1();
        //ExamTests ExamTest = new ExamTests();
        //
        // GET: /ExamTests/
        public ActionResult Index()
        {
            
            return View();
        }

        public JsonResult GetExam()
        {
            var Examtest = db.Exams.ToList();
            return Json(Examtest,JsonRequestBehavior.AllowGet);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Insert(string TestID, string ExamDate, string IsActive, string ShortName)
        {
            Exam ex = new Exam();
            Boolean Active = true;

            ex.TestID = Convert.ToInt32(TestID);
            ex.ExamDate = Convert.ToDateTime(ExamDate);
            ex.IsActive = Active;
            ex.ShortName = ShortName;
            db.Exams.Add(ex);
            db.SaveChanges();
            return Json("Save Successfully", JsonRequestBehavior.AllowGet);
        }
      
	}
}