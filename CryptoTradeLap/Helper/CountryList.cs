using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CryptoTradeLap.Models;

namespace CryptoTradeLap.Helper
{
    public static class CountryList
    {
        /// <summary>
        /// befüllt die Lister mit den vorhandenen Ländern aus der datenbank
        /// </summary>
        /// <param name="Countries"></param>
        /// <returns>Liste mit Ländern</returns>
        public static List<SelectListItem> FilCountryList(List<Country> Countries)
        {
            List<SelectListItem> countryList = new List<SelectListItem>();
            foreach (Country country in Countries)
            {
                countryList.Add(new SelectListItem() { Text = country.name });
            }
            return countryList;
        }


      

    }
}