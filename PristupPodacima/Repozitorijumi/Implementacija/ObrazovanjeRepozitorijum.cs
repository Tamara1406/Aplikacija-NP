using Domen;
using PristupPodacima.Repozitorijumi.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupPodacima.Repozitorijumi.Implementacija
{
    // <summary>
    /// Predstavlja repozitorijum za upravljanje obrazovanjem.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class ObrazovanjeRepozitorijum : IObrazovanjeRepozitorijum
    {
        /// <summary>
        /// Kontekst pomocu kog se pristupa bazi.
        /// </summary>
        Context context;

        /// <summary>
        /// Konstruktor klase ObrazovanjeRepozitorijum.
        /// 
        /// Dodeljuje vrednost kontekstu.
        /// </summary>
        /// <param name="context"></param>
        public ObrazovanjeRepozitorijum(Context context)
        {
            this.context = context;
        }

        /// <summary>
        /// Funkcija koja dodaje prosledjeno obrazovanje u bazu.
        /// </summary>
        /// <param name="t"></param>
        public void Dodaj(Obrazovanje t)
        {
            context.Obrazovanja.Add(t);
        }

        /// <summary>
        /// Funkcija koja vrsi izmenu na prosledjenom obrazovanju u bazi.
        /// </summary>
        /// <param name="t"></param>
        public void Izmeni(Obrazovanje t)
        {
            context.Obrazovanja.Update(t);
        }

        /// <summary>
        /// FUnkcija koja brise prosledjeno o brazovanje iz baze.
        /// </summary>
        /// <param name="t"></param>
        public void Obrisi(Obrazovanje t)
        {
            context.Obrazovanja.Remove(t);
        }

        /// <summary>
        /// Funkcija koja pretrazuje i vraca sva obrazovanja prema prosledjenom kriterijumu o stepenu obrazovanja.
        /// </summary>
        /// <param name="kriterijum"></param>
        /// <returns>lista obrazovanja</returns>
        public List<Obrazovanje> Pretrazi(string kriterijum)
        {
            return context.Obrazovanja.Where(t => t.StepenObrazovanja == kriterijum).ToList();
        }

        /// <summary>
        /// Funkcija koja vraca obrazovanje na osnovu argumenta.
        /// </summary>
        /// <param name="t"></param>
        /// <returns>obrazovanje</returns>
        public Obrazovanje Vrati(int t)
        {
            return context.Obrazovanja.Find(t);
        }

        /// <summary>
        /// Funkcija koja vraca sva obrazovanja iz baze.
        /// </summary>
        /// <returns>lista obrazovanja</returns>
        public List<Obrazovanje> VratiSve()
        {
            return context.Obrazovanja.ToList();
        }
    }
}
