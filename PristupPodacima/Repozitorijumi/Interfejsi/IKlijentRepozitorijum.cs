using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupPodacima.Repozitorijumi.Interfejsi
{
    /// <summary>
    /// Interfejs repozitorijuma klijenta koji nasledjuje IRepozitorijum sa parametrom Klijent
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public interface IKlijentRepozitorijum : IRepozitorijum<Klijent>
    {
    }
}
