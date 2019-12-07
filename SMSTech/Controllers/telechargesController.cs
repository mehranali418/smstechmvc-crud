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
    public class telechargesController : Controller
    {
        //
        // GET: /telecharges/
        public ActionResult telecharges()
        {
            DataTable dt = new DataTable();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var url = "https://black-frog-6.localtunnel.me/telecharges";
                var json = webClient.DownloadString(url);
                JArray jsonArray = JArray.Parse(json);
                int lenght = jsonArray.Count;
                dynamic data;
                telecharges Telecharges = new telecharges();
                dt.Columns.Add("Name");
                dt.Columns.Add("Date");
                dt.Columns.Add("Amount");



                for (int i = 0; i < lenght; i++)
                {
                    data = JObject.Parse(jsonArray[i].ToString());
                    //Stud.ID = int.Parse(data.Std_RollNo);
                    Telecharges.TExpName = data.Tel_ExpenceName;
                    Telecharges.TExpDate = data.Tel_ExpenceDate;
                    Telecharges.TAmount = data.Tel_Ammount;


                    dt.Rows.Add();
                    dt.Rows[i]["Name"] = Telecharges.TExpName;
                    dt.Rows[i]["Date"] = Telecharges.TExpDate;
                    dt.Rows[i]["Amount"] = Telecharges.TAmount;


                }

            }
            return View(dt);
        }
	}
}