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
    public class ReligionsController : Controller
    {
        //
        // GET: /Religions/
        public ActionResult ReligionsView()
        {

            DataTable dt = new DataTable();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var url = "http://192.168.0.119:3000/Religion";
                var json = webClient.DownloadString(url);
                JArray jsonArray = JArray.Parse(json);
                int lenght = jsonArray.Count;
                dynamic data;
                Religions Rel = new Religions();
                
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
	}
}