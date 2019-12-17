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
    public class ClassesController : Controller
    {
        Classes Class = new Classes();
       public ActionResult Index()
        {
            DataTable dt = new DataTable();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var url = "http://192.168.0.119:3000/classes";
                var json = webClient.DownloadString(url);
                JArray jsonArray = JArray.Parse(json);
                int lenght = jsonArray.Count;
                dynamic data;

                dt.Columns.Add("Name");
                dt.Columns.Add("ClassNumber");
                dt.Columns.Add("LevelName");

                dt.Columns.Add("Level_id");

                for (int i = 0; i < lenght; i++)
                {
                    data = JObject.Parse(jsonArray[i].ToString());
                    Class.name = data.Name;
                    Class.classNumber = data.ClassNumber;
                    Class.Class_LevelName = data.Class_LevelName;
                    Class.levelId = data.LevelNumber;



                    dt.Rows.Add();
                    dt.Rows[i]["Name"] = Class.name;
                    dt.Rows[i]["ClassNumber"] = Class.classNumber;
                    dt.Rows[i]["LevelName"] = Class.Class_LevelName;
                    dt.Rows[i]["Level_id"] = Class.levelId;

                }
            }
            return View(dt);
        

        }

       public ActionResult AddClasses()
       {
           return View();
       }
       [HttpPost]
       public ActionResult AddClasses(Classes Class)
       {
           HttpClient client = new HttpClient();
           client.BaseAddress = new Uri("http://192.168.0.119:3000/");
           var response = client.PostAsJsonAsync("classes/AddClasses", Class).Result;
           if (response.IsSuccessStatusCode)
           {
               Console.Write("Success");
           }
           else
           {
               Console.Write("Error");
           }
           return View(Class);
       }

	}
}