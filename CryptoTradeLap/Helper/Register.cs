using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CryptoTradeLap.Models;
using System.Security.Policy;


namespace CryptoTradeLap.Helper
{
    public class Register
    {

        public static void Registrieren(UserVM user)
                     
        {
         
            User dbUser = new User();
            dbUser.firstname = user.firstname;
            dbUser.lastname = user.lastname;
            dbUser.email = user.email;
            dbUser.password = user.password;
            dbUser.created = DateTime.Now;

            //Salt erzeugen
            var salt = Hash.SaltErzeugen();

            //Salt in das EntiyModel speichern
            dbUser.salt = salt;

            //Salt an das Klartextpasswort anhaengen
            dbUser.password += salt;

            //PW Hashen
            dbUser.password = Hash.HashBerechnen(dbUser.password);

            //Datenbankverbindung aufgebaut
            using (var db = new CryptoTraderEntities())

            {
                db.User.Add(dbUser); //User hinzufügen
                db.SaveChanges(); //speichern in datenbank
            

            }

            return;
        }
    }
}