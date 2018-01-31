using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CryptoTradeLap.Models;

namespace CryptoTradeLap.Controllers
{
    public class RegisterController : Controller
    {
        //Ruft die Register View auf
        [AllowAnonymous]//
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        //Postet die daten ans Model
        [AllowAnonymous]//
        [HttpPost]
        public ActionResult Register(string firstname, string lastname, string password, string email)
        {
            UserVM newUser = new UserVM();
            newUser.firstname = firstname;
            newUser.lastname = lastname;
            newUser.email = email;
            newUser.password = password;

            Helper.Register.Registrieren(newUser);

            return RedirectToAction("Access", "Home");
        }
    }
}