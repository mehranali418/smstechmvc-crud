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
    public class StudentGuardianRelationController : Controller
    {
        SMST4MEntities1 db = new SMST4MEntities1();
        Student_Guardians stdGuardian = new Student_Guardians();

        //
        // GET: /StudentGuardians/
        public ActionResult Index()
        {
           
            return View();
        }

        public JsonResult Action()
        {
            var stdGuardian = db.Student_Guardians.ToList();
            return Json(stdGuardian,JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddStudentGuardians()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudentGuardians(Student_Guardians stdGuardian)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.0.119:3000/");
            var response = client.PostAsJsonAsync("studentGuardian/AddStudentGuardians", stdGuardian).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Error");
            }
            return View(stdGuardian);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Insert(string StudentID, string GuardianID, string RelationID)
        {
            Student_Guardian_Relation sgr = new Student_Guardian_Relation();

            sgr.StudentID = Convert.ToInt32(StudentID);
            sgr.GuardianID = Convert.ToInt32(GuardianID);
            sgr.RelationID = Convert.ToInt32(RelationID);
            db.Student_Guardian_Relation.Add(sgr);
            db.SaveChanges();
            return Json("Save Successfully", JsonRequestBehavior.AllowGet);
        }
    }
}