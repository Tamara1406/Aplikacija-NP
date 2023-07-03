using Domen;
using Microsoft.EntityFrameworkCore;
using PristupPodacima.Repozitorijumi.Interfejsi;

namespace PristupPodacima.Repozitorijumi.Implementacija
{
    public class TerminRepozitorijum : ITerminRepozitorijum
    {
        Context context;
        public TerminRepozitorijum(Context context)
        {
            this.context = context;
        }

        public void Dodaj(Termin t)
        {
            context.Termini.Add(t);
        }

        public void Izmeni(Termin t)
        {
            context.Termini.Update(t);
        }

        public void Obrisi(Termin t)
        {
            context.Termini.Remove(t);
        }

        public List<Termin> Pretrazi(string kriterijum)
        {
            return context.Termini.Where(t => t.Grupa.GrupaIme == kriterijum).ToList();
        }

        public Termin Vrati(int id)
        {
            return context.Termini.Single(t => t.TerminID == id);
        }

        public List<Termin> VratiSve()
        {
            return context.Termini.Include(t => t.Grupa).ToList();
        }
    }
}
