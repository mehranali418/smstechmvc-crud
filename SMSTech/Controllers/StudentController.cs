using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSTech.Models;
using System.Data.SqlClient;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json.Linq;

namespace SMSTech.Controllers
{
    public class StudentController : Controller
    {

        SMST4MEntities1 db = new SMST4MEntities1();
        string roll;
        //
        // GET: /Student/
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.ClassList = new SelectList(db.Classes, "Name", "Name");
            ViewBag.SectionList = new SelectList(db.Sections, "ID", "Name");
            ViewBag.ReligionList = new SelectList(db.Religions, "ID", "Name");
            ViewBag.NationalityList = new SelectList(db.Nationalities, "ID", "Name");

            return View();
        }


        public JsonResult GetStudents()
        {
                var Result = (from stu in db.Students
                          join cls in db.Classes on stu.JoiningClassID equals cls.ID
                          join sec in db.Sections on stu.SectionID equals sec.ID
                          join usr in db.Users on stu.UserID equals usr.ID
                          join Famid in db.Student_Family on stu.FamilyID equals Famid.ID
                          join nation in db.Nationalities on stu.NationalityID equals nation.ID
                          join relig in db.Religions on stu.ReligionID equals relig.ID
                          join stdgrp in db.Student_Groups on stu.StuGroupID equals stdgrp.ID
                          select new
                          {
                              ID = cls.ID,
                              SectionID = sec.Name,
                              UserID = usr.Name,
                              RollNo = stu.RollNo,
                              Name = stu.Name,
                              sDate = stu.sDate,
                              Status = stu.Status,
                              image = stu.image,
                              BirthDate = stu.BirthDate,
                              StuCNIC = stu.StuCNIC,
                              FamilyID = Famid.FatherName,
                              Gender = stu.Gender,
                              JoiningClassID = cls.Name,
                              LeavingDate = stu.LeavingDate,
                              registration_no = stu.registration_no,
                              NationalityID = nation.Name,
                              ReligionID = relig.Name,
                              Email = stu.Email,
                              StuGroupID = stdgrp.Name
                          }).ToList();  
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetClassesDrop(string clsname)
        {
            var Result = (from stu in db.Students
                          join cls in db.Classes on stu.JoiningClassID equals cls.ID
                          join sec in db.Sections on stu.SectionID equals sec.ID
                          join usr in db.Users on stu.UserID equals usr.ID
                          join Famid in db.Student_Family on stu.FamilyID equals Famid.ID
                          join nation in db.Nationalities on stu.NationalityID equals nation.ID
                          join relig in db.Religions on stu.ReligionID equals relig.ID
                          join stdgrp in db.Student_Groups on stu.StuGroupID equals stdgrp.ID
                          where cls.Name == clsname
                          select new
                          {
                              ID = cls.ID,
                              SectionID = sec.Name,
                              UserID = usr.Name,
                              RollNo = stu.RollNo,
                              Name = stu.Name,
                              sDate = stu.sDate,
                              Status = stu.Status,
                              image = stu.image,
                              BirthDate = stu.BirthDate,
                              StuCNIC = stu.StuCNIC,
                              FamilyID = Famid.FatherName,
                              Gender = stu.Gender,
                              JoiningClassID = cls.Name,
                              LeavingDate = stu.LeavingDate,
                              registration_no = stu.registration_no,
                              NationalityID = nation.Name,
                              ReligionID = relig.Name,
                              Email = stu.Email,
                              StuGroupID = stdgrp.Name
                          }).ToList();  
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSearchingData(string RollNo)
        {
            var Stud = db.Students.Where(x => x.RollNo == RollNo).ToList();

            return Json(Stud, JsonRequestBehavior.AllowGet);

        }


        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student Stud)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.0.119:3000/");
            var response = client.PostAsJsonAsync("student/AddStudent", Stud).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Error");
            }
            return View(Stud);
        }

        public ActionResult AdmissionForm()
        {
            return View();
        }

    }

}