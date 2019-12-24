using Newtonsoft.Json.Linq;
using SMSTech.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMSTech.Controllers
{
    public class RankController : Controller
    {
        SMST4MEntities1 db = new SMST4MEntities1();
        Rank rank = new Rank();

        //
        // GET: /Rank/
        public ActionResult Index()
        {
           return View();
        }

        public JsonResult GetRank()
        {
            var rank = db.Ranks.ToList();
            return Json(rank,JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddRanks()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRanks(Rank rank)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.0.119:3000/");
            var response = client.PostAsJsonAsync("rank/AddRanks", rank).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Error");
            }
            return View(rank);
        }
	}
}