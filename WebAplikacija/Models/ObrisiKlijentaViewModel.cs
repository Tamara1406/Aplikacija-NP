using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebAplikacija.Models
{
    /// <summary>
    /// Predstavlja podatke potrebne za brisanje klijenta koji trenira u teretani.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class ObrisiKlijentaViewModel
    {
        /// <summary>
        /// Id klijenta kao int.
        /// </summary>
        public int KlijentID { get; set; }
        /// <summary>
        /// Ime klijenta kao string.
        /// </summary>
        public string Ime { get; set; }
        /// <summary>
        /// Prezime klijenta kao string.
        /// </summary>
        public string Prezime { get; set; }
        /// <summary>
        /// Kilaza klijenta u kg.
        /// </summary>
        public int Kilaza { get; set; }
        /// <summary>
        /// Visina klijenta u cm.
        /// </summary>
        public int Visina { get; set; }
        /// <summary>
        /// Id pola klijenta.
        /// </summary>
        public int PolID { get; set; }
        /// <summary>
        /// Pol klijenta.
        /// </summary>
        public string Pol { get; set; }
        /// <summary>
        /// Id grupe u kojoj klijent trenira.
        /// </summary>
        public int GrupaID { get; set; }
        /// <summary>
        /// Grupa u kojoj klijent trenira.
        /// </summary>
        public string Grupa { get; set; }


    }
}
