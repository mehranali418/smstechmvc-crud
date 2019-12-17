using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMSTech.Models;
using System.Net.Http;

namespace SMSTech.Controllers
{
    public class StudentRelationsController : Controller
    {
        //
        // GET: /StudentRelations/
        StudentRelations SRelation = new StudentRelations();

        public ActionResult Index()
        {
            DataTable dt = new DataTable();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var url = "http://192.168.0.119:3000/studentRelation";
                var json = webClient.DownloadString(url);
                JArray jsonArray = JArray.Parse(json);
                int lenght = jsonArray.Count;
                dynamic data;
                

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


        public ActionResult AddRelations()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddRelations(StudentRelations SRelation)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.0.119:3000/");
            var response = client.PostAsJsonAsync("studentRelation/AddRelations", SRelation).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Error");
            }
            return View(SRelation);
        }
	}
}