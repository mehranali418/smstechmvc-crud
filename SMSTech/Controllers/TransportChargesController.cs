using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMSTech.Models;

namespace SMSTech.Controllers
{
    public class TransportChargesController : Controller
    {
        //
        // GET: /TransportCharges/
        public ActionResult TransportCharges()
        {
            DataTable dt = new DataTable();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var url = "https://amga-monorepo-starter-api.localtunnel.me/TransportCharges";
                var json = webClient.DownloadString(url);
                JArray jsonArray = JArray.Parse(json);
                int lenght = jsonArray.Count;
                dynamic data;
                TransportCharges Tcharges = new TransportCharges();
                dt.Columns.Add("Location");
                dt.Columns.Add("Date");
                dt.Columns.Add("Amount");



                for (int i = 0; i < lenght; i++)
                {
                    data = JObject.Parse(jsonArray[i].ToString());
                    //Stud.ID = int.Parse(data.Std_RollNo);
                    Tcharges.Tlocation = data.Trans_Location;
                    Tcharges.TExpDate = data.Trans_ExpenceDate;
                    Tcharges.TAmount = data.Trans_Ammount;


                    dt.Rows.Add();
                    dt.Rows[i]["Location"] = Tcharges.Tlocation;
                    dt.Rows[i]["Date"] = Tcharges.TExpDate;
                    dt.Rows[i]["Amount"] = Tcharges.TAmount;


                }

            }
            return View(dt);
        }
	}
}