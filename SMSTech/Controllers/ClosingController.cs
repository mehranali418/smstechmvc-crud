using SMSTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMSTech.Controllers
{
    public class ClosingController : Controller
    {
        // GET: Closing
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(Closings c)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://black-frog-6.localtunnel.me/");
            //var response = client.PostAsJsonAsync("closing/AddClosing", c).Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    Console.Write("Success");
            //}
            //else
            //{
            //    Console.Write("Error");
            //}
            return View(c);
        }
    }
}