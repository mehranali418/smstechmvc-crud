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
    public class ReligionController : Controller
    {
        SMST4MEntities1 db = new SMST4MEntities1();

        //
        // GET: /Religions/
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetReligion()
        {
            var Religion = db.Religions.ToList();
            return Json(Religion, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddReligions()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddReligions(Religion Rel)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.0.119:3000/");
            var response = client.PostAsJsonAsync("religion/Addreligions", Rel).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Error");
            }
            return View(Rel);
        }
	}
}