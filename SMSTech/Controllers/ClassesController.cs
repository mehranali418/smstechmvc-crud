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
    public class ClassesController : Controller
    {
        SMST4MEntities1 db = new SMST4MEntities1();

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetClasses()
        {
            var Class = db.Classes.ToList();
            return Json(Class, JsonRequestBehavior.AllowGet);
        }




        //Mehrans Data

        public ActionResult Create()
        {
            ViewBag.LevelID = new SelectList(db.Exams_Grade, "ID", "Level_id");
            return View();
        }


        [HttpGet]
        public ActionResult Insert(string Name, string ClassNumber, string LevelID)
        {
            Class cls = new Class();
            cls.Name = Name;
            int ClassNumbers = Convert.ToInt32(ClassNumber);

            int LevelId = Convert.ToInt32(LevelID);
            db.Classes.Add(cls);
            db.SaveChanges();
            return Json("Save Successfully", JsonRequestBehavior.AllowGet);
        }

    }
}