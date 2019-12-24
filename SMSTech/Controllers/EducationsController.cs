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

        [HttpPost]
        public ActionResult AddEducation(Education e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.0.119:3000/");
            var response = client.PostAsJsonAsync("Educations/AddEducation", e).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Error");
            }
            return View(e);
        }
        [HttpPut]
        public ActionResult Edit(int ID)
        {
            Education edu = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.0.119:3000/");
                //HTTP GET
                var responseTask = client.GetAsync("Educations?ID=" + ID.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Education>();
                    readTask.Wait();
                    edu = readTask.Result;
                }
            }

            return View(edu);
        }
        public ActionResult Edit()
        {
            return View();
        }

	}
}