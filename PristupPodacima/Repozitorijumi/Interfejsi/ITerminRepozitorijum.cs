using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupPodacima.Repozitorijumi.Interfejsi
{
    /// <summary>
    /// Interfejs repozitorijuma termina koji nasledjuje IRepozitorijum sa parametrom Termin
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public interface ITerminRepozitorijum : IRepozitorijum<Termin>
    {
    }
}
