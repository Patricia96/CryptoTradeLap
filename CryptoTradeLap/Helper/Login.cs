using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CryptoTradeLap.Models;
using System.Web.Security;

namespace CryptoTradeLap.Helper
{
    public class Login
    {
        public static string Login1(UserVM user, ref string login)
        {
            string mail = user.email;
            string passwort = user.password;

            using (var db = new CryptoTraderEntities())
            {
                if (db.User.Any(n => n.email == mail))
                {
                    var dbUser = db.User.Where((n => n.email == mail)).FirstOrDefault();

                    user.password += dbUser.salt;

                    var eingegPWHash = Helper.Hash.HashBerechnen(user.password);

                    if (eingegPWHash == dbUser.password)
                    {
                        var authTicket = new FormsAuthenticationTicket(
                            1,  //Ticketversion
                            user.email, //Useridentifizierung
                            DateTime.Now, //Zeitpunkt der Erstellung
                            DateTime.Now.AddMinutes(30), //Wann das Ticket ablaeuft
                            false, //Persistentes Ticket?
                            ""
                            );

                        var encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                        var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                        System.Web.HttpContext.Current.Response.Cookies.Add(authCookie);

                        return login = "true";
                    }
                }
                return login = "false";
            }
        }
    }
}