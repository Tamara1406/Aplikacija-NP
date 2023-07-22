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
    /// Predstavlja repozitorijum za upravljanje klijentima.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class KlijentRepozitorijum : IKlijentRepozitorijum
    {
        /// <summary>
        /// Kontekst pomocu kog se pristupa bazi.
        /// </summary>
        private Context context;

        /// <summary>
        /// Konstruktor klase KlijentRepozitorijum.
        /// 
        /// Dodeljuje vrednost kontekstu.
        /// </summary>
        /// <param name="context"></param>
        public KlijentRepozitorijum(Context context)
        {
            this.context = context;
        }

        /// <summary>
        /// Funkcija koja dodaje prosledjenog klijenta u bazu.
        /// </summary>
        /// <param name="t"></param>
        public void Dodaj(Klijent t)
        {
            context.Klijenti.Add(t);
        }

        /// <summary>
        /// Funkcija koja menja podatke o prosledjenom klijentu u bazi.
        /// </summary>
        /// <param name="t"></param>
        public void Izmeni(Klijent t)
        {
            context.Klijenti.Update(t);
        }

        /// <summary>
        /// Funkcija koj abrise prosledjenog klijenta iz baze.
        /// </summary>
        /// <param name="t"></param>
        public void Obrisi(Klijent t)
        {
            context.Klijenti.Remove(t);
        }

        /// <summary>
        /// Funkcija koja pretrazuje klijente prema imenu i vraca listu klijenata.
        /// </summary>
        /// <param name="ime"></param>
        /// <returns>lista klijenata</returns>
        public List<Klijent> Pretrazi(string ime)
        {
            if (ime == "" || ime == null)
                return context.Klijenti.Include(k => k.Pol).Include(k => k.Grupa).ToList();
            return context.Klijenti.Include(k => k.Pol).Include(k => k.Grupa).ToList().Where(k => k.ImePrezime.Trim().ToLower().StartsWith(ime.Trim().ToLower())).ToList();
        }

        /// <summary>
        /// Funkcija koja vraca klijenta na osnovu prosledjenog id-ja.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>klijent</returns>
        public Klijent Vrati(int id)
        {
            return context.Klijenti.Single(k => k.KlijentID == id);
        }

        
        /// <summary>
        /// Funkcija koja vraca listu svih klijenata.
        /// </summary>
        /// <returns>lista klijenata</returns>
        public List<Klijent> VratiSve()
        {
            return context.Klijenti.Include(k => k.Pol).Include(k => k.Grupa).ToList();
        }
    }
}
