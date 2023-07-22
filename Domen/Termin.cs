using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    /// <summary>
    /// Predstavlja vremenski termin u kom trenira neka grupa.
    /// 
    /// Sadrzi id, vreme, i grupu.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class Termin
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
        public Grupa? Grupa { get; set; }
        /// <summary>
        /// Id grupe koja trenira u ovom terminu.
        /// </summary>
        public int GrupaID { get; set; }
    }
}
