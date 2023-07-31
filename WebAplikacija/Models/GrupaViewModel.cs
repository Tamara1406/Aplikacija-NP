using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAplikacija.Models
{
    /// <summary>
    /// Predstavlja grupu za vezbanje u teretani.
    /// 
    /// Koristi se za prikaz svih grupa.
    /// Sadrzi id, ime grupe, trenere, mesta.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class GrupaViewModel
    {
        /// <summary>
        /// Id grupe kao int
        /// </summary>
        public int GrupaID { get; set; }

        /// <summary>
        /// Ime grupe kao string
        /// </summary>
        public string GrupaIme { get; set; }

        /// <summary>
        /// Lista trenera koji rade u teretani.
        /// </summary>
        public List<SelectListItem> Treneri { get; set; }

        /// <summary>
        /// Trener koji je zaduzen za drzanje treninga u grupi.
        /// </summary>
        public string Trener { get; set; }

        /// <summary>
        /// Lista mesta u kojima se nalaze teretane.
        /// </summary>
        public List<SelectListItem> Mesta { get; set; }

        /// <summary>
        /// Mesto u kom se nalazi teretana u kojoj trenira grupa.
        /// </summary>
        public string Mesto { get; set; }
    }
}
