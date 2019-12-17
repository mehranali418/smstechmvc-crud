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
    public class ClassesController : Controller
    {
        //         "insert into classes (Name,ClassNumber,Level_id) values('"+req.body.name+"','"+req.body.classNumber+"','"+req.body.levelId+"')"

        // GET: /Classes/
        public ActionResult ClassesView()
        {
            DataTable dt = new DataTable();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var url = "http://192.168.0.119:3000/classes";
                var json = webClient.DownloadString(url);
                JArray jsonArray = JArray.Parse(json);
                int lenght = jsonArray.Count;
                dynamic data;
                Classes Sec = new Classes();

                dt.Columns.Add("Name");
                dt.Columns.Add("ClassNumber");
                dt.Columns.Add("LevelName");

                dt.Columns.Add("Level_id");

                for (int i = 0; i < lenght; i++)
                {
                    data = JObject.Parse(jsonArray[i].ToString());
                    Sec.name = data.Name;
                    Sec.classNumber = data.ClassNumber;
                    Sec.Class_LevelName = data.Class_LevelName;
                    Sec.levelId = data.LevelNumber;



                    dt.Rows.Add();
                    dt.Rows[i]["Name"] = Sec.name;
                    dt.Rows[i]["ClassNumber"] = Sec.classNumber;
                    dt.Rows[i]["LevelName"] = Sec.Class_LevelName;
                    dt.Rows[i]["Level_id"] = Sec.levelId;

                }
            }
            return View(dt);
        

        }
	}
}