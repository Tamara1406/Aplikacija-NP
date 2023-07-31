namespace WebAplikacija.Models
{
    /// <summary>
    /// Predstavlja podatke potrebne za pretragu klijenata koji treniraju u teretani.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class PretraziKlijentaViewModel
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
        /// Ime i prezime klijenta kao string.
        /// </summary>
        public string ImePrezime { get; set; }
        /// <summary>
        /// Kilaza klijenta u kg.
        /// </summary>
        public int Kilaza { get; set; }
        /// <summary>
        /// Visina klijenta u cm.
        /// </summary>
        public int Visina { get; set; }
        /// <summary>
        /// Naziv grupe u kojoj klijent trenira.
        /// </summary>
        public string Grupa { get; set; }
        /// <summary>
        /// Pol klijenta kao string.
        /// </summary>
        public string Pol { get; set; }
    }
}
