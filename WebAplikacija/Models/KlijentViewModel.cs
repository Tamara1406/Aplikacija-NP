namespace WebAplikacija.Models
{
    /// <summary>
    /// Predstavlja klijenta koji trenira u teretani.
    /// 
    /// KOristi se za prikaz klijenata iz baze.
    /// Sadrzi id, ime ,prezime, imePrezime, kilazu, visinu, grupu i pol.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class KlijentViewModel
    {
        /// <summary>
        /// Id klijenta kao int.
        /// </summary>
        public int KlijentID { get; set; }

        /// <summary>
        /// Ime klijenta koji trenira u teretani kao string.
        /// </summary>
        public string Ime { get; set; }

        /// <summary>
        /// Prezime klijenta koji trenira u teretani kao string.
        /// </summary>
        public string Prezime { get; set; }

        /// <summary>
        /// Ime i prezime klijenta koji trenira u teretani kao string.
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
        /// Grupa u kojoj klijent trenira.
        /// </summary>
        public string Grupa { get; set; }

        /// <summary>
        /// Pol klijenta.
        /// </summary>
        public string Pol { get; set; }

    }
}
