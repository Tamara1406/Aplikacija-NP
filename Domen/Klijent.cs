using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domen
{
    /// <summary>
    /// Predstavlja klijenta koji vezba u teretani.
    /// 
    /// Sadrzi id, ime ,prezime, kilazu, visinu, grupu za treniranje i pol.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class Klijent
    {
        /// <summary>
        /// Id klijenta koji trenira u teretani.
        /// </summary>
        private int klijentID;
        public int KlijentID
        {
            get { return klijentID; }
            set {
                if (value == null)
                    throw new ArgumentNullException("Vrednost ID-ja je null!");
                klijentID = value; }
        }
        /// <summary>
        /// Ime klijenta koji trenira u teretani.
        /// </summary>
        private string ime;
        public string Ime
        {
            get { return ime; }
            set
            {
                if (value == null || value.Length == 0)
                    throw new ArgumentNullException("Morate uneti vrednost za ime!");
                if (value.Length > 20)
                    throw new ArgumentException("Ime je ograniceno na 20 karaktera!"); 
                ime = value; 
            }
        }
        /// <summary>
        /// Prezime klijenta koji trenira u teretani.
        /// </summary>
        private string prezime;
        public string Prezime
        {
            get { return prezime; }
            set
            {
                if (value == null || value.Length == 0)
                    throw new ArgumentNullException("Morate uneti vrednost za prezime!");
                if (value.Length > 30)
                    throw new ArgumentException("Prezime je ograniceno na 30 karaktera!");
                prezime = value; 
            }
        }
        /// <summary>
        /// Kilaza klijenta u kg.
        /// </summary>
        private int kilaza;
        public int Kilaza
        {
            get { return kilaza; }
            set
            {
                if (value == 0)
                    throw new ArgumentException("Morate uneti vrednost za kilazu!");
                kilaza = value; }
        }
        /// <summary>
        /// Visima klijenta u cm.
        /// </summary>
        private int visina;
        public int Visina
        {
            get { return visina; }
            set
            {
                if (value == 0)
                    throw new ArgumentException("Morate uneti vrednost za visinu!");
                visina = value; }
        }
        /// <summary>
        /// Grupa u kojoj klijent trenira.
        /// </summary>
        private Grupa? grupa;
        public Grupa? Grupa
        {
            get { return grupa; }
            set { grupa = value; }
        }
        /// <summary>
        /// Id grupe u kojoj klijent trenira.
        /// </summary>
        private int grupaID;
        public int GrupaID
        {
            get { return grupaID; }
            set { grupaID = value; }
        }
        /// <summary>
        /// Pol klijenta.
        /// </summary>
        private Pol? pol;
        public Pol? Pol
        {
            get { return pol; }
            set { pol = value; }
        }
        /// <summary>
        /// Id pola klijenta.
        /// </summary>
        private int polID;
        public int PolID
        {
            get { return polID; }
            set { polID = value; }
        }
        /// <summary>
        /// Get metoda koja vraca ime i prezime klijenta kao string.
        /// </summary>
        public string ImePrezime
        {
            get => Ime + " " + Prezime;
        }

    }
}
