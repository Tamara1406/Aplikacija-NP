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

        /// <summary>
        /// Vraca ili postavlja id trenera kao int.
        /// </summary>
        /// <param name="value">Novi id trenera koji treba postaviti</param>
        /// <returns>trenutni id trenera</returns>
        /// <exception cref="ArgumentNullException">ako je uneti id trenera jednak null</exception>
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

        /// <summary>
        /// Vraca ili postavlja ime trenera kao string.
        /// </summary>
        /// <param name="value">Novo ime trenera koje treba postaviti</param>
        /// <returns>trenutno ime trenera</returns>
        /// <exception cref="ArgumentNullException">ako je uneto ime trenera jednako null ili prazan string</exception>
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
                ime = value; }
        }
        /// <summary>
        /// Prezime treneras kao string.
        /// </summary>
        private string prezime;

        /// <summary>
        /// Vraca ili postavlja prezime trenera kao string.
        /// </summary>
        /// <param name="value">Novo prezime trenera koje treba postaviti</param>
        /// <returns>trenutno prezime trenera</returns>
        /// <exception cref="ArgumentNullException">ako je uneto prezime trenera jednako null ili prazan string</exception>
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
                prezime = value; }
        }
        /// <summary>
        /// Obrazovanje trenera koji radi u teretani.
        /// </summary>
        private Obrazovanje obrazovanje;

        /// <summary>
        /// Vraca ili postavlja obrazovanje trenera.
        /// </summary>
        /// <param name="value">Novo obrazovanje trenera koje treba postaviti</param>
        /// <returns>trenutno obrazovanje trenera</returns>
        /// <exception cref="ArgumentNullException">ako je uneto obrazovanje trenera jednako null</exception>

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

        /// <summary>
        /// Vraca ili postavlja id obrazovanja trenera kao int.
        /// </summary>
        /// <param name="value">Novi id obrazovanja koji treba postaviti</param>
        /// <returns>trenutni id obrazovanja trenera</returns>
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

        /// <summary>
        /// Vraca ili postavlja opis trenera kao string.
        /// </summary>
        /// <param name="value">Novi opis trenera koji treba postaviti</param>
        /// <returns>trenutni opis trenera</returns>
        /// <exception cref="ArgumentNullException">ako je uneti opis trenera jednak null ili prazan string</exception>
        /// <exception cref="ArgumentException">ako uneti string ima vise od 50 karaktera</exception>
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

        /// <summary>
        /// Vraca ili postavlja sliku trenera kao string.
        /// </summary>
        /// <param name="value">Nova slika trenera koju treba postaviti</param>
        /// <returns>trenutna slika trenera</returns>
        public string? Slika
        {
            get { return slika; }
            set { slika = value; }
        }
    }
}
