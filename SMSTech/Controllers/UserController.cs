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
    public class UserController : Controller
    {

        SMST4MEntities1 db = new SMST4MEntities1();
        //
        User Usr = new User();

        // GET: /User/
        public ActionResult Index()
        {
            
            return View();



            //RoleID
            //Name
            //Phone
            //Address
            //Status
            //Username
            //Password
            //RankID
            //NationalityID
            //EducationID
            //ExperienceID
            //ReligionID
            //AppointmentDate
            //TerminationDate
            //DateOfBirth
            //Phone2
            //Email
            //Comments


        }

        public JsonResult GetUsers()
        {
            var user = db.Users.ToList();
            return Json(user,JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User Usr)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.0.119:3000/");
            var response = client.PostAsJsonAsync("user/AddUser", Usr).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Error");
            }
            return View(Usr);
        }
    }
}