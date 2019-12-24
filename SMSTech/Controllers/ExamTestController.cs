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
    public class ExamTestController : Controller
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
      
	}
}