using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Termin
    {
        public int TerminID { get; set; }
        public DateTime VremeTermina { get; set; }
        public Grupa? Grupa { get; set; }
        public int GrupaID { get; set; }
    }
}
