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
        public int MestoID { get; set; }
        /// <summary>
        /// Naziv mesta kao string.
        /// </summary>
        public string Naziv { get; set; }
    }
}
