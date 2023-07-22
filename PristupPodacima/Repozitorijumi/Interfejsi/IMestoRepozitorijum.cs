using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupPodacima.Repozitorijumi.Interfejsi
{
    /// <summary>
    /// Interfejs repozitorijuma mesta koji nasledjuje IRepozitorijum sa parametrom Mesto
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public interface IMestoRepozitorijum : IRepozitorijum<Mesto>
    {
    }
}
