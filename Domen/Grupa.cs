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

        /// <summary>
        /// Vraca ili postavlja Id grupe kao int.
        /// </summary>
        /// <param name="value">Novi id koji treba postaviti</param>
        /// <returns>trenutni id grupe</returns>
        /// <exception cref="ArgumentNullException">ako je uneti id jednak null</exception>
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
        /// <summary>
        /// Vraca ili postavlja ime grupe kao string.
        /// </summary>
        /// <param name="value">Novo ime grupe koje treba postaviti</param>
        /// <returns>trenutno ime grupe</returns>
        /// <exception cref="ArgumentNullException">ako je uneto ime grupe jednao null ili prazan string</exception>
        /// <exception cref="ArgumentException">ako uneti string ima vise od 20 karaktera</exception>
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
        /// <summary>
        /// Vraca ili postavlja trener koji je zaduzen da trenira grupu.
        /// </summary>
        /// <param name="value">Novog trenera kojeg treba postaviti</param>
        /// <returns>trenutnog trenera grupe</returns>
        public Trener Trener { 
            get { return trener; }
            set {
                trener = value; }
        }
        /// <summary>
        /// Id trenera koji trenira grupu.
        /// </summary>
        private int trenerID;
        /// <summary>
        /// Vraca ili postavlja Id trenera koji trenira grupu.
        /// </summary>
        /// <param name="value">Novi id trenera koji treba postaviti</param>
        /// <returns>trenutni id trenera</returns>
        public int TrenerID
        {
            get { return trenerID; }
            set { trenerID = value; }
        }
        /// <summary>
        /// Mesto u kom se nalazi grupa.
        /// </summary>
        private Mesto mesto;
        /// <summary>
        /// Vraca ili postavlja mesto u kom se nalazi grupa.
        /// </summary>
        /// <param name="value">Novo mesto koje treba postaviti</param>
        /// <returns>trenutno mesto u kom se nalazi grupa</returns>
        public Mesto Mesto {
            get { return mesto; }
            set {
                mesto = value; }
        }
        /// <summary>
        /// Id mesta u kom se nalazi grupa.
        /// </summary>
        private int mestoID;
        /// <summary>
        /// Vraca ili postavlja Id mesta u kom se nalazi grupa.
        /// </summary>
        /// <param name="value">Novi id mesta koji treba postaviti</param>
        /// <returns>trenutni id mesta</returns>
        public int MestoID {
            get { return mestoID; }
            set { mestoID = value; }
        }
    }
}