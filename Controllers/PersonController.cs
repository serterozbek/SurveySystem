using Survey_System.Models;
using Survey_System.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Survey_System.Controllers
{
    public class PersonController : BaseController
    {
        public ActionResult Index()
        {
            var model = db.Person.ToList();
            return View(model);
        }

        public ActionResult Create(Person person, string Answer)
        {
            if (person.NameSurname != null)
            {
                person.CreateDate = DateTime.Now;
                person.CreateBy = NameSurname;
                if (Answer==Constants.AnswerType.Yes)
                {
                    person.IsAdmin = true;
                }
                else
                {
                    person.IsAdmin = false;
                }
                db.Person.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
            return View();
            }

        }

        public ActionResult Edit(int? id)
        {
            if (id==null || id==0)
            {
                return HttpNotFound();
            }
            var model = db.Person.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Person person)
        {
            db.Entry(person).State = System.Data.Entity.EntityState.Modified;
            db.Entry(person).Property(e => e.CreateBy).IsModified = false;
            db.Entry(person).Property(e => e.CreateDate).IsModified = false;

            person.ModifyBy = NameSurname;
            person.ModifyDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }
            var person = db.Person.Find(id);
            db.Person.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}