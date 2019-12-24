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
    public class GasController : Controller
    {
        //
        // GET: /Gas/
        
public ActionResult Gas()
        {
            DataTable dt = new DataTable();

            //using (WebClient webClient = new System.Net.WebClient())
            //{
            //    var url = "https://amga-monorepo-starter-api.localtunnel.me/Gas";
            //    var json = webClient.DownloadString(url);
            //    JArray jsonArray = JArray.Parse(json);
            //    int lenght = jsonArray.Count;
            //    dynamic data;
            //     Gas gas = new Gas();
            //    dt.Columns.Add("Month");
            //    dt.Columns.Add("PaidDate");
            //    dt.Columns.Add("Amount");
            


            //    for (int i = 0; i < lenght; i++)
            //    {
            //        data = JObject.Parse(jsonArray[i].ToString());
            //        //Stud.ID = int.Parse(data.Std_RollNo);
            //        gas.Gas_Month = data.Gas_Month;
            //        gas.Gas_PaidDate = data.Gas_PaidDate;
            //        gas.Gas_Ammount = data.Gas_Ammount;
                  


            //        dt.Rows.Add();
            //        dt.Rows[i]["Month"] = gas.Gas_Month;
            //        dt.Rows[i]["PaidDate"] = gas.Gas_PaidDate;
            //        dt.Rows[i]["Amount"] = gas.Gas_Ammount;


            //    }

            //}
            return View(dt);
        }        
	}
}