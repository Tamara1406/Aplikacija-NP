using Domen;
using PristupPodacima.Repozitorijumi.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupPodacima.Repozitorijumi.Implementacija
{
    /// <summary>
    /// Predstavlja repozitorijum za upravljanje mestima.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class MestoRepozitorijum : IMestoRepozitorijum
    {
        /// <summary>
        /// Kontekst pomocu kog se pristupa bazi.
        /// </summary>
        Context context;

        /// <summary>
        /// Konstruktor klase MestoRepozitorijum.
        /// 
        /// Dodeljuje vrednost kontekstu.
        /// </summary>
        /// <param name="context"></param>
        public MestoRepozitorijum(Context context)
        {
            this.context = context;
        }

        /// <summary>
        /// Funkcija koja dodaje prosledjeno mesto u bazu.
        /// </summary>
        /// <param name="t"></param>
        public void Dodaj(Mesto t)
        {
            context.Mesta.Add(t);
        }

        /// <summary>
        /// Funkcija koja menja proslednjeno mesto u bazi.
        /// </summary>
        /// <param name="t"></param>
        public void Izmeni(Mesto t)
        {
            context.Mesta.Update(t);
        }

        /// <summary>
        /// Funkcija koja brise prosledjeno mesto iz baze.
        /// </summary>
        /// <param name="t"></param>
        public void Obrisi(Mesto t)
        {
            context.Mesta.Remove(t);
        }

        /// <summary>
        /// Funkcija koja pretrazuje mesta na osnovu prosledjenog imena mesta, i vraca listu mesta sa tim imenom.
        /// </summary>
        /// <param name="ime"></param>
        /// <returns>lista mesta</returns>
        public List<Mesto> Pretrazi(string ime)
        {
            return context.Mesta.Where(t => t.Naziv == ime).ToList();
        }

        /// <summary>
        /// Funkcija koja vraca mesto sa prosledjenim id-jem;.
        /// </summary>
        /// <param name="t"></param>
        /// <returns>mesto</returns>
        public Mesto Vrati(int t)
        {
            return context.Mesta.Find(t);   
        }

        /// <summary>
        /// Funkcija koja vraca sva mesta iz baze.
        /// </summary>
        /// <returns>lista mesta</returns>
        public List<Mesto> VratiSve()
        {
            return context.Mesta.ToList();
        }
    }
}
