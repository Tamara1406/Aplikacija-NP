using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    /// <summary>
    /// Predstavlja klijenta koji vezba u teretani.
    /// 
    /// Sadrzi id, ime ,prezime, kilazu, visinu, grupu za treniranje i pol.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class Klijent
    {
        /// <summary>
        /// Id klijenta koji trenira u teretani.
        /// </summary>
        public int KlijentID { get; set; }
        /// <summary>
        /// Ime klijenta koji trenira u teretani.
        /// </summary>
        public string Ime { get; set; }
        /// <summary>
        /// Prezime klijenta koji trenira u teretani.
        /// </summary>
        public string Prezime { get; set; }
        /// <summary>
        /// Kilaza klijenta u kg.
        /// </summary>
        public int Kilaza { get; set; }
        /// <summary>
        /// Visima klijenta u cm.
        /// </summary>
        public int Visina { get; set; }
        /// <summary>
        /// Grupa u kojoj klijent trenira.
        /// </summary>
        public Grupa? Grupa { get; set; }
        /// <summary>
        /// Id grupe u kojoj klijent trenira.
        /// </summary>
        public int GrupaID { get; set; }
        /// <summary>
        /// Pol klijenta.
        /// </summary>
        public Pol? Pol { get; set; }
        /// <summary>
        /// Id pola klijenta.
        /// </summary>
        public int PolID { get; set; }
        /// <summary>
        /// Get metoda koja vraca ime i prezime klijenta kao string.
        /// </summary>
        public string ImePrezime
        {
            get => Ime + " " + Prezime;
        }

    }
}
