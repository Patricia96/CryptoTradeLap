using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CryptoTradeLap.Models
{
    public class VerifiVM
    {
        //[Required]
        public int Id { get; set; }
        public decimal Status { get; set; }

        //[MinLength(7, ErrorMessage = "Ungültiges Starße")]
        public string Street { get; set; }

        //[MinLength(1, ErrorMessage = "Ungültige Nummer ")]
        public string Numbers { get; set; }

        //[MinLength(2, ErrorMessage = "Ungültige Stadt")]
        public string City { get; set; }

        //[MinLength(1, ErrorMessage = "Ungültiger Pass")]
        public HttpPostedFileBase Pass { get; set;   }

        //[MinLength(2, ErrorMessage = "Ungültiges Postleitzahl")]
        public string Zip { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

       
        public string Country { get; set; }
        public List<SelectListItem> CountryList { get; set; }




    }
}