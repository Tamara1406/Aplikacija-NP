namespace WebAplikacija.Models
{
    /// <summary>
    /// Predstavlja mesto u kom se nalazi teretana.
    /// 
    /// Koristi se za prikaz mestra iz baze.
    /// Sadrzi id i naziv mesta.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class MestoViewModel
    {
        /// <summary>
        /// Id mesta kao int.
        /// </summary>
        public int MestoID { get; set; }

        /// <summary>
        /// Naziv mesta u kom se nalazi teretana, kao string.
        /// </summary>
        public string Naziv { get; set; }
    }
}
