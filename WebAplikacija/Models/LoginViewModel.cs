using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebAplikacija.Models
{
    /// <summary>
    /// Predstavlja klasu za prijavljivanje admina na sajt.
    /// 
    /// Sadrzi korisnicko ime i lozinku.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Korisnicko ime admina za prijavljivanje, kao string.
        /// </summary>
        [Required(ErrorMessage = "Morate uneti korisnicko ime!")]
        public string KorisnickoIme { get; set; }

        /// <summary>
        /// Lozinka admina za prijavljivanje, kao string.
        /// </summary>
        [Required(ErrorMessage = "Morate uneti lozinku!")]
        public string Lozinka { get; set; }
    }
}
