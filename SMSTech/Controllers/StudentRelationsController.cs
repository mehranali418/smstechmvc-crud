using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMSTech.Models;

namespace SMSTech.Controllers
{
    public class StudentRelationsController : Controller
    {
        //
        // GET: /StudentRelations/
        public ActionResult StudentRelationsView()
        {
            DataTable dt = new DataTable();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var url = "http://192.168.0.119:3000/studentRelation";
                var json = webClient.DownloadString(url);
                JArray jsonArray = JArray.Parse(json);
                int lenght = jsonArray.Count;
                dynamic data;
                StudentRelations SRelation = new StudentRelations();

                dt.Columns.Add("Name");

                for (int i = 0; i < lenght; i++)
                {
                    data = JObject.Parse(jsonArray[i].ToString());

                    SRelation.name = data.Name;


                    dt.Rows.Add();
                    dt.Rows[i]["Name"] = SRelation.name;


                }
            }
            return View(dt);
        }
	}
}