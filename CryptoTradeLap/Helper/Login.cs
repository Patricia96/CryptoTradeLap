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
        public static bool Login1(UserVM user)
        {
            using (var db = new CryptoTraderEntities())
            {
                if (db.User.Any(n => n.email == user.email))
                {
                    var dbUser = db.User.Where((n => n.email == user.email)).FirstOrDefault();

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
                            user.Role.ToString()
                            );
                        // FormsAuthentication.Encrypt erstellt eine Zeichenfolge, die einen verschlüsselten Formularauthentifizierungstickets
                        //     geeignet für die Verwendung in einem HTTP-Cookie enthält.
                        var encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                        var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                        HttpContext.Current.Response.Cookies.Add(authCookie);
                        return true;
                    }

                }
            }
            return false;
        }
    }
}