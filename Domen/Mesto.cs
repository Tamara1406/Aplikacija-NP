using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    /// <summary>
    /// Predstavlja grad.
    /// 
    /// Sadrzi id i naziv mesta.
    /// 
    /// @author Tamara Maksimovic
    /// </summary>
    public class Mesto
    {
        /// <summary>
        /// Id mesta kao int.
        /// </summary>
        private int mestoID;

        /// <summary>
        /// Vraca ili postavlja id mesta kao int.
        /// </summary>
        /// <param name="value">Novi id mesta koji treba postaviti</param>
        /// <returns>trenutni id mesta</returns>
        /// <exception cref="ArgumentNullException">ako je uneti id mesta jednak null</exception>
        public int MestoID {
            get { return mestoID; }
            set {
                if (value == null)
                    throw new ArgumentNullException("Vrednost ID-ja je null!");
                mestoID = value; }
        }
        /// <summary>
        /// Naziv mesta kao string.
        /// </summary>
        private string naziv;

        /// <summary>
        /// Vraca ili postavlja naziv mesta kao string.
        /// </summary>
        /// <param name="value">Novi naziv mesta koji treba postaviti</param>
        /// <returns>trenutni naziv mesta</returns>
        /// <exception cref="ArgumentNullException">ako je uneti naziv mesta jednak null ili prazan string</exception>
        /// <exception cref="ArgumentException">ako uneti string ima vise od 20 karaktera</exception>
        public string Naziv
        {
            get { return naziv; }
            set {
                if (value == null|| value.Length == 0)
                    throw new ArgumentNullException("Morate uneti vrednost za naziv mesta!");
                if (value.Length > 20)
                    throw new ArgumentException("Naziv mesta je ogranicen na 20 karaktera!");
                naziv = value; }
        }
    }
}
