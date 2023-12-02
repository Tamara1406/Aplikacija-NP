using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    /// <summary>
    /// Predstavlja trenera koji radi u treretani.
    /// 
    /// Sadrzi id, ime, prezime, obrazovanje.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class Trener
    {
        /// <summary>
        /// Id trenera kao int.
        /// </summary>
        private int trenerID;
        public int TrenerID
        {
            get { return trenerID; }
            set {
                if (value == null)
                    throw new ArgumentNullException("Vrednost ID-ja je null!");
                trenerID = value; 
            }
        }
        /// <summary>
        /// Ime trenera kao string.
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
                ime = value; }
        }
        /// <summary>
        /// Prezime treneras kao string.
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
                prezime = value; }
        }
        /// <summary>
        /// Obrazovanje trenera koji radi u teretani.
        /// </summary>
        private Obrazovanje obrazovanje;
        public Obrazovanje Obrazovanje
        {
            get { return obrazovanje; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Morate uneti vrednost za obrazovanje!");
                obrazovanje = value; }
        }
        /// <summary>
        /// Id obrazovanja trenera.
        /// </summary>
        private int obrazovanjeID;
        public int ObrazovanjeID
        {
            get { return obrazovanjeID; }
            set { obrazovanjeID = value; }
        }
        /// <summary>
        /// Get metoda koja vraca ime i prezime trenera.
        /// </summary>
        public string ImePrezime
        {
            get => Ime + " " + Prezime;
        }
        /// <summary>
        /// Opis trenera kao string.
        /// </summary>
        private string opis;
        public string Opis
        {
            get { return opis; }
            set
            {
                if (value == null || value.Length == 0)
                    throw new ArgumentNullException("Morate uneti opis!");
                if (value.Length > 50)
                    throw new ArgumentException("Opis je ogranicen na 50 karaktera!");
                opis = value; }
        }
        /// <summary>
        /// Slika trenera kao string koji sadrzi adresu slike.
        /// </summary>
        private string? slika;
        public string? Slika
        {
            get { return slika; }
            set { slika = value; }
        }
    }
}
