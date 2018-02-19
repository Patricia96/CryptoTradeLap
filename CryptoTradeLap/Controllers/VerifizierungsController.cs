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

            adress.created = verifi.created;
            adress.street = verifi.street;
            adress.numbers = verifi.numbers;
            adress.user_id = dbuser.id;
            adress.city_id = city.id;
            db.Address.Add(adress);

            city.created = verifi.created;
            city.city1 = verifi.city;
            city.country_id = country.id;
            city.zip = verifi.zip;
            db.City.Add(city);

            dbuser.status++;
            //speichern im Ordner
            Pass.SaveAs("C:\\Users\\Patricia\\source\\repos\\original\\CryptoTradeLap\\Image\\upload\\" + Pass.FileName);
            string path = "~/Image/upload" + Path.GetExtension(verifi.Pass.FileName);
            verifi.Pass.SaveAs(Server.MapPath(path));
            upload.path = verifi.Pass.FileName;

            upload.user_id = dbuser.id;
            upload.created = dbuser.created;
            


            if (ModelState.IsValid)
            {
                db.Upload.Add(upload);
                db.SaveChanges();
                return RedirectToAction("Index","Verifizierungs");
            }

            return View();
        }
             
    }
}