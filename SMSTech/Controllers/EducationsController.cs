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
    public class EducationsController : Controller
    {
        //
        // GET: /Educations/
        public ActionResult Index()
        {
            DataTable dt = new DataTable();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var url = "http://192.168.0.119:3000/educations";
                var json = webClient.DownloadString(url);
                JArray jsonArray = JArray.Parse(json);
                int lenght = jsonArray.Count;
                dynamic data;
                Educations Edu = new Educations();

                dt.Columns.Add("Name");


                for (int i = 0; i < lenght; i++)
                {
                    data = JObject.Parse(jsonArray[i].ToString());

                    Edu.Name = data.Name;


                    dt.Rows.Add();
                    dt.Rows[i]["Name"] = Edu.Name;

                }
            }
            return View(dt);
        

        }


        [HttpPost]
        public ActionResult AddEducation(Educations e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.0.119:3000/");
            var response = client.PostAsJsonAsync("Educations/AddEducation", e).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Error");
            }
            return View(e);
        }
        [HttpPut]
        public ActionResult Edit(int ID)
        {
            Educations Education = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.0.119:3000/");
                //HTTP GET
                var responseTask = client.GetAsync("Educations?ID=" + ID.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Educations>();
                    readTask.Wait();
                    Education = readTask.Result;
                }
            }

            return View(Education);
        }
        public ActionResult Edit()
        {
            return View();
        }

	}
}