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
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

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
            ViewBag.SectionList = new SelectList(db.Sections, "Name", "Name");
            ViewBag.ReligionList = new SelectList(db.Religions, "Name", "Name");
            ViewBag.NationalityList = new SelectList(db.Nationalities, "Name", "Name");

            return View();
        }



        public ActionResult Create()
        {
            ViewBag.ReligionID = new SelectList(db.Religions, "ID", "Name");
            ViewBag.NationalityID = new SelectList(db.Nationalities, "ID", "Name");
            ViewBag.SectionID = new SelectList(db.Sections, "ID", "Name");
            ViewBag.UserID = new SelectList(db.Users, "ID", "Name");
            ViewBag.StuGroupID = new SelectList(db.Student_Groups, "ID", "Name");
            ViewBag.Status = new SelectList(db.Users, "ID", "Name");
            return View();
        }



        
        //Ajax Methods

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
                              ID = stu.ID,
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
                              ID = stu.ID,
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


        public JsonResult GetSectionDrop(string Secname)
        {
            var Result = (from stu in db.Students
                          join cls in db.Classes on stu.JoiningClassID equals cls.ID
                          join sec in db.Sections on stu.SectionID equals sec.ID
                          join usr in db.Users on stu.UserID equals usr.ID
                          join Famid in db.Student_Family on stu.FamilyID equals Famid.ID
                          join nation in db.Nationalities on stu.NationalityID equals nation.ID
                          join relig in db.Religions on stu.ReligionID equals relig.ID
                          join stdgrp in db.Student_Groups on stu.StuGroupID equals stdgrp.ID
                          where sec.Name == Secname
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


        public JsonResult GetReligionDrop(string Religion)
        {
            var Result = (from stu in db.Students
                          join cls in db.Classes on stu.JoiningClassID equals cls.ID
                          join sec in db.Sections on stu.SectionID equals sec.ID
                          join usr in db.Users on stu.UserID equals usr.ID
                          join Famid in db.Student_Family on stu.FamilyID equals Famid.ID
                          join nation in db.Nationalities on stu.NationalityID equals nation.ID
                          join relig in db.Religions on stu.ReligionID equals relig.ID
                          join stdgrp in db.Student_Groups on stu.StuGroupID equals stdgrp.ID
                          where relig.Name == Religion
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


        public JsonResult GetNationalityDrop(string Nationality)
        {
            var Result = (from stu in db.Students
                          join cls in db.Classes on stu.JoiningClassID equals cls.ID
                          join sec in db.Sections on stu.SectionID equals sec.ID
                          join usr in db.Users on stu.UserID equals usr.ID
                          join Famid in db.Student_Family on stu.FamilyID equals Famid.ID
                          join nation in db.Nationalities on stu.NationalityID equals nation.ID
                          join relig in db.Religions on stu.ReligionID equals relig.ID
                          join stdgrp in db.Student_Groups on stu.StuGroupID equals stdgrp.ID
                          where nation.Name == Nationality
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

        


        //MehranData
        [HttpPost]
        public void Upload()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/"), fileName);
                file.SaveAs(path);
                Session["Imageurl"] = path;

            }

        }
        [HttpPost]
        public ActionResult Insert(Student data)
        {


            Student st = new Student();
            st.SectionID = data.SectionID;
            st.UserID = data.UserID;
            st.StuCNIC = data.StuCNIC;
            st.Status = data.Status;
            st.sDate = data.sDate;
            st.RollNo = data.RollNo;
            st.ReligionID = data.ReligionID;
            st.registration_no = data.registration_no;
            st.NationalityID = data.NationalityID;
            st.Name = data.Name;
            st.JoiningClassID = data.JoiningClassID;
            st.LeavingDate = data.LeavingDate;
            st.StuGroupID = data.StuGroupID;
            st.Gender = data.Gender;
            st.Email = data.Email;
            st.BirthDate = data.BirthDate;
            st.FamilyID = data.FamilyID;
            string path = Session["Imageurl"].ToString();
            Image img = Image.FromFile(path);
            MemoryStream tmpStream = new MemoryStream();
            img.Save(tmpStream, ImageFormat.Png);
            tmpStream.Seek(0, SeekOrigin.Begin);
            byte[] imgBytes = new byte[800000];
            tmpStream.Read(imgBytes, 0, 800000);
            st.image = imgBytes;
            db.Students.Add(st);
            db.SaveChanges();
            db.Entry(st).State = System.Data.Entity.EntityState.Modified;
            return Json("Saved Successfully");

        }


       


    }

}