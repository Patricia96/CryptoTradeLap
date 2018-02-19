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
        public decimal status { get; set; }
        public string street { get; set; }
        public string numbers { get; set; }
        public string city { get; set; }
        public HttpPostedFileBase Pass { get; set;   }
        public string zip { get; set; }
        public DateTime created { get; set; } = DateTime.Now;
        public string Country { get; set; }
        public List<SelectListItem> CountryList { get; set; }




    }
}