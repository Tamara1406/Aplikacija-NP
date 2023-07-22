using PristupPodacima.Repozitorijumi.Interfejsi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupPodacima.Jedinica_Posla
{
    /// <summary>
    /// Interfejs koji predstavlja jedinicu posla koja upravlja repozitorijumima.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public interface IJedinicaPosla
    {
        /// <summary>
        /// Get i set metoda za repozitorijum klijenta.
        /// </summary>
        public IKlijentRepozitorijum KlijentRepozitorijum { get; set; }
        /// <summary>
        /// Get i set metoda za repozitorijum trenera.
        /// </summary>
        public ITrenerRepozitorijum TrenerRepozitorijum { get; set; }
        /// <summary>
        /// Get i set metoda za repozitorijum mesta.
        /// </summary>
        public IMestoRepozitorijum MestoRepozitorijum { get; set; }
        /// <summary>
        /// Get i set metoda za repozitorijum grupe.
        /// </summary>
        public IGrupaRepozitorijum GrupaRepozitorijum { get; set; }
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
        void SacuvajPromene();
    }
}
