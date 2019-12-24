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
    public class WaterchargesController : Controller
    {
        //
        // GET: /Watercharges/
        public ActionResult WaterCharges()
        {
            DataTable dt = new DataTable();

            //using (WebClient webClient = new System.Net.WebClient())
            //{
            //    var url = "https://amga-monorepo-starter-api.localtunnel.me/watercharges";
            //    var json = webClient.DownloadString(url);
            //    JArray jsonArray = JArray.Parse(json);
            //    int lenght = jsonArray.Count;
            //    dynamic data;
            //    Watercharges Wcharges = new Watercharges();
            //    dt.Columns.Add("Month");
            //    dt.Columns.Add("PaidDate");
            //    dt.Columns.Add("Amount");



            //    for (int i = 0; i < lenght; i++)
            //    {
            //        data = JObject.Parse(jsonArray[i].ToString());
            //        //Stud.ID = int.Parse(data.Std_RollNo);
            //        Wcharges.ExpName = data.W_ExpenceName;
            //        Wcharges.ExpDate = data.W_ExpenceDate;
            //        Wcharges.Amount = data.W_Ammount;


            //        dt.Rows.Add();
            //        dt.Rows[i]["Month"] = Wcharges.ExpName;
            //        dt.Rows[i]["PaidDate"] = Wcharges.ExpDate;
            //        dt.Rows[i]["Amount"] = Wcharges.Amount;


            //    }

            //}
            return View(dt);
        }

	}
}