using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    /// <summary>
    /// Predstavlja pol osobe.
    /// 
    /// Sadrzi id i naziv pola.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class Pol
    {
        /// <summary>
        /// Id pola kao int.
        /// </summary>
        private int polID;

        /// <summary>
        /// Vraca ili postavlja id pola kao int.
        /// </summary>
        /// <param name="value">Novi id pola koji treba postaviti</param>
        /// <returns>trenutni id pola</returns>
        /// <exception cref="ArgumentNullException">ako je uneti id pola jednak null</exception>
        public int PolID
        {
            get { return polID; }
            set {
                if (value == null)
                    throw new ArgumentNullException("Vrednost ID-ja je null!");
                polID = value; }
        }
        /// <summary>
        /// Naziv pola kao string.
        /// </summary>
        private string polNaziv;

        /// <summary>
        /// Vraca ili postavlja naziv pola kao string.
        /// </summary>
        /// <param name="value">Novi naziv pola koji treba postaviti</param>
        /// <returns>trenutni naziv pola</returns>
        /// <exception cref="ArgumentNullException">ako je uneti naziv pola jednak null</exception>
        public string PolNaziv
        {
            get { return polNaziv; }
            set {
                if (value == null)
                    throw new ArgumentNullException("Vrednost je null!"); 
                polNaziv = value; }
        }
    }
}
