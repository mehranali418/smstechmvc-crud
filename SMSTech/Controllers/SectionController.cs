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
    public class SectionController : Controller
    {
        SMST4MEntities1 db = new SMST4MEntities1();
        //
        // GET: /Section/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetSections()
        {
            var Section = db.Sections.ToList();
            return Json(Section, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddSection()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSection(Section Sec)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.0.119:3000/");
            var response = client.PostAsJsonAsync("section/AddSection", Sec).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Error");
            }
            return View(Sec);
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Insert(string Name, string ClassID)
        {
            Section section = new Section();
            section.Name = Name;
            section.ClassID = Convert.ToInt32(ClassID);
            db.Sections.Add(section);
            db.SaveChanges();
            return Json("Save Successfully", JsonRequestBehavior.AllowGet);
        }

	}
}

