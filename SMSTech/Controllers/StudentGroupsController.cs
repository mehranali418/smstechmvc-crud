using SMSTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSTech.Controllers
{
    public class StudentGroupsController : Controller
    {
        SMST4MEntities1 db = new SMST4MEntities1();
        //
        // GET: /StudentGroups/
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetStdGrp()
        {
            var stdgrp = db.Student_Groups.ToList();
            return Json(stdgrp,JsonRequestBehavior.AllowGet);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Insert(string Name)
        {
            Student_Groups stdgroups = new Student_Groups();
            stdgroups.Name = Name;
            db.Student_Groups.Add(stdgroups);
            db.SaveChanges();
            return Json("Save Successfully", JsonRequestBehavior.AllowGet);
        }
	}
}