using Domen;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAplikacija.Models
{
    /// <summary>
    /// Predstavlja podatke potrebne za pretragu grupe za treniranje u teretani.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class PretraziGrupuViewModel
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
        /// Lista svih trenera koji rade u teretani.
        /// </summary>
        public List<SelectListItem> Treneri { get; set; }
        /// <summary>
        /// Id trenera koji drzi treninge grupi.
        /// </summary>
        public int TrenerID { get; set; }
        /// <summary>
        /// Ime trenera koji drzi treninge grupi.
        /// </summary>
        public string Trener { get; set; }
        /// <summary>
        /// Lista svih mesta u kojima se nalaze teretane.
        /// </summary>
        public List<SelectListItem> Mesta { get; set; }
        /// <summary>
        /// Mesto u kom se nalazi teretana u kojoj trenira grupa.
        /// </summary>
        public string Mesto { get; set; }
    }
}
