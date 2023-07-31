namespace WebAplikacija.Models
{
    /// <summary>
    /// Predstavlja podatke potrebne za pretragu trenera koji rade u teretani.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class PretraziTreneraViewModel
    {
        /// <summary>
        /// Id trenera kao int.
        /// </summary>
        public int TrenerID { get; set; }
        /// <summary>
        /// Ime trenera kao string.
        /// </summary>
        public string Ime { get; set; }
        /// <summary>
        /// Prezime trenera kao string.
        /// </summary>
        public string Prezime { get; set; }
        /// <summary>
        /// Strucna sprema trenera koji radi u teretani kao string.
        /// </summary>
        public string Obrazovanje { get; set; }
        /// <summary>
        /// Ime i prezime trenera kao string.
        /// </summary>
        public string ImePrezime { get; set; }
        /// <summary>
        /// Opis trenera kao string.
        /// </summary>
        public string Opis { get; set; }
        /// <summary>
        /// Url adresa slike trenera kao string.
        /// </summary>
        public string? Slika { get; set; }
    }
}
