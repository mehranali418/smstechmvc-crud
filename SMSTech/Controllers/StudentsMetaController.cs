using SMSTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSTech.Controllers
{
    public class StudentsMetaController : Controller
    {
        SMST4MEntities1 db = new SMST4MEntities1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Insert(string StudentID, string KeyName,string KeyValue)
        {
            StudentsMeta sm = new StudentsMeta();

            sm.StudentID = Convert.ToInt32(StudentID);
            sm.KeyName = KeyName;
            sm.KeyValue = KeyValue;
            db.StudentsMetas.Add(sm);
            db.SaveChanges();
            return Json("Save Successfully", JsonRequestBehavior.AllowGet);
        }
    }
}