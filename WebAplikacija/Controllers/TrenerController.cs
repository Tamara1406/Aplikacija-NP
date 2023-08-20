using Domen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PristupPodacima.Jedinica_Posla;
using System.Text.Json;
using WebAplikacija.Models;

namespace WebAplikacija.Controllers
{
    /// <summary>
    /// Predstavlja klasu koja upravlja stranicama o trenerima .
    /// 
    /// Nasledjuje klasu Controller.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class TrenerController : Controller
    {
        /// <summary>
        /// Predstavlja jedinincu posla koja upravlja repozitorijumima.
        /// </summary>
        private readonly IJedinicaPosla jedinicaPosla;

        /// <summary>
        /// Konstruktor kojim se dodeljuje vrednost jedinici posla.
        /// </summary>
        /// <param name="jedinicaPosla">Jedinica posla koja upravlja repozitorijumima</param>
        public TrenerController(IJedinicaPosla jedinicaPosla)
        {
            this.jedinicaPosla = jedinicaPosla;
        }

        /// <summary>
        /// Metoda koja vraca stranicu sa listom svih terenra koji rade u teretani.
        /// </summary>
        /// <returns>stranica sa listom trenera</returns>
        public async Task<IActionResult> Index()
        {
            List<TrenerViewModel> model = jedinicaPosla
                .TrenerRepozitorijum
                .VratiSve()
                .Select(t => new TrenerViewModel
                {
                    TrenerID = t.TrenerID,
                    Ime = t.Ime,
                    Prezime = t.Prezime,
                    Obrazovanje = t.Obrazovanje.StepenObrazovanja,
                    ImePrezime = t.ImePrezime,
                    Opis = t.Opis,
                    Slika = t.Slika
                })
                .ToList();

            string fileName = "Treneri.txt";
            string jsonString = JsonSerializer.Serialize(model);

            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                await streamWriter.WriteAsync(jsonString);
            }
            return View(model);
        }

        /// <summary>
        /// Metoda koja vraca stranicu sa listom svih trenera koji rade u teretani.
        /// 
        /// Pristup stranici imaju samo admini i treneri.
        /// 
        /// </summary>
        /// <returns>stranica sa listom trenera</returns>
        [Authorize(Roles = "Admin, Trener")]
        public async Task<IActionResult> IndexAdmin()
        {
            List<TrenerViewModel> model = jedinicaPosla
                .TrenerRepozitorijum
                .VratiSve()
                .Select(t => new TrenerViewModel
                {
                    TrenerID = t.TrenerID,
                    Ime = t.Ime,
                    Prezime = t.Prezime,
                    Obrazovanje = t.Obrazovanje.StepenObrazovanja,
                    Opis = t.Opis,
                    Slika = t.Slika
                })
                .ToList();
            return View(model);
        }

        /// <summary>
        /// Metoda koja vraca stranicu na kojoj se kreira novi trener.
        /// 
        /// Pristup stranici imaju samo admini.
        /// 
        /// </summary>
        /// <returns>stranica za kreiranje trenera</returns>
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Kreiraj()
        {
            KreirajTreneraViewModel model = new KreirajTreneraViewModel();
            model.Obrazovanja = jedinicaPosla.ObrazovanjeRepozitorijum
                .VratiSve()
                .Select(g => new SelectListItem
                {
                    Text = g.StepenObrazovanja,
                    Value = g.ObrazovanjeID.ToString()
                })
                .ToList();

            return View(model);
        }

        /// <summary>
        /// Metoda koja prikuplja unete podatke o treneru i poziva metodu za kreiranje novog trenera.
        /// </summary>
        /// <param name="trener">novi trener koji se unosi u bazu</param>
        /// <returns>metoda za kreiranje trenera</returns>
        [HttpPost]
        public async Task<IActionResult> Kreiraj(KreirajTreneraViewModel trener)
        {
            if (ModelState.IsValid)
            {
                Trener t = new Trener()
                {
                    Ime = trener.Ime,
                    Prezime = trener.Prezime,
                    ObrazovanjeID = trener.ObrazovanjeID,
                    Opis = trener.Opis,
                    Slika = trener.Slika
                };
                jedinicaPosla.TrenerRepozitorijum.Dodaj(t);
                jedinicaPosla.SacuvajPromene();

                return RedirectToAction("Index");
            }
            return await Kreiraj();
        }

        /// <summary>
        /// Metoda koja vraca stranicu na kojoj se menjaju podaci o treneru.
        /// 
        /// Stranici za promenu podataka o treneru moze da pristupi samo admin.
        /// </summary>
        /// <param name="id">id trenera ciji podaci se menjaju</param>
        /// <returns>stranica za izmenu podataka o treneru</returns>
        [Authorize(Roles = "Admin")]
        public IActionResult Promeni(int id)
        {

            Trener t = jedinicaPosla.TrenerRepozitorijum.Vrati(id);

            PromeniTreneraViewModel tr = new PromeniTreneraViewModel
            {
                TrenerID = t.TrenerID,
                Ime = t.Ime,
                Prezime = t.Prezime,
                ObrazovanjeID = t.ObrazovanjeID,
                Opis = t.Opis,
                Slika = t.Slika
            };

            tr.Obrazovanja = jedinicaPosla.ObrazovanjeRepozitorijum
                .VratiSve()
                .Select(g => new SelectListItem
                {
                    Text = g.StepenObrazovanja,
                    Value = g.ObrazovanjeID.ToString()
                })
                .ToList();


            return View(tr);
        }

        /// <summary>
        /// Metoda koja prikuplja unete podatke o treneru i poziva metodu za izmenu podataka o tom treneru.
        /// </summary>
        /// <param name="model">model trenera kome se menjaju podaci</param>
        /// <returns>listu svih trenera ili stranicu za izmenu podataka</returns>
        [HttpPost]
        public IActionResult Promeni(PromeniTreneraViewModel model)
        {
            if (ModelState.IsValid)
            {
                Trener t = new Trener()
                {
                    TrenerID = model.TrenerID,
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    ObrazovanjeID = model.ObrazovanjeID,
                    Opis = model.Opis,
                    Slika = model.Slika
                };
                jedinicaPosla.TrenerRepozitorijum.Izmeni(t);
                jedinicaPosla.SacuvajPromene();
                return RedirectToAction("Index");

            }
            return Promeni(model.TrenerID);
        }

        /// <summary>
        /// Metoda koja vraca stranicu za brisanje nekog trenera iz baze podataka.
        /// 
        /// Stranici za brisanje trenera mogu da pristupe samo admini.
        /// </summary>
        /// <param name="id">id trenera koji treba da se obrise</param>
        /// <returns>stranica za brisanje trenera</returns>
        [Authorize(Roles = "Admin")]
        public IActionResult Obrisi(int id)
        {
            List<ObrisiTreneraViewModel> list = jedinicaPosla
                .TrenerRepozitorijum
                .VratiSve()
                .Select(t => new ObrisiTreneraViewModel
                {
                    TrenerID = t.TrenerID,
                    Ime = t.Ime,
                    Prezime = t.Prezime,
                    ObrazovanjeID = t.ObrazovanjeID,
                    Obrazovanje = t.Obrazovanje.StepenObrazovanja,
                    Opis = t.Opis,
                    Slika=t.Slika

                })
                .ToList();

            ObrisiTreneraViewModel model = list.Single(t => t.TrenerID == id);


            return View(model);
        }

        /// <summary>
        /// Metoda koja salje zahtev za brisanje trenera.
        /// </summary>
        /// <param name="model">model trenera koji treba da se obrise</param>
        /// <returns>vraca pocetnu stranicu za prikaz svih trenera</returns>
        [HttpPost]
        public IActionResult Obrisi(ObrisiTreneraViewModel model)
        {
            if (ModelState.IsValid)
            {

                Trener t = new Trener()
                {
                    TrenerID = model.TrenerID,
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    ObrazovanjeID = model.ObrazovanjeID,
                    Opis = model.Opis,
                    Slika = model.Slika
                };
                jedinicaPosla.TrenerRepozitorijum.Obrisi(t);
                jedinicaPosla.SacuvajPromene();
                

            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Metoda koja vraca stranicu na kojoj se pretrazuju treneri prema imenu i prezimenu.
        /// 
        /// Kriterijum za pretragu je ime i prezime trenera.
        /// </summary>
        /// <param name="imePrezime">ime i prezime trenera kao string</param>
        /// <returns>stranica za pretragu trenera ili za prikaz svih trenera</returns>
        public async Task<IActionResult> Pretrazi(string imePrezime)
        {
            List<PretraziTreneraViewModel> model = jedinicaPosla
                .TrenerRepozitorijum
                .VratiSve()
                .Select(t => new PretraziTreneraViewModel
                {
                    TrenerID = t.TrenerID,
                    Ime = t.Ime,
                    Prezime = t.Prezime,
                    ImePrezime = t.ImePrezime,
                    Obrazovanje = t.Obrazovanje.StepenObrazovanja,
                    Opis = t.Opis,
                    Slika = t.Slika
                })
                .ToList();


            PretraziTreneraViewModel? tr = model.FirstOrDefault(t => t.ImePrezime.Trim().ToLower().StartsWith(imePrezime.Trim().ToLower()));

            if (tr == null)
                return RedirectToAction("Index");

            return View(tr);


        }
    }
}
