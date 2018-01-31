using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CryptoTradeLap.Models;
using CryptoTradeLap.Helper;

namespace CryptoTradeLap.Controllers
{
    public class LoginController : Controller
    {
        // GET: SignIn
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string mail, string password)
        {
            string login = "";

            UserVM logInUser = new UserVM();
            logInUser.email = mail;
            logInUser.password = password;

            Helper.Login.Login1(logInUser, ref login);

            if (login == "true")
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}