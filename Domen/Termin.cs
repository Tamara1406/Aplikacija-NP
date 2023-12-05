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

        /// <summary>
        /// Vraca ili postavlja id termina kao int.
        /// </summary>
        /// <param name="value">Novi id termina koji treba postaviti</param>
        /// <returns>trenutni id termina</returns>
        /// <exception cref="ArgumentNullException">ako je uneti id termina jednak null</exception>
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

        /// <summary>
        /// Vraca ili postavlja vreme termina kao DateTime.
        /// </summary>
        /// <param name="value">Novo vreme termina koje treba postaviti</param>
        /// <returns>trenutno vreme termina</returns>
        /// <exception cref="ArgumentNullException">ako je uneto vreme termina jednako null</exception>
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

        /// <summary>
        /// Vraca ili postavlja grupu koja trenira u tom temrinu.
        /// </summary>
        /// <param name="value">Nova grupa koju treba postaviti u taj termin</param>
        /// <returns>trenutna grupa koja trenira u tom terminu</returns>
        public Grupa? Grupa
        {
            get { return grupa; }
            set { grupa = value; }
        }
        /// <summary>
        /// Id grupe koja trenira u ovom terminu.
        /// </summary>
        private int grupaID;

        /// <summary>
        /// Vraca ili postavlja id grupe koja trenira u tom terminu.
        /// </summary>
        /// <param name="value">Novi id grupe koji treba postaviti za taj termin</param>
        /// <returns>trenutni id grupekoja trenira u tom terminu</returns>
        public int GrupaID
        {
            get { return grupaID; }
            set { grupaID = value; }
        }
    }
}
