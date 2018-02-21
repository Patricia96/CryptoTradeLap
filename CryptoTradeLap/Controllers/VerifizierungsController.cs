using System;
using System.Linq;
using System.Web.Mvc;
using CryptoTradeLap.Helper;
using CryptoTradeLap.Models;
using System.Web;
using System.IO;

namespace CryptoTradeLap.Controllers
{
    public class VerifizierungsController : Controller
    {

        //Datenbank aufrufen
        private CryptoTraderEntities db = new CryptoTraderEntities();

     
        // GET: Verifizierungs
        public ActionResult Verifizierung()
        {
            VerifiVM vm = new VerifiVM();
            //daten aus datenbank mache ich zu einer liste(ToList)
            var list = db.Country.ToList();
            vm.CountryList = CountryList.FilCountryList(list);
            return View(vm);
        }



        [HttpPost]
        public ActionResult Verifizierung(VerifiVM verifi ,HttpPostedFileBase Pass)
        {


            User dbuser = db.User.Where(a => a.email == User.Identity.Name).FirstOrDefault();
            var country = db.Country.Where(c => c.name == verifi.Country).FirstOrDefault();

            var city = new City();
            var adress = new Address();
            var upload = new Upload();

            city.id = db.City.Count();
            city.created = DateTime.Now;
            city.city1 = verifi.City;
            city.zip = verifi.Zip;
            city.country_id = country.id;
            db.City.Add(city);
            db.SaveChanges();


            adress.id = db.Address.Count();
            adress.created = verifi.Created;
            adress.street = verifi.Street;
            adress.numbers = verifi.Numbers;
            adress.user_id = dbuser.id;
            adress.city_id = city.id;
            db.Address.Add(adress);
            db.SaveChanges();

            dbuser.status++;


            //speichern im Ordner direkter Pfad

            //Pass.SaveAs("C:\\Users\\Patricia\\source\\repos\\original\\CryptoTradeLap\\Image\\upload\\" + Pass.FileName);
            //string path = "~/Image/upload" + Path.GetExtension(verifi.Pass.FileName);
            //verifi.Pass.SaveAs(Server.MapPath(path));
            //


            var path = Path.GetFileName(Pass.FileName);
            var pathBild = Path.Combine(Server.MapPath("~/Content/upload/"), path);
            verifi.Pass.SaveAs(pathBild);
            verifi.Pass = Pass;
            upload.path = verifi.Pass.FileName;

            upload.id = db.Upload.Count();
            upload.user_id = dbuser.id;
            upload.created = dbuser.created;
            db.Upload.Add(upload);
            db.SaveChanges();


            if (ModelState.IsValid)
            {


                return RedirectToAction("Verifizierung", "Verifizierungs");
            }

            return View();
        }
             
    }
}