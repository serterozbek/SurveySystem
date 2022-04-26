using Survey_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Survey_System.Controllers
{
    public class PersonController : Controller
    {
        survey_systemEntities db = new survey_systemEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(Person person)
        {
            if (person.NameSurname != null)
            {
                person.CreateDate = DateTime.Now;
                person.CreateBy = "System";
                db.Person.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
            return View();
            }

        }


    }
}