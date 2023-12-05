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

        /// <summary>
        /// Vraca ili postavlja id klijenta kao int.
        /// </summary>
        /// <param name="value">Novi id klijenta koji treba postaviti</param>
        /// <returns>trenutni id klijenta</returns>
        /// <exception cref="ArgumentNullException">ako je uneti id klijenta jednak null</exception>
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

        /// <summary>
        /// Vraca ili postavlja ime klijenta kao string.
        /// </summary>
        /// <param name="value">Novo ime klijenta koje treba postaviti</param>
        /// <returns>trenutno ime klijenta</returns>
        /// <exception cref="ArgumentNullException">ako je uneto ime klijenta jednako null ili prazan string</exception>
        /// <exception cref="ArgumentException">ako uneti string ima vise od 20 karaktera</exception>
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

        /// <summary>
        /// Vraca ili postavlja prezime klijenta kao string.
        /// </summary>
        /// <param name="value">Novo prezime klijenta koje treba postaviti</param>
        /// <returns>trenutno prezime klijenta</returns>
        /// <exception cref="ArgumentNullException">ako je uneto prezime klijneta jednako null ili prazan string</exception>
        /// <exception cref="ArgumentException">ako uneti string ima vise od 30 karaktera</exception>
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

        /// <summary>
        /// Vraca ili postavlja kilazu kao int.
        /// </summary>
        /// <param name="value">Nova kilaza klijenta koju treba postaviti</param>
        /// <returns>trenutna kilaza klijenta</returns>
        /// <exception cref="ArgumentException">ako je uneta kilaza klijenta jednaka null</exception>
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

        /// <summary>
        /// Vraca ili postavlja visinu kao int.
        /// </summary>
        /// <param name="value">Nova visina klijenta koju treba postaviti</param>
        /// <returns>trenutna visina klijenta</returns>
        /// <exception cref="ArgumentException">ako je uneta visina klijenta jednaka null</exception>
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

        /// <summary>
        /// Vraca ili postavlja grupu u kojoj klijent trenira.
        /// </summary>
        /// <param name="value">Nova grupa klijenta koju treba postaviti</param>
        /// <returns>trenutna grupa klijenta</returns>
        public Grupa? Grupa
        {
            get { return grupa; }
            set { grupa = value; }
        }
        /// <summary>
        /// Id grupe u kojoj klijent trenira.
        /// </summary>
        private int grupaID;

        /// <summary>
        /// Vraca ili postavlja id grupe u kojoj klijent trenira.
        /// </summary>
        /// <param name="value">Novi id grupe koji treba postaviti</param>
        /// <returns>trenutni id grupe u kojoj klijent trenira</returns>
        public int GrupaID
        {
            get { return grupaID; }
            set { grupaID = value; }
        }
        /// <summary>
        /// Pol klijenta.
        /// </summary>
        private Pol? pol;

        /// <summary>
        /// Vraca ili postavlja pol klijenta.
        /// </summary>
        /// <param name="value">Novi pol klijenta koji treba postaviti</param>
        /// <returns>trenutni pol klijenta</returns>
        public Pol? Pol
        {
            get { return pol; }
            set { pol = value; }
        }
        /// <summary>
        /// Id pola klijenta.
        /// </summary>
        private int polID;

        /// <summary>
        /// Vraca ili postavlja id pola klijenta.
        /// </summary>
        /// <param name="value">Novi id pola koji treba postaviti</param>
        /// <returns>trenutni id pola klijenta</returns>
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
