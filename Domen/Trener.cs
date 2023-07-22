using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    /// <summary>
    /// Predstavlja trenera koji radi u treretani.
    /// 
    /// Sadrzi id, ime, prezime, obrazovanje.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class Trener
    {
        /// <summary>
        /// Id trenera kao int.
        /// </summary>
        public int TrenerID { get; set; }
        /// <summary>
        /// Ime trenera kao string.
        /// </summary>
        public string Ime { get; set; }
        /// <summary>
        /// Prezime treneras kao string.
        /// </summary>
        public string Prezime { get; set; }
        /// <summary>
        /// Obrazovanje trenera koji radi u teretani.
        /// </summary>
        public Obrazovanje Obrazovanje { get; set; }
        /// <summary>
        /// Id obrazovanja trenera.
        /// </summary>
        public int ObrazovanjeID { get; set; }
        /// <summary>
        /// Get metoda koja vraca ime i prezime trenera.
        /// </summary>
        public string ImePrezime
        {
            get => Ime + " " + Prezime;
        }
        /// <summary>
        /// Opis trenera kao string.
        /// </summary>
        public string Opis { get; set; }
        /// <summary>
        /// Slika trenera kao string koji sadrzi adresu slike.
        /// </summary>
        public string? Slika { get; set; }
    }
}
