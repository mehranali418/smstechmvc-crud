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
        //
        // GET: /Student/
        [HttpGet]
        public ActionResult Index(int? ByID)
        {

            Student Stud = new Student();
            DataTable dt = new DataTable();

            using (WebClient webClient = new System.Net.WebClient())
            {
                string url;

                if (ByID == null)
                {
                    //url = null;
                    url = "http://192.168.0.119:3000/student";
                }
                else
                {
                    //url = null;
                    url = "http://192.168.0.119:3000/student/" + ByID.ToString();
                }

                var json = webClient.DownloadString(url);
                JArray jsonArray = JArray.Parse(json);
                int lenght = jsonArray.Count;
                dynamic data;

                dt.Columns.Add("ID");
                dt.Columns.Add("SectionID");
                dt.Columns.Add("UserID");
                dt.Columns.Add("RollNo");
                dt.Columns.Add("Name");
                dt.Columns.Add("sDate");
                dt.Columns.Add("Status");
                dt.Columns.Add("image");
                dt.Columns.Add("BirthDate");
                dt.Columns.Add("StuCNIC");
                dt.Columns.Add("FamilyID");
                dt.Columns.Add("Gender");
                dt.Columns.Add("JoiningClassID");
                dt.Columns.Add("LeavingDate");
                dt.Columns.Add("registration_no");
                dt.Columns.Add("ReligionID");
                dt.Columns.Add("Email");
                dt.Columns.Add("StuGroupID");

                for (int i = 0; i < lenght; i++)
                {
                    data = JObject.Parse(jsonArray[i].ToString());

                    Stud.secid = data.SectionID;
                    Stud.uid = data.UserID;
                    Stud.rollNo = data.RollNo;
                    Stud.name = data.Name;
                    Stud.sDate = data.sDate;
                    Stud.status = data.Status;
                    Stud.image = data.image;
                    Stud.DOB = data.BirthDate;
                    Stud.sNIC = data.StuCNIC;
                    Stud.famid = data.FamilyID;
                    Stud.gender = data.Gender;
                    Stud.Cid = data.JoiningClassID;
                    Stud.leaveDate = data.LeavingDate;
                    Stud.regNo = data.registration_no;
                    Stud.NatId = data.NationalityID;
                    Stud.relId = data.ReligionID;
                    Stud.email = data.Email;
                    Stud.StuGrpId = data.StuGroupID;

                    dt.Rows.Add();
                    dt.Rows[i]["ID"] = Stud.secid;
                    dt.Rows[i]["SectionID"] = Stud.uid;
                    dt.Rows[i]["UserID"] = Stud.rollNo;
                    dt.Rows[i]["RollNo"] = Stud.name;
                    dt.Rows[i]["Name"] = Stud.sDate;
                    dt.Rows[i]["sDate"] = Stud.status;
                    dt.Rows[i]["Status"] = Stud.image;
                    dt.Rows[i]["image"] = Stud.DOB;
                    dt.Rows[i]["BirthDate"] = Stud.sNIC;
                    dt.Rows[i]["StuCNIC"] = Stud.famid;
                    dt.Rows[i]["FamilyID"] = Stud.gender;
                    dt.Rows[i]["Gender"] = Stud.Cid;
                    dt.Rows[i]["JoiningClassID"] = Stud.leaveDate;
                    dt.Rows[i]["LeavingDate"] = Stud.regNo;
                    dt.Rows[i]["registration_no"] = Stud.NatId;
                    dt.Rows[i]["ReligionID"] = Stud.relId;
                    dt.Rows[i]["Email"] = Stud.email;
                    dt.Rows[i]["StuGroupID"] = Stud.StuGrpId;
                }
            }
            return View(dt);
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



    }

}