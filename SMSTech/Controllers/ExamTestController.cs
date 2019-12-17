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
    public class ExamTestController : Controller
    {

        ExamTests ExamTest = new ExamTests();
        //
        // GET: /ExamTests/
        public ActionResult Index()
        {
            DataTable dt = new DataTable();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var url = "http://192.168.0.119:3000/examTest";
                var json = webClient.DownloadString(url);
                JArray jsonArray = JArray.Parse(json);
                int lenght = jsonArray.Count;
                dynamic data;
                

                dt.Columns.Add("Name");
                dt.Columns.Add("details");

                for (int i = 0; i < lenght; i++)
                {
                    data = JObject.Parse(jsonArray[i].ToString());

                    ExamTest.Name = data.Name;
                    ExamTest.details = data.Detail;


                    dt.Rows.Add();
                    dt.Rows[i]["Name"] = ExamTest.Name;
                    dt.Rows[i]["details"] = ExamTest.details;


                }
            }
            return View(dt);
        }


        public ActionResult AddExam()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExam(ExamTests ExamTest)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.0.119:3000/");
            var response = client.PostAsJsonAsync("examTest/AddExam", ExamTest).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Error");
            }
            return View(ExamTest);
        }
	}
}