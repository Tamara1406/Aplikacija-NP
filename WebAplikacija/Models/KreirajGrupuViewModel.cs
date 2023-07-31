using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebAplikacija.Models
{
    /// <summary>
    /// Predstavlja podatke potrebne za kreiranje nove grupe za treniranje u teretani.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class KreirajGrupuViewModel
    {
        /// <summary>
        /// Id grupe kao int.
        /// </summary>
        public int GrupaID { get; set; }

        /// <summary>
        /// Ime grupe kao string.
        /// </summary>
        [Required(ErrorMessage = "Morate uneti naziv grupe!")]
        public string GrupaIme { get; set; }

        /// <summary>
        /// Lista trenera koji rade u teretani.
        /// </summary>
        public List<SelectListItem>? Treneri { get; set; }

        /// <summary>
        /// Id trenera koji trenira grupu.
        /// </summary>
        public int TrenerID { get; set; }

        /// <summary>
        /// Lista mesta u kojima se nalaze teretane.
        /// </summary>
        public List<SelectListItem>? Mesta { get; set; }

        /// <summary>
        /// Id mest au kom se nalazi grupa.
        /// </summary>
        public int MestoID { get; set; }


    }
}
