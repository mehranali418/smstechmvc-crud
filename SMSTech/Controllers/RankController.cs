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
    public class RankController : Controller
    {
        //
        // GET: /Rank/
        public ActionResult RankView()
        {
            DataTable dt = new DataTable();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var url = "http://192.168.0.119:3000/Rank";
                var json = webClient.DownloadString(url);
                JArray jsonArray = JArray.Parse(json);
                int lenght = jsonArray.Count;
                dynamic data;
                Rank rank = new Rank();

                dt.Columns.Add("Name");


                for (int i = 0; i < lenght; i++)
                {
                    data = JObject.Parse(jsonArray[i].ToString());

                    rank.name = data.Name;

                    dt.Rows.Add();
                    dt.Rows[i]["Name"] = rank.name;

                }
            }
            return View(dt);
        }
	}
}