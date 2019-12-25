using SMSTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSTech.Controllers
{
    public class AssessmentCategoriesController : Controller
    {
        SMST4MEntities1 db = new SMST4MEntities1();
    // GET: AssessmentCategories
    public ActionResult Index()
    {
        return View();
    }
    [HttpPost]
        public ActionResult Insert(AssessmentCategory data)
        {
            AssessmentCategory Assessmentcategory = new AssessmentCategory();
            Assessmentcategory.Name = data.Name;
            Assessmentcategory.Detail = data.Detail;
            Assessmentcategory.Status = data.Status;
            db.AssessmentCategories.Add(Assessmentcategory);
            db.SaveChanges();
            db.Entry(Assessmentcategory).State = System.Data.Entity.EntityState.Modified;
            return Json("Saved Successfully");
        }
    }
}