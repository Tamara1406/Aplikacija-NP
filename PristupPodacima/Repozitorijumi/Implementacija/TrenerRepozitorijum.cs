using Domen;
using Microsoft.EntityFrameworkCore;
using PristupPodacima.Repozitorijumi.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupPodacima.Repozitorijumi.Implementacija
{
    /// <summary>
    /// Predstavlja repozitorijum za upravljanje trenerima.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class TrenerRepozitorijum : ITrenerRepozitorijum
    {
        /// <summary>
        /// Kontekst pomocu kog se pristupa bazi.
        /// </summary>
        Context context;

        /// <summary>
        /// Konstruktor klase TrenerRepozitorijum.
        /// 
        /// Dodeljuje vrednost kontekstu.
        /// </summary>
        /// <param name="context"></param>
        public TrenerRepozitorijum(Context context)
        {
            this.context = context;
        }

        /// <summary>
        /// Funkcija koja dodaje prosledjenog trenera u bazu.
        /// </summary>
        /// <param name="t"></param>
        public void Dodaj(Trener t)
        {
            context.Treneri.Add(t);
        }

        /// <summary>
        /// Funkcija koja vrsi izmenu na prosledjenom treneru u bazi.
        /// </summary>
        /// <param name="t"></param>
        public void Izmeni(Trener t)
        {
            context.Treneri.Update(t);
        }

        /// <summary>
        /// FUnkcija koja brise prosledjenog trenera iz baze.
        /// </summary>
        /// <param name="t"></param>
        public void Obrisi(Trener t)
        {
            context.Treneri.Remove(t);
        }

        /// <summary>
        /// Funkcija koja pretrazuje i vraca sve trenere sa prosledjenim imenom.
        /// </summary>
        /// <param name="ime"></param>
        /// <returns>lista trenera</returns>
        public List<Trener> Pretrazi(string ime)
        {
            return context.Treneri.Where(t => t.ImePrezime == ime).ToList();
        }

        /// <summary>
        /// Funkcija koja vraca trenera na osnovu id*ja.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>trener</returns>
        public Trener Vrati(int id)
        {
            return context.Treneri.Single(t => t.TrenerID == id);
        }

        /// <summary>
        /// Funkcija koja vraca sve trenere iz baze.
        /// </summary>
        /// <returns>lista trenera</returns>
        public List<Trener> VratiSve()
        {
            return context.Treneri.Include(t => t.Obrazovanje).ToList();
        }
    }
}
