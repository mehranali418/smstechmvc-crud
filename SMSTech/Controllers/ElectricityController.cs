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
    public class ElectricityController : Controller
    {
        //
        // GET: /Electricity/
        public ActionResult Electricity()
        {
            DataTable dt = new DataTable();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var url = "https://amga-monorepo-starter-api.localtunnel.me/Electricity";
                var json = webClient.DownloadString(url);
                JArray jsonArray = JArray.Parse(json);
                int lenght = jsonArray.Count;
                dynamic data;
                Electricity EBill = new Electricity();
                dt.Columns.Add("Month");
                dt.Columns.Add("PaidDate");
                dt.Columns.Add("Amount");



                for (int i = 0; i < lenght; i++)
                {
                    data = JObject.Parse(jsonArray[i].ToString());
                    //Stud.ID = int.Parse(data.Std_RollNo);
                    EBill.EL_Month = data.EL_Month;
                    EBill.EL_PaidDate = data.EL_PaidDate;
                    EBill.EL_Ammount = data.EL_Ammount;



                    dt.Rows.Add();
                    dt.Rows[i]["Month"] = EBill.EL_Month;
                    dt.Rows[i]["PaidDate"] = EBill.EL_PaidDate;
                    dt.Rows[i]["Amount"] = EBill.EL_Ammount;


                }

            }
            return View(dt);
        }
	}
}