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
    public class EducationsController : Controller
    {
        
        SMST4MEntities1 db = new SMST4MEntities1();
        //
        // GET: /Educations/
        public ActionResult Index()
        {           
            return View();
        }

        public JsonResult GetClassLevel()
        {
            var education = db.Educations.ToList();
            return Json(education,JsonRequestBehavior.AllowGet);
        }

       //mehran data

        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Insert(string Name)
        {
            Education ed = new Education();
            ed.Name = Name;
            db.Educations.Add(ed);
            db.SaveChanges();
            return Json("Save Successfully", JsonRequestBehavior.AllowGet);
        }

	}
}