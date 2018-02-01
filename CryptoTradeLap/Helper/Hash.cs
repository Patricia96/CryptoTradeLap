using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace CryptoTradeLap.Helper
{
    public class Hash
    {
        public static string SaltErzeugen()
        {
            //Byte Array erzeugen
            var salt = new byte[32];

            //Klasse Krypto erzeugen
            var rng = new RNGCryptoServiceProvider();

            // das Array der Methode Salt Übergeben
            rng.GetNonZeroBytes(salt);

            return HexString(salt);
        }

        private static string HexString(byte[] bytes)
        {
            //Instanz von stringbuilder initialisieren
            var hashSB = new StringBuilder(64);

            //für jeden eintrag im Array ersetzen durch 2 hexzahlen
            foreach (var b in bytes)
            {
                //nimmt die instanz namens hashSB her , und formatiert jedes zeichen in eine Hex zahl
                hashSB.Append(b.ToString("X2"));
            }

            //retuniert den hash als string zum aufrufer
            return hashSB.ToString();
        }

        public static string HashBerechnen(string s)
        {
            //Daten (in unserem Fall ein String) in ein ByteArray umwandeln
            var bytes = Encoding.UTF8.GetBytes(s);

            //Initialisiert eine neue Instanz der klasse SHA256....
            using (SHA256 sha = new SHA256Managed())
            {
                //errechnet den hash für das ganze Array und liefert das zurück
                var hash = sha.ComputeHash(bytes);
                return HexString(hash);
            }
        }
    }
}