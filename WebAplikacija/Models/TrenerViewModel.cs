using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAplikacija.Models
{
    /// <summary>
    /// Predstavlja trenera koji radi u teretani i trenira neku grupu.
    /// 
    /// KOristi see za prikaz trenera iz baze.
    /// Sadrzi id, ime, prezime, obrazovanje, imePrezime, opis i sliku trenera.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class TrenerViewModel
    {
        /// <summary>
        /// Id trenera kao int.
        /// </summary>
        public int TrenerID { get; set; }

        /// <summary>
        /// Ime trenera koji radi u teretani, kao string.
        /// </summary>
        public string Ime { get; set; }

        /// <summary>
        /// Prezime trenera koji radi u teretani, kao string.
        /// </summary>
        public string Prezime { get; set; }

        /// <summary>
        /// Stepen obrazovanja trenera koji radi u teretani, kao string.
        /// </summary>
        public string Obrazovanje { get; set; }

        /// <summary>
        /// Ime i prezime trenera koji radi u  teretani, kao string.
        /// </summary>
        public string ImePrezime { get; set; }

        /// <summary>
        /// Opis trenera koji radi u teretani, kao string.
        /// </summary>
        public string Opis { get; set; }

        /// <summary>
        /// Slika trenera koji radi u teretani, preko url adrese kao string.
        /// </summary>
        public string Slika { get; set; }

    }
}
