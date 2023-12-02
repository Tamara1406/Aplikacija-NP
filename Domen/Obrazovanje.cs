using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    /// <summary>
    /// Predstavlja nivo obrazovanja neke osobe.
    /// 
    /// Sadrzi id i stepen strucne spreme.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class Obrazovanje
    {
        /// <summary>
        /// Id obrazovanja kao int.
        /// </summary>
        private int obrazovanjeID;
        public int ObrazovanjeID
        {
            get { return obrazovanjeID; }
            set {
                if (value == null)
                    throw new ArgumentNullException("Vrednost ID-ja je null!");
                obrazovanjeID = value; }
        }
        /// <summary>
        /// Stepen obrazovanja kao string.
        /// 
        /// Predstvalja stepen strucne spreme.
        /// </summary>
        private string stepenObrazovanja;
        public string StepenObrazovanja
        {
            get { return stepenObrazovanja; }
            set 
            { 
                if(value == null || value.Length == 0)
                    throw new ArgumentNullException("Morate uneti vrednost za stepen obrazovanja!");
                if (value.Length > 20)
                    throw new ArgumentException("Stepen obrazovanja je ogranicen na 20 karaktera!");
                stepenObrazovanja = value; 
            }
        }
    }
}
