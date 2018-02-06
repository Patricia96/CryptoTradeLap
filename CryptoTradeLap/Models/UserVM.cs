using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptoTradeLap.Models
{
    public class UserVM
    {
        public int id {get;set; }
        public string email { get; set; }
        public string password{ get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string salt { get; set; }
        public decimal Role { get; set; }
    }
}