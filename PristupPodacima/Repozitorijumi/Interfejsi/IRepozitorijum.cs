using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupPodacima.Repozitorijumi.Interfejsi
{
    /// <summary>
    /// Interfejs repozitorijum
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public interface IRepozitorijum<T> where T : class
    {
        /// <summary>
        /// Funkcija koja dodaje prosledjeni entitet.
        /// </summary>
        /// <param name="t"></param>
        void Dodaj(T t);
        /// <summary>
        /// Funkcija koja brise prosledjeni entitet.
        /// </summary>
        /// <param name="t"></param>
        void Obrisi(T t);
        /// <summary>
        /// Funkcija koja menja prosledjeni entitet.
        /// </summary>
        /// <param name="t"></param>
        void Izmeni(T t);
        /// <summary>
        /// Funkcija koja vraca sve entiteter iz baze.
        /// </summary>
        /// <returns>lista entiteta</returns>
        List<T> VratiSve();
        /// <summary>
        /// Funkcija koja vraca entitet na osnovu nekog argumenta.
        /// </summary>
        /// <param name="t"></param>
        /// <returns>Entitet</returns>
        T Vrati(int t);
        /// <summary>
        /// Funkcija koja vraca listu entiteta koje pretrazuje na osnovu nekog kriterijuma.
        /// </summary>
        /// <param name="kriterijum"></param>
        /// <returns>lista entiteta</returns>
        List<T> Pretrazi(string kriterijum);


    }
}
