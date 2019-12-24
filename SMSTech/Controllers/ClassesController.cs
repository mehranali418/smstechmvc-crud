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

        //public ActionResult AddClasses()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult AddClasses(Classes Class)
        //{
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri("http://192.168.0.119:3000/");
        //    var response = client.PostAsJsonAsync("classes/AddClasses", Class).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        Console.Write("Success");
        //    }
        //    else
        //    {
        //        Console.Write("Error");
        //    }
        //    return View(Class);
        //}

    }
}