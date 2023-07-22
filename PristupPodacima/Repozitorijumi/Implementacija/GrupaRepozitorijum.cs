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
    /// Predstavlja repozitorijum za upravljanje grupama.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class GrupaRepozitorijum : IGrupaRepozitorijum
    {
        /// <summary>
        /// Kontekst pomocu kog se pristupa bazi.
        /// </summary>
        Context context;
        /// <summary>
        /// Konstruktor klase GrupaRepozitorijum.
        /// 
        /// Dodeljuje vrednost kontekstu.
        /// </summary>
        /// <param name="context"></param>
        public GrupaRepozitorijum(Context context)
        {
            this.context = context;
        }

        /// <summary>
        /// Funkcija koja dodaje prosledjenu grupu u bazu.
        /// </summary>
        /// <param name="t"></param>
        public void Dodaj(Grupa t)
        {
            context.Grupe.Add(t);
        }

        /// <summary>
        /// Funkcija koja vrsi izmenu na prosledjenoj grupi u bazi.
        /// </summary>
        /// <param name="t"></param>
        public void Izmeni(Grupa t)
        {
            context.Grupe.Update(t);
        }

        /// <summary>
        /// FUnkcija koja brise prosledjenu grupu iz baze.
        /// </summary>
        /// <param name="t"></param>
        public void Obrisi(Grupa t)
        {
            context.Grupe.Remove(t);
        }

        /// <summary>
        /// Funkcija koja pretrazuje i vraca sve grupe koje se nalaze u prosledjenom mestu.
        /// </summary>
        /// <param name="mesto"></param>
        /// <returns>lista grupa</returns>
        public List<Grupa> Pretrazi(string mesto)
        {
            return context.Grupe.Where(t => t.Mesto.Naziv == mesto).ToList();
        }

        /// <summary>
        /// Funkcija koja vraca grupu na osnovu argumenta.
        /// </summary>
        /// <param name="t"></param>
        /// <returns>grupa</returns>
        public Grupa Vrati(int t)
        {
            return context.Grupe.Find(t);
        }

        /// <summary>
        /// Funkcija koja vraca sve grupe iz baze.
        /// </summary>
        /// <returns>lista grupa</returns>
        public List<Grupa> VratiSve()
        {
            return context.Grupe.Include(t => t.Trener).Include(t => t.Mesto).ToList();
        }
    }
}
