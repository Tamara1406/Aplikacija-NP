using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    /// <summary>
    /// User je admin sistema za teretanu.
    /// 
    /// Nasledjuje IdentityUser klasu i sadrzi ime i prezime.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Ime i prezime User-a.
        /// </summary>
        public string ImePrezime { get; set; }
    }
}
