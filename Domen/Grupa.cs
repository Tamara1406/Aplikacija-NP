namespace Domen
{
    /// <summary>
    /// Predstavlja grupu za vezbanje u teretani.
    /// 
    /// Grupa ima id, ime, trenera, i mesto gde se nalazi.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class Grupa
    {
        /// <summary>
        /// Id grupe kao int.
        /// </summary>
        public int GrupaID { get; set; }
        /// <summary>
        /// Ime grupe kao string.
        /// </summary>
        public string GrupaIme { get; set; }
        /// <summary>
        /// Trener koji je zaduzen da trenira grupu.
        /// </summary>
        public Trener Trener { get; set; }
        /// <summary>
        /// Id trenera koji trenira grupu.
        /// </summary>
        public int TrenerID { get; set; }
        /// <summary>
        /// Mesto u kom se nalazi grupa.
        /// </summary>
        public Mesto Mesto { get; set; }
        /// <summary>
        /// Id mesta u kom se nalazi grupa.
        /// </summary>
        public int MestoID { get; set; }
    }
}