﻿using Survey_System.Models;
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
            var model = db.Person.ToList();
            return View(model);
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

            person.ModifyBy = "System Edit";
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