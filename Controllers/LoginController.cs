﻿using Survey_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Survey_System.Controllers
{
    public class LoginController : Controller
    {
        survey_systemEntities db = new survey_systemEntities();
        public ActionResult SignIn(string Code, string Password)
        {
            if (Code == null)
            {
                return View();
            }
            else
            {
                var person = db.Person.FirstOrDefault(m => m.Code == Code && m.Password == Password);
                if (person != null)
                {
                    Session["Code"] = person.Code;
                    Session["NameSurname"] = person.NameSurname;
                    return RedirectToAction("Create", "Answer");
                }
                else
                {
                    ViewBag.Error = "Kullanıcı adı veya şifre hatalı";
                    return View();

                }
            }

        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("SignIn","Login");
        }
    }
}