using SMSTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSTech.Controllers
{
    public class AllowanceAmountsController : Controller
    {
        SMST4MEntities1 db = new SMST4MEntities1(); 
        // GET: AllowanceAmounts
        public ActionResult Index()
        {
            ViewBag.UserID = new SelectList(db.Users, "ID", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Insert(AllowanceAmount data)
        {
            AllowanceAmount Allowanceamount = new AllowanceAmount();
            Allowanceamount.UserID= data.UserID;
            Allowanceamount.AllowanceTypeID = data.AllowanceTypeID;
            Allowanceamount.Amount = data.Amount;
            Allowanceamount.SalaryMonthID = data.SalaryMonthID;
            Allowanceamount.AllowanceAmountID = data.AllowanceAmountID;
            db.AllowanceAmounts.Add(Allowanceamount);
            db.SaveChanges();
            db.Entry(Allowanceamount).State = System.Data.Entity.EntityState.Modified;
            return Json("Saved Successfully");
        }
    }
}