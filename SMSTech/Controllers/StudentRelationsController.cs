using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMSTech.Models;
using System.Net.Http;

namespace SMSTech.Controllers
{
    public class StudentRelationsController : Controller
    {
        SMST4MEntities1 db = new SMST4MEntities1();
        //
        // GET: /StudentRelations/
        Student_Relations SRelation = new Student_Relations();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Action()
        {
            var StdRelations = db.Student_Guardian_Relation.ToList();
            return Json(StdRelations,JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult AddRelations()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddRelations(Student_Relations SRelation)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.0.119:3000/");
            var response = client.PostAsJsonAsync("studentRelation/AddRelations", SRelation).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Error");
            }
            return View(SRelation);
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Insert(string Name)
        {
            Student_Relations std = new Student_Relations();
            std.Name = Name;
            db.Student_Relations.Add(std);
            db.SaveChanges();
            return Json("Save Successfully", JsonRequestBehavior.AllowGet);
        }
	}
}