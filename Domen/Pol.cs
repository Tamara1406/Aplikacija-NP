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
