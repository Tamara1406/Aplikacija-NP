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
        private int grupaID;
        public int GrupaID {
            get { return grupaID; }
            set {
                if (value == null)
                    throw new ArgumentNullException("Vrednost ID-ja je null!");
                grupaID = value; }
        }
        /// <summary>
        /// Ime grupe kao string.
        /// </summary>
        private string grupaIme;
        public string GrupaIme {
            get { return grupaIme; }
            set {
                if (value == null || value.Length == 0)
                    throw new ArgumentNullException("Morate uneti vrednost za ime!");
                if (value.Length > 20)
                    throw new ArgumentException("Ime je ograniceno na 20 karaktera!");
                grupaIme = value; } 
        }
        /// <summary>
        /// Trener koji je zaduzen da trenira grupu.
        /// </summary>
        private Trener trener;
        public Trener Trener { 
            get { return trener; }
            set {
                trener = value; }
        }
        /// <summary>
        /// Id trenera koji trenira grupu.
        /// </summary>
        private int trenerID;
        public int TrenerID
        {
            get { return trenerID; }
            set { trenerID = value; }
        }
        /// <summary>
        /// Mesto u kom se nalazi grupa.
        /// </summary>
        private Mesto mesto;
        public Mesto Mesto {
            get { return mesto; }
            set {
                mesto = value; }
        }
        /// <summary>
        /// Id mesta u kom se nalazi grupa.
        /// </summary>
        private int mestoID;
        public int MestoID {
            get { return mestoID; }
            set { mestoID = value; }
        }
    }
}