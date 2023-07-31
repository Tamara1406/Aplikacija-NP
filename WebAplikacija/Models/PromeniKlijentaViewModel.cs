﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebAplikacija.Models
{
    /// <summary>
    /// Predstavlja podatke potrebne za promenu podataka o  klijentu koji treniraju u teretani.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class PromeniKlijentaViewModel
    {
        /// <summary>
        /// Id klijenta kao int.
        /// </summary>
        public int KlijentID { get; set; }
        /// <summary>
        /// Ime klijenta kao string.
        /// </summary>
        [Required(ErrorMessage = "Morate uneti ime!")]
        public string Ime { get; set; }
        /// <summary>
        /// Prezime klijenta kao string.
        /// </summary>
        [Required(ErrorMessage = "Morate uneti prezime!")]
        public string Prezime { get; set; }
        /// <summary>
        /// Kilaza klijenta u kg.
        /// </summary>
        [Required(ErrorMessage = "Morate uneti kilažu!")]
        public int Kilaza { get; set; }
        /// <summary>
        /// Visina klijenta u cm.
        /// </summary>
        [Required(ErrorMessage = "Morate uneti visinu!")]
        public int Visina { get; set; }
        /// <summary>
        /// Id pola klijenta.
        /// </summary>
        public int PolID { get; set; }
        /// <summary>
        /// Lista polova.
        /// </summary>
        public List<SelectListItem>? Polovi { get; set; }
        /// <summary>
        /// Id grupe u kojoj klijenta trenira.
        /// </summary>
        public int GrupaID { get; set; }
        /// <summary>
        /// Lista svih grupa u teretani.
        /// </summary>
        public List<SelectListItem>? Grupe { get; set; }


    }
}