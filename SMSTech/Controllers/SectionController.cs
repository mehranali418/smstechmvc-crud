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
    public class SectionController : Controller
    {
        //
        // GET: /Section/
        public ActionResult SectionView()
        {
              DataTable dt = new DataTable();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var url = "http://192.168.0.119:3000/section";
                var json = webClient.DownloadString(url);
                JArray jsonArray = JArray.Parse(json);
                int lenght = jsonArray.Count;
                dynamic data;
                Section Sec = new Section();

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
	}
}

