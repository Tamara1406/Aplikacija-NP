using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupPodacima.Repozitorijumi.Interfejsi
{
    /// <summary>
    /// Interfejs repozitorijuma grupe koji nasledjuje IRepozitorijum sa parametrom Grupa
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public interface IGrupaRepozitorijum : IRepozitorijum<Grupa>
    {
    }
}
