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
        public ActionResult Login(UserVM userInfo)
        {
            bool result = Helper.Login.Login1(userInfo);

            if (result)
            {
                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }
    }
}