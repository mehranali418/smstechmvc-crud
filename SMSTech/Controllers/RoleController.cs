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
    public class RoleController : Controller
    {
        Roles Role = new Roles();

        // GET: Role
        
        public ActionResult Index()
        {
            DataTable dt = new DataTable();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var url = "http://192.168.0.119:3000/section";
                var json = webClient.DownloadString(url);
                JArray jsonArray = JArray.Parse(json);
                int lenght = jsonArray.Count;
                dynamic data;

                dt.Columns.Add("Name");
                dt.Columns.Add("Type");


                for (int i = 0; i < lenght; i++)
                {
                    data = JObject.Parse(jsonArray[i].ToString());

                    Role.name = data.Name;
                    Role.type = data.type;


                    dt.Rows.Add();
                    dt.Rows[i]["Name"] = Role.name;
                    dt.Rows[i]["Type"] = Role.type;

                }
            }
            return View(dt);
        
        }

        public ActionResult AddRoles()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddRoles(Roles Role)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.0.119:3000/");
            var response = client.PostAsJsonAsync("role/AddRoles", Role).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Error");
            }
            return View(Role);
        }

    }
}