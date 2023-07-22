using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupPodacima.Repozitorijumi.Interfejsi
{
    /// <summary>
    /// Interfejs repozitorijuma pola koji nasledjuje IRepozitorijum sa parametrom Pol
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public interface IPolRepozitorijum : IRepozitorijum<Pol>
    {
    }
}
