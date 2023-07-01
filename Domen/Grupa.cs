namespace Domen
{
    public class Grupa
    {
        public int GrupaID { get; set; }
        public string GrupaIme { get; set; }
        public Trener Trener { get; set; }
        public int TrenerID { get; set; }
        public Mesto Mesto { get; set; }
        public int MestoID { get; set; }
    }
}