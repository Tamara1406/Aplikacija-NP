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
        public int ObrazovanjeID { get; set; }
        /// <summary>
        /// Stepen obrazovanja kao string.
        /// 
        /// Predstvalja stepen strucne spreme.
        /// </summary>
        public string StepenObrazovanja { get; set; }
    }
}
