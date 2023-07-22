using Domen;
using PristupPodacima.Repozitorijumi.Interfejsi;

namespace PristupPodacima.Repozitorijumi.Implementacija
{
    /// <summary>
    /// Predstavlja repozitorijum za upravljanje polovima.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    internal class PolRepozitorijum : IPolRepozitorijum
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
        public PolRepozitorijum(Context context)
        {
            this.context = context;
        }

        /// <summary>
        /// Funkcija koja dodaje prosledjen pol u bazu.
        /// </summary>
        /// <param name="t"></param>
        public void Dodaj(Pol t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Funkcija koja vrsi izmenu na prosledjenom polu u bazi.
        /// </summary>
        /// <param name="t"></param>
        public void Izmeni(Pol t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// FUnkcija koja brise prosledjeni pol iz baze.
        /// </summary>
        /// <param name="t"></param>
        public void Obrisi(Pol t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Funkcija koja pretrazuje i vraca sve grupe prema zadatom kriterijumu.
        /// </summary>
        /// <param name="kriterijum"></param>
        /// <returns>lista polova</returns>
        public List<Pol> Pretrazi(string kriterijum)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Funkcija koja vraca pol na osnovu argumenta.
        /// </summary>
        /// <param name="t"></param>
        /// <returns>pol</returns>
        public Pol Vrati(int t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Funkcija koja vraca sve polove iz baze.
        /// </summary>
        /// <returns>lista polova</returns>
        public List<Pol> VratiSve()
        {
            return context.Pol.ToList();
        }
    }
}
