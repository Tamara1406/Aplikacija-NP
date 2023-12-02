using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        private int terminID;
        public int TerminID
        {
            get { return terminID; }
            set {
                if (value == null)
                    throw new ArgumentNullException("Vrednost ID-ja je null!");
                terminID = value; }
        }
        /// <summary>
        /// Vreme u kom se odrzava termin kao DateTime
        /// </summary>
        private DateTime vremeTermina;
        public DateTime VremeTermina
        {
            get { return vremeTermina; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Morate uneti vrednost za vreme termina!");
                vremeTermina = value; }
        }
        /// <summary>
        /// Grupa koja trenira u ovom terminu.
        /// </summary>
        private Grupa? grupa;
        public Grupa? Grupa
        {
            get { return grupa; }
            set { grupa = value; }
        }
        /// <summary>
        /// Id grupe koja trenira u ovom terminu.
        /// </summary>
        private int grupaID;
        public int GrupaID
        {
            get { return grupaID; }
            set { grupaID = value; }
        }
    }
}
