using Domen;
using Microsoft.EntityFrameworkCore;
using PristupPodacima.Repozitorijumi.Interfejsi;

namespace PristupPodacima.Repozitorijumi.Implementacija
{
    /// <summary>
    /// Predstavlja repozitorijum za upravljanje terminima.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class TerminRepozitorijum : ITerminRepozitorijum
    {
        /// <summary>
        /// Kontekst pomocu kog se pristupa bazi.
        /// </summary>
        Context context;

        /// <summary>
        /// Konstruktor klase PolRepozitorijum.
        /// 
        /// Dodeljuje vrednost kontekstu.
        /// </summary>
        /// <param name="context"></param>
        public TerminRepozitorijum(Context context)
        {
            this.context = context;
        }

        /// <summary>
        /// Funkcija koja dodaje prosledjen termin u bazu.
        /// </summary>
        /// <param name="t"></param>
        public void Dodaj(Termin t)
        {
            context.Termini.Add(t);
        }

        /// <summary>
        /// Funkcija koja vrsi izmenu na prosledjenom terminu u bazi.
        /// </summary>
        /// <param name="t"></param>
        public void Izmeni(Termin t)
        {
            context.Termini.Update(t);
        }

        /// <summary>
        /// FUnkcija koja brise prosledjeni termin iz baze.
        /// </summary>
        /// <param name="t"></param>
        public void Obrisi(Termin t)
        {
            context.Termini.Remove(t);
        }

        /// <summary>
        /// Funkcija koja pretrazuje i vraca sve termine na osnovu prosledjenog kriterijuma.
        /// </summary>
        /// <param name="kriterijum"></param>
        /// <returns>lista termina</returns>
        public List<Termin> Pretrazi(string kriterijum)
        {
            return context.Termini.Where(t => t.Grupa.GrupaIme == kriterijum).ToList();
        }

        /// <summary>
        /// Funkcija koja vraca termin na osnovu id-ja.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>termin</returns>
        public Termin Vrati(int id)
        {
            return context.Termini.Single(t => t.TerminID == id);
        }

        /// <summary>
        /// Funkcija koja vraca sve termine iz baze.
        /// </summary>
        /// <returns>lista termina</returns>
        public List<Termin> VratiSve()
        {
            return context.Termini.Include(t => t.Grupa).ToList();
        }
    }
}
