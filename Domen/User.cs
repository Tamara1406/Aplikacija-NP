﻿using Microsoft.AspNetCore.Identity;
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
        private string imePrezime;
        public string ImePrezime
        {
            get { return imePrezime; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Morate uneti vrednost za ime i prezime!");
                if (value.Length == 0)
                    throw new ArgumentException("Morate uneti vrednost za ime i prezime!"); 
                imePrezime = value; }
        }
    }
}
