using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupPodacima.Repozitorijumi.Interfejsi
{
    /// <summary>
    /// Interfejs repozitorijuma obrazovanja koji nasledjuje IRepozitorijum sa parametrom Obrazovanje
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public interface IObrazovanjeRepozitorijum : IRepozitorijum<Obrazovanje>
    {
    }
}
