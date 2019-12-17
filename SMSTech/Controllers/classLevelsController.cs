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
    public class ClassLevelsController : Controller
    {
        //
        // GET: /classLevels/
        classLevels ClsLevel = new classLevels();

        public ActionResult Index()
        {
            DataTable dt = new DataTable();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var url = "http://192.168.0.119:3000/classLevels";
                var json = webClient.DownloadString(url);
                JArray jsonArray = JArray.Parse(json);
                int lenght = jsonArray.Count;
                dynamic data;
                

                dt.Columns.Add("Name");
                dt.Columns.Add("LevelNumber");


                for (int i = 0; i < lenght; i++)
                {
                    data = JObject.Parse(jsonArray[i].ToString());

                    ClsLevel.name = data.Name;
                    ClsLevel.LevelNumber = data.LevelNumber;

                    dt.Rows.Add();
                    dt.Rows[i]["Name"] = ClsLevel.name;
                    dt.Rows[i]["LevelNumber"] = ClsLevel.LevelNumber;

                }
            }
            return View(dt);
        }

        public ActionResult AddClassLevel()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddClassLevel(classLevels clsLevel)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.0.119:3000/");
            var response = client.PostAsJsonAsync("classLevels/AddClassLevel", clsLevel).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Error");
            }
            return View(clsLevel);
        }

	}
}