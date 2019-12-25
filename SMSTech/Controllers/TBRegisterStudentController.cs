using SMSTech.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSTech.Controllers
{
    public class TBRegisterStudentController : Controller
    {
        SMST4MEntities1 db = new SMST4MEntities1();
        public ActionResult Index()
        {
            return View();
        }
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
        public ActionResult Insert(TB_RegisterStudent data)
        {
            //TB_RegisterStudent TBRegisterStudent = new TB_RegisterStudent();
            //TBRegisterStudent.RollNo = data.RollNo;
            //TBRegisterStudent.Class = data.Class;
            //TBRegisterStudent.Name = data.Name;
            //TBRegisterStudent.Section = data.Section;
            //TBRegisterStudent.DOB = data.DOB;
            //TBRegisterStudent.Status = data.Status;
            //TBRegisterStudent.DateOfAdmission = data.DateOfAdmission;
            //TBRegisterStudent.Section = data.Section;
            //TBRegisterStudent.Gender = data.Gender;
            //string path = Session["Imageurl"].ToString();
            //Image img = Image.FromFile(path);
            //MemoryStream tmpStream = new MemoryStream();
            //img.Save(tmpStream, ImageFormat.Png);
            //tmpStream.Seek(0, SeekOrigin.Begin);
            //byte[] imgBytes = new byte[800000];
            //tmpStream.Read(imgBytes, 0, 800000);
            //TBRegisterStudent.Image = imgBytes;
            //db.TB_RegisterStudent.Add(TBRegisterStudent);
            //db.SaveChanges();
            //db.Entry(TBRegisterStudent).State = System.Data.Entity.EntityState.Modified;
            return Json("Saved Successfully");

        }
    }
}