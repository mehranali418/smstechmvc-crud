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
    public class ReligionController : Controller
    {
        Religions Rel = new Religions();

        //
        // GET: /Religions/
        public ActionResult Index()
        {

            DataTable dt = new DataTable();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var url = "http://192.168.0.119:3000/Religion";
                var json = webClient.DownloadString(url);
                JArray jsonArray = JArray.Parse(json);
                int lenght = jsonArray.Count;
                dynamic data;
                
                dt.Columns.Add("Name");


                for (int i = 0; i < lenght; i++)
                {
                    data = JObject.Parse(jsonArray[i].ToString());

                    Rel.name = data.Name;


                    dt.Rows.Add();
                    dt.Rows[i]["Name"] = Rel.name;

                }
            }
            return View(dt);
        }


        public ActionResult AddReligions()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddReligions(Religions Rel)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.0.119:3000/");
            var response = client.PostAsJsonAsync("religion/Addreligions", Rel).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Error");
            }
            return View(Rel);
        }
	}
}