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
    public class ClassLevelsController : Controller
    {
        SMST4MEntities1 db = new SMST4MEntities1();
        //
        // GET: /classLevels/
        ClassLevel ClsLevel = new ClassLevel();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetClassLevel()
        {
            var classlvl = db.ClassLevels.ToList();
            return Json(classlvl,JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddClassLevel()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddClassLevel(ClassLevel clsLevel)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.0.119:3000/");
            var response = client.PostAsJsonAsync("classLevels/AddClassLevel", clsLevel).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Error");
            }
            return View(clsLevel);
        }

	}
}