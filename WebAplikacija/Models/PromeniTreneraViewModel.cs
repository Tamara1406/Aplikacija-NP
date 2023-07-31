using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebAplikacija.Models
{
    /// <summary>
    /// Predstavlja podatke potrebne za promenu podataka o treneru koji radi u teretani.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class PromeniTreneraViewModel
    {
        /// <summary>
        /// Id trenera kao int.
        /// </summary>
        public int TrenerID { get; set; }
        /// <summary>
        /// Ime trenera kao string.
        /// </summary>
        [Required(ErrorMessage = "Morate uneti ime!")]
        public string Ime { get; set; }
        /// <summary>
        /// Prezime trenera kao string.
        /// </summary>
        [Required(ErrorMessage = "Morate uneti prezime!")]
        public string Prezime { get; set; }
        /// <summary>
        /// Id strucne spreme trenera kao int.
        /// </summary>
        public int ObrazovanjeID { get; set; }
        /// <summary>
        /// Lista svih nivoa strucne spreme trenera.
        /// </summary>
        public List<SelectListItem>? Obrazovanja { get; set; }
        /// <summary>
        /// Opis trenera kao string.
        /// </summary>
        [Required(ErrorMessage = "Morate uneti opis!")]
        public string Opis { get; set; }
        /// <summary>
        /// Url adresa slike trenera kao string.
        /// </summary>
        public string Slika { get; set; }
    }
}
