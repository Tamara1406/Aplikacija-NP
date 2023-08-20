using Domen;

namespace WebAplikacija.Models
{
    public class TerminViewModel
    {
        /// <summary>
        /// Id termina kao int.
        /// </summary>
        public int TerminID { get; set; }
        /// <summary>
        /// Vreme u kom se odrzava termin kao DateTime
        /// </summary>
        public DateTime VremeTermina { get; set; }
        /// <summary>
        /// Grupa koja trenira u ovom terminu.
        /// </summary>
        public string Grupa { get; set; }
        /// <summary>
        /// Id grupe koja trenira u ovom terminu.
        /// </summary>
        public int GrupaID { get; set; }
    }
}
