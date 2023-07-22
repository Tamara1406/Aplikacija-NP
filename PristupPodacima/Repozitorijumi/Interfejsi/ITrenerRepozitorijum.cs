using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupPodacima.Repozitorijumi.Interfejsi
{
    /// <summary>
    /// Interfejs repozitorijuma trenera koji nasledjuje IRepozitorijum sa parametrom Trener
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public interface ITrenerRepozitorijum : IRepozitorijum<Trener>
    {
    }
}
