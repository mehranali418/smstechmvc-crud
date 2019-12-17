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
        // GET: Role
        
        public ActionResult RolesView(Roles r)
        {
            DataTable dt = new DataTable();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var url = "http://192.168.0.119:3000/section";
                var json = webClient.DownloadString(url);
                JArray jsonArray = JArray.Parse(json);
                int lenght = jsonArray.Count;
                dynamic data;
                Roles Role = new Roles();

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
    }
}