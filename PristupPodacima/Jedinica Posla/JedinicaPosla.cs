using PristupPodacima.Repozitorijumi.Implementacija;
using PristupPodacima.Repozitorijumi.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupPodacima.Jedinica_Posla
{
    /// <summary>
    /// Predstavlja jedinincu posla koja nasledjuje interfejs IJedinicaPosla i upravlja repozitorijumima.
    /// </summary>
    public class JedinicaPosla : IJedinicaPosla
    {
        /// <summary>
        /// Kontekst pomocu kog se pristupa bazi.
        /// </summary>
        Context context;
        /// <summary>
        /// Konstruktor kojim se dodeljuje vrednost kontekstu i instanciraju se Repozitorijumi domenskih klasa.
        /// </summary>
        /// <param name="context"></param>
        public JedinicaPosla(Context context)
        {
            this.context = context;
            KlijentRepozitorijum = new KlijentRepozitorijum(context);
            TrenerRepozitorijum = new TrenerRepozitorijum(context);
            GrupaRepozitorijum = new GrupaRepozitorijum(context);
            MestoRepozitorijum = new MestoRepozitorijum(context);
            ObrazovanjeRepozitorijum = new ObrazovanjeRepozitorijum(context);
            PolRepozitorijum = new PolRepozitorijum(context);
            TerminRepozitorijum = new TerminRepozitorijum(context);


        }
        /// <summary>
        /// Get i set metoda za repozitorijum klijenta.
        /// </summary>
        public IKlijentRepozitorijum KlijentRepozitorijum { get; set; }
        /// <summary>
        /// Get i set metoda za repozitorijum trenera.
        /// </summary>
        public ITrenerRepozitorijum TrenerRepozitorijum { get; set; }
        /// <summary>
        /// Get i set metoda za repozitorijum grupe.
        /// </summary>
        public IGrupaRepozitorijum GrupaRepozitorijum { get; set; }
        /// <summary>
        /// Get i set metoda za repozitorijum mesta.
        /// </summary>
        public IMestoRepozitorijum MestoRepozitorijum { get; set; }
        /// <summary>
        /// Get i set metoda za repozitorijum obrazovanja.
        /// </summary>
        public IObrazovanjeRepozitorijum ObrazovanjeRepozitorijum { get; set; }
        /// <summary>
        /// Get i set metoda za repozitorijum pola.
        /// </summary>
        public IPolRepozitorijum PolRepozitorijum { get; set; }
        /// <summary>
        /// Get i set metoda za repozitorijum termina.
        /// </summary>
        public ITerminRepozitorijum TerminRepozitorijum { get; set; }

        /// <summary>
        /// Metoda koja cuva promene napravljene u repozitorijumima.
        /// </summary>
        public void SacuvajPromene()
        {
            context.SaveChanges();
        }
    }
}
