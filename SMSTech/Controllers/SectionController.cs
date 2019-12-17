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
    public class SectionController : Controller
    {
        Section Sec = new Section();

        //
        // GET: /Section/
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
                dt.Columns.Add("ClassID");
               

                for (int i = 0; i < lenght; i++)
                {
                    data = JObject.Parse(jsonArray[i].ToString());

                    Sec.name = data.Name;
                    Sec.cid = data.ClassID;
                    

                    dt.Rows.Add();
                    dt.Rows[i]["Name"] = Sec.name;
                    dt.Rows[i]["ClassID"] = Sec.cid;
                    
                }
            }
            return View(dt);
        

        }

        public ActionResult AddSection()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSection(Section Sec)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.0.119:3000/");
            var response = client.PostAsJsonAsync("section/AddSection", Sec).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Error");
            }
            return View(Sec);
        }

	}
}

