using Domen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PristupPodacima.Jedinica_Posla;
using System.Data;
using System.Text.Json;
using WebAplikacija.Models;

namespace WebAplikacija.Controllers
{
    /// <summary>
    /// Predstavlja klasu koja upravlja stranicama o grupama .
    /// 
    /// Nasledjuje klasu Controller.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class GrupaController : Controller
    {
        /// <summary>
        /// Predstavlja jedinincu posla koja upravlja repozitorijumima.
        /// </summary>
        private readonly IJedinicaPosla jedinicaPosla;
        /// <summary>
        /// Konstruktor kojim se dodeljuje vrednost jedinici posla.
        /// </summary>
        /// <param name="jedinicaPosla">Jedinica posla koja upravlja repozitorijumima</param>
        public GrupaController(IJedinicaPosla jedinicaPosla)
        {
            this.jedinicaPosla = jedinicaPosla;
        }

        /// <summary>
        /// Metoda koja vraca stranicu sa listom svih grupa koje postoje u teretani.
        /// </summary>
        /// <returns>stranica sa listom grupa</returns>
        public async Task<IActionResult> Index()
        {
            List<GrupaViewModel> model = jedinicaPosla
                .GrupaRepozitorijum
                .VratiSve()
                .Select(g => new GrupaViewModel
                {
                    GrupaIme = g.GrupaIme,
                    Trener = g.Trener.ImePrezime,
                    Mesto = g.Mesto.Naziv
                })
                .ToList();

            
            return View(model);
        }

        /// <summary>
        /// Metoda koja vraca stranicu sa listom svih grupa koje postoje u teretani.
        /// 
        /// Pristup stranici imaju samo admini i treneri.
        /// 
        /// </summary>
        /// <returns>stranica sa listom grupa</returns>
        [Authorize(Roles ="Admin, Trener")]
        public async Task<IActionResult> IndexAdmin()
        {
            List<GrupaViewModel> model = jedinicaPosla
                .GrupaRepozitorijum
                .VratiSve()
                .Select(g => new GrupaViewModel
                {
                    GrupaID = g.GrupaID,
                    GrupaIme = g.GrupaIme,
                    Trener = g.Trener.ImePrezime,
                    Mesto = g.Mesto.Naziv
                })
                .ToList();

            string fileName = "Grupe.txt";
            string jsonString = JsonSerializer.Serialize(model);

            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                await streamWriter.WriteAsync(jsonString);
            }
            return View(model);
        }

        /// <summary>
        /// Metoda koja vraca stranicu na kojoj se pretrazuju grupe prema kriterijumu.
        /// 
        /// Kriterijum za pretragu je naziv grupe.
        /// </summary>
        /// <param name="naziv">naziv grupe kao string</param>
        /// <returns>stranica za pretragu grupa</returns>
        public IActionResult Pretrazi(string naziv)
        {
            List<PretraziGrupuViewModel> model = jedinicaPosla
                .GrupaRepozitorijum
                .VratiSve()
                .Select(g => new PretraziGrupuViewModel
                {
                    GrupaIme = g.GrupaIme,
                    TrenerID = g.Trener.TrenerID,
                    Trener = g.Trener.ImePrezime,
                    Mesto = g.Mesto.Naziv
                })
                .ToList();

            List<PretraziGrupuViewModel> nova = new List<PretraziGrupuViewModel>();

            foreach(var item in model)
            {
                if(item.Mesto.Equals(naziv))
                    nova.Add(item);
            }

            
            return View(nova);
        }

        /// <summary>
        /// Metoda koja vraca stranicu na kojoj se pretrazuju grupe prema treneru koji trenira grupu.
        /// 
        /// Kriterijum za pretragu je ime trenera.
        /// </summary>
        /// <param name="trener">ime trenera grupe kao string</param>
        /// <returns>stranica za pretragu grupe</returns>
        public IActionResult PretraziTrener(int trener)
        {
            List<PretraziGrupuViewModel> model = jedinicaPosla
                .GrupaRepozitorijum
                .VratiSve()
                .Select(g => new PretraziGrupuViewModel
                {
                    GrupaIme = g.GrupaIme,
                    TrenerID = g.Trener.TrenerID,
                    Trener = g.Trener.ImePrezime,
                    Mesto = g.Mesto.Naziv
                })
                .ToList();

            List<PretraziGrupuViewModel> nova = new List<PretraziGrupuViewModel>();

            foreach (var item in model)
            {
                if (item.TrenerID.Equals(trener))
                    nova.Add(item);
            }


            return View(nova);
        }

        /// <summary>
        /// Metoda koja vraca stranicu na kojoj se kreira nova grupa.
        /// 
        /// Kreiranje nove grupe je dostupno samo adminima ili trenerima.
        /// 
        /// </summary>
        /// <returns>stranica za kreiranje grupe</returns>
        [Authorize(Roles = "Admin,Trener")]
        public async Task<IActionResult> Kreiraj()
        {
            KreirajGrupuViewModel model = new KreirajGrupuViewModel();
            model.Treneri = jedinicaPosla.TrenerRepozitorijum
                .VratiSve()
                .Select(g => new SelectListItem
                {
                    Text = g.ImePrezime,
                    Value = g.TrenerID.ToString()
                })
                .ToList();
            model.Mesta = jedinicaPosla.MestoRepozitorijum
                .VratiSve()
                .Select(g => new SelectListItem
                {
                    Text = g.Naziv,
                    Value = g.MestoID.ToString()
                })
                .ToList();
            return View(model);
        }

        /// <summary>
        /// Metoda koja prikuplja unete podatke o grupi i poziva metodu za kreiranje nove grupe.
        /// </summary>
        /// <param name="grupa">nova grupa koja se unosi u bazu</param>
        /// <returns>metoda za kreiranje grupe</returns>
        [HttpPost]
        public async Task<IActionResult> Kreiraj(KreirajGrupuViewModel grupa)
        {
            if (grupa.GrupaIme != null && grupa.GrupaIme.Length > 20)
            {
                ModelState.AddModelError("GrupaIme", "Ime grupe mora imati do 20 karaktera");
                return await Kreiraj();
            }


            if (ModelState.IsValid)
            {
                Grupa g = new Grupa()
                {
                    GrupaIme = grupa.GrupaIme,
                    TrenerID = grupa.TrenerID,
                    MestoID = grupa.MestoID
                };
                jedinicaPosla.GrupaRepozitorijum.Dodaj(g);
                jedinicaPosla.SacuvajPromene();
                return RedirectToAction("Index");
            }
            return await Kreiraj();
        }

        /// <summary>
        /// Metoda koja vraca stranicu za brisanje neke grupe iz baze podataka.
        /// 
        /// Stranici za brisanje mogu da pristupe samo admini i treneri.
        /// </summary>
        /// <param name="id">id grupe koja treba da se obrise</param>
        /// <returns>stranica za brisanje grupe</returns>
        [Authorize(Roles = "Admin, Trener")]
        public IActionResult Obrisi(int id)
        {
            List<ObrisiGrupuViewModel> list = jedinicaPosla
                .GrupaRepozitorijum
                .VratiSve()
                .Select(g => new ObrisiGrupuViewModel
                {
                    GrupaID = g.GrupaID,
                    GrupaIme = g.GrupaIme,
                    TrenerID = g.TrenerID,
                    MestoID = g.MestoID,
                    Trener = g.Trener.ImePrezime,
                    Mesto = g.Mesto.Naziv

                })
                .ToList();

            ObrisiGrupuViewModel model = list.Single(g => g.GrupaID == id);


            return View(model);
        }

        /// <summary>
        /// Metoda koja salje zahtev za brisanje grupe.
        /// </summary>
        /// <param name="model">model grupe koja treba da se obrise</param>
        /// <returns>vraca pocetnu stranicu za prikaz svih grupa</returns>
        [HttpPost]
        public IActionResult Obrisi(ObrisiGrupuViewModel model)
        {
            if (ModelState.IsValid)
            {

                Grupa g = new Grupa()
                {
                    GrupaID = model.GrupaID,
                    GrupaIme = model.GrupaIme,
                    TrenerID = model.TrenerID,
                    MestoID = model.MestoID
                };
                jedinicaPosla.GrupaRepozitorijum.Obrisi(g);
                jedinicaPosla.SacuvajPromene();


            }
            return RedirectToAction("Index");
        }

    
    }
}
