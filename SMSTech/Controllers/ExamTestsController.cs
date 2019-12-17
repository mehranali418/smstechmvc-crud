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
    public class ExamTestsController : Controller
    {
        //
        // GET: /ExamTests/
        public ActionResult ExamTestView()
        {
            DataTable dt = new DataTable();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var url = "http://192.168.0.119:3000/examTest";
                var json = webClient.DownloadString(url);
                JArray jsonArray = JArray.Parse(json);
                int lenght = jsonArray.Count;
                dynamic data;
                ExamTests Etest = new ExamTests();

                dt.Columns.Add("Name");
                dt.Columns.Add("details");

                for (int i = 0; i < lenght; i++)
                {
                    data = JObject.Parse(jsonArray[i].ToString());

                    Etest.Name = data.Name;
                    Etest.details = data.Detail;


                    dt.Rows.Add();
                    dt.Rows[i]["Name"] = Etest.Name;
                    dt.Rows[i]["details"] = Etest.details;


                }
            }
            return View(dt);
        }
	}
}