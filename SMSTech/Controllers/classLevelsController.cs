using Newtonsoft.Json.Linq;
using SMSTech.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SMSTech.Controllers
{
    public class classLevelsController : Controller
    {
        //
        // GET: /classLevels/
        public ActionResult classLevelsView()
        {
            DataTable dt = new DataTable();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var url = "http://192.168.0.119:3000/classLevels";
                var json = webClient.DownloadString(url);
                JArray jsonArray = JArray.Parse(json);
                int lenght = jsonArray.Count;
                dynamic data;
                classLevels Rel = new classLevels();

                dt.Columns.Add("Name");
                dt.Columns.Add("LevelNumber");


                for (int i = 0; i < lenght; i++)
                {
                    data = JObject.Parse(jsonArray[i].ToString());

                    Rel.name = data.Name;
                    Rel.LevelNumber = data.LevelNumber;

                    dt.Rows.Add();
                    dt.Rows[i]["Name"] = Rel.name;
                    dt.Rows[i]["LevelNumber"] = Rel.LevelNumber;

                }
            }
            return View(dt);
        }
	}
}