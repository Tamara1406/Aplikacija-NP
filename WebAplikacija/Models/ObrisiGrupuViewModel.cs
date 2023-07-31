using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;

namespace WebAplikacija.Models
{
    /// <summary>
    /// Predstavlja podatke potrebne za brisanje grupe za treniranje u teretani.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class ObrisiGrupuViewModel
    {
        /// <summary>
        /// Id grupe kao int.
        /// </summary>
        public int GrupaID { get; set; }

        /// <summary>
        /// Ime grupe kao string.
        /// </summary>
        public string GrupaIme { get; set; }

        /// <summary>
        /// Id trenera koji drzi treninge grupi.
        /// </summary>
        public int TrenerID { get; set; }

        /// <summary>
        /// Ime trenera koji drzi treninge grupi.
        /// </summary>
        public string Trener { get; set; }

        /// <summary>
        /// Id mesta u kom se nalazi teretana u kojoj je ova grupa.
        /// </summary>
        public int MestoID { get; set; }

        /// <summary>
        /// Naziv mesta u kom se nalazi teretana u kojoj je ova grupa.
        /// </summary>
        public string Mesto { get; set; }
    }
}
