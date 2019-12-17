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
    public class StudentGuardiansController : Controller
    {
        //
        // GET: /StudentGuardians/
        public ActionResult StudentGuardiansView()
        {
            DataTable dt = new DataTable();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var url = "http://192.168.0.119:3000/studentGuardian";
                var json = webClient.DownloadString(url);
                JArray jsonArray = JArray.Parse(json);
                int lenght = jsonArray.Count;
                dynamic data;
                StudentGuardians stdGuardian = new StudentGuardians();

                dt.Columns.Add("Name  ");
                dt.Columns.Add("Phone ");
                dt.Columns.Add("Phone2");
                dt.Columns.Add("Addr  ");
                dt.Columns.Add("status");
                dt.Columns.Add("nic   ");
                dt.Columns.Add("voice ");


                for (int i = 0; i < lenght; i++)
                {
                    data = JObject.Parse(jsonArray[i].ToString());

                    stdGuardian.Name = data.Name;
                    stdGuardian.Phone = data.phone;
                    stdGuardian.Phone2 = data.phone2;
                    stdGuardian.Addr = data.Addr;
                    stdGuardian.status = data.status;
                    stdGuardian.nic = data.nic;
                    stdGuardian.voice = data.voice;


                    dt.Rows.Add();
                    dt.Rows[i]["Name  "] = stdGuardian.Name;
                    dt.Rows[i]["Phone "] = stdGuardian.Phone;
                    dt.Rows[i]["Phone2"] = stdGuardian.Phone2;
                    dt.Rows[i]["Addr  "] = stdGuardian.Addr;
                    dt.Rows[i]["status"] = stdGuardian.status;
                    dt.Rows[i]["nic   "] = stdGuardian.nic;
                    dt.Rows[i]["voice "] = stdGuardian.voice;


                }
            }
            return View(dt);
        }
    }
}