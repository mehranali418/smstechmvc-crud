using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSTech.Controllers
{
    public class BillsController : Controller
    {
        //
        // GET: /Bills/
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GasBill()
        {
            return View();
        }
	}
}