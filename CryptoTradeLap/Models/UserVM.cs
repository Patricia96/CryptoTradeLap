using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CryptoTradeLap.Models
{
    public class UserVM
    {
       

        public int id { get; set; }
        public DateTime created { get; set; } = DateTime.Now;

        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [MinLength(7, ErrorMessage = "Ungültiges Passwort")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [MinLength(3, ErrorMessage = "Vorname ist ungültig")]
        public string firstname { get; set; }

        [MinLength(3, ErrorMessage = "Nachname ist ungültig")]
        public string lastname { get; set; }

        public string salt { get; set; }
        public decimal Role { get; set; }

    }
}