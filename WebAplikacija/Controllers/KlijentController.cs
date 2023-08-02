using Domen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NuGet.Protocol;
using PristupPodacima.Jedinica_Posla;
using WebAplikacija.Models;
using System;
using System.IO;
using System.Text.Json;

namespace WebAplikacija.Controllers
{
    /// <summary>
    /// Predstavlja klasu koja upravlja stranicama o klijentima .
    /// 
    /// Nasledjuje klasu Controller.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class KlijentController : Controller
    {
        /// <summary>
        /// Predstavlja jedinincu posla koja upravlja repozitorijumima.
        /// </summary>
        private readonly IJedinicaPosla jedinicaPosla;
        //private readonly UserManager<User> userManager;
        //private readonly RoleManager<IdentityRole> roleManager;

        /// <summary>
        /// Konstruktor kojim se dodeljuje vrednost jedinici posla.
        /// </summary>
        /// <param name="jedinicaPosla">Jedinica posla koja upravlja repozitorijumima</param>
        public KlijentController(IJedinicaPosla jedinicaPosla)
        {
            this.jedinicaPosla = jedinicaPosla;
            //this.userManager = userManager;
            //this.roleManager = roleManager;
        }

        /// <summary>
        /// Metoda koja vraca stranicu sa listom svih klijenata koji treniraju u teretani.
        /// </summary>
        /// <returns>stranica sa listom klijenata</returns>
        public async Task<IActionResult> Index()
        {
            List<KlijentViewModel> model = jedinicaPosla
                .KlijentRepozitorijum
                .VratiSve()
                .Select(k => new KlijentViewModel
                {
                    KlijentID = k.KlijentID,
                    Ime = k.Ime,
                    Prezime = k.Prezime,
                    ImePrezime = k.ImePrezime,
                    Visina = k.Visina,
                    Kilaza = k.Kilaza,
                    Pol = k.Pol.PolNaziv,
                    Grupa = k.Grupa.GrupaIme

                })
                .ToList();

            string fileName = "Klijenti.txt";
            string jsonString = JsonSerializer.Serialize(model);

            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                await streamWriter.WriteAsync(jsonString);
            }
            return View(model);
        }

        /// <summary>
        /// Metoda koja vraca stranicu na kojoj se kreira novi klijent.
        /// 
        /// </summary>
        /// <returns>stranica za kreiranje naloga klijenta</returns>
        public async Task<IActionResult> Kreiraj()
        {
            //User v = new User
            //{
            //    UserName = "tamara",
            //    Email = "tamara@gmail.com",
            //    ImePrezime = "Tamara Tamaric",
            //};

            //var result = await userManager.CreateAsync(v, "Password!123");
            //User v = new User
            //{
            //    UserName = "Nata",
            //    Email = "nata@gmail.com",
            //    ImePrezime = "Nata Natic",
            //};

            //var result = await userManager.CreateAsync(v, "Password!123");

            KreirajKlijentaViewModel model = new KreirajKlijentaViewModel();
            model.Grupe = jedinicaPosla.GrupaRepozitorijum
                .VratiSve()
                .Select(g => new SelectListItem
                {
                    Text = g.GrupaIme + "-" + g.Mesto.Naziv,
                    Value = g.GrupaID.ToString()
                })
                .ToList();
            model.Polovi = jedinicaPosla.PolRepozitorijum
                .VratiSve()
                .Select(p => new SelectListItem
                {
                    Text = p.PolNaziv,
                    Value = p.PolID.ToString()
                })
                .ToList();
            return View(model);
        }

        /// <summary>
        /// Metoda koja prikuplja unete podatke o klijentu i poziva metodu za kreiranje novog klijenta.
        /// </summary>
        /// <param name="klijent">novi klijent koji se unosi u bazu</param>
        /// <returns>metoda za kreiranje klijenta</returns>
        [HttpPost]
        public async Task<IActionResult> Kreiraj(KreirajKlijentaViewModel klijent)
        {
            if (ModelState.IsValid)
            {
                if (klijent.Kilaza == 0)
                {
                    ModelState.AddModelError("Kilaza", "Morate uneti kilazu!");
                    return await Kreiraj();
                }
                if (klijent.Visina == 0)
                {
                    ModelState.AddModelError("Visina", "Morate uneti visinu!");
                    return await Kreiraj();
                }
                Klijent k = new Klijent()
                {
                    Ime = klijent.Ime,
                    Prezime = klijent.Prezime,
                    Kilaza = klijent.Kilaza,
                    Visina = klijent.Visina,
                    PolID = klijent.PolID,
                    GrupaID = klijent.GrupaID
                };


                
                jedinicaPosla.KlijentRepozitorijum.Dodaj(k);
                jedinicaPosla.SacuvajPromene();
                return RedirectToAction("Index");
            }
            return await Kreiraj();
        }

        /// <summary>
        /// Metoda koja vraca stranicu na kojoj se menjaju podaci o klijentu.
        /// 
        /// Stranici za promenu podataka o klijentu moze da pristupi samo trener.
        /// </summary>
        /// <param name="id">id klijenta ciji podaci se menjaju</param>
        /// <returns>stranica za izmenu podataka o klijentu</returns>
        [Authorize(Roles = "Trener")]
        public IActionResult Promeni(int id)
        {
            
            Klijent k = jedinicaPosla.KlijentRepozitorijum.Vrati(id);

            PromeniKlijentaViewModel kl = new PromeniKlijentaViewModel
                {
                KlijentID = k.KlijentID,
                Ime = k.Ime,
                Prezime = k.Prezime,
                Visina = k.Visina,
                Kilaza = k.Kilaza,
                PolID = k.PolID,
                GrupaID = k.GrupaID
                };

            kl.Grupe = jedinicaPosla.GrupaRepozitorijum
                .VratiSve()
                .Select(g => new SelectListItem
                {
                    Text = g.GrupaIme + "-" + g.Mesto.Naziv,
                    Value = g.GrupaID.ToString()
                })
                .ToList();
            kl.Polovi = jedinicaPosla.PolRepozitorijum
                .VratiSve()
                .Select(p => new SelectListItem
                {
                    Text = p.PolNaziv,
                    Value = p.PolID.ToString()
                })
                .ToList();

            return View(kl);
        }

        /// <summary>
        /// Metoda koja prikuplja unete podatke o klijentu i poziva metodu za izmenu podataka o tom klijentu.
        /// </summary>
        /// <param name="model">model klijenta kome se menjaju podaci</param>
        /// <returns>listu svih klijenata ili stranicu za izmenu podataka</returns>
        [HttpPost]
        public IActionResult Promeni(PromeniKlijentaViewModel model)
        {
            if (ModelState.IsValid)
            {
                Klijent k = new Klijent()
                {
                    KlijentID = model.KlijentID,
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    Kilaza = model.Kilaza,
                    Visina = model.Visina,
                    PolID = model.PolID,
                    GrupaID = model.GrupaID
                };
                jedinicaPosla.KlijentRepozitorijum.Izmeni(k);
                jedinicaPosla.SacuvajPromene();
                return RedirectToAction("Index");
            }
            return Promeni(model.KlijentID);
        }

        /// <summary>
        /// Metoda koja vraca stranicu za brisanje nekog klijenta iz baze podataka.
        /// 
        /// Stranici za brisanje klijenata mogu da pristupe samo treneri.
        /// </summary>
        /// <param name="id">id klijenta koji treba da se obrise</param>
        /// <returns>stranica za brisanje klijenata</returns>
        [Authorize(Roles = "Trener")]
        public IActionResult Obrisi(int id)
        {
            List<ObrisiKlijentaViewModel> list = jedinicaPosla
                .KlijentRepozitorijum
                .VratiSve()
                .Select(k => new ObrisiKlijentaViewModel
                {
                    KlijentID=k.KlijentID,
                    Ime = k.Ime,
                    Prezime = k.Prezime,
                    Visina = k.Visina,
                    Kilaza = k.Kilaza,
                    PolID = k.PolID,
                    Pol = k.Pol.PolNaziv,
                    GrupaID = k.GrupaID,
                    Grupa = k.Grupa.GrupaIme

                })
                .ToList();

            

            ObrisiKlijentaViewModel model = list.Single(k => k.KlijentID == id);

            return View(model);
        }

        /// <summary>
        /// Metoda koja salje zahtev za brisanje klijenta.
        /// </summary>
        /// <param name="model">model klijenta koji treba da se obrise</param>
        /// <returns>vraca pocetnu stranicu za prikaz svih klijenata</returns>
        [HttpPost]
        public IActionResult Obrisi(ObrisiKlijentaViewModel model)
        {
            if (ModelState.IsValid)
            {

                Klijent k = new Klijent()
                {
                    KlijentID = model.KlijentID,
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    Kilaza = model.Kilaza,
                    Visina = model.Visina,
                    PolID = model.PolID,
                    GrupaID = model.GrupaID
                };
                jedinicaPosla.KlijentRepozitorijum.Obrisi(k);
                jedinicaPosla.SacuvajPromene();
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Metoda koja vraca stranicu na kojoj se pretrazuju klijenti prema imenu i prezimenu.
        /// 
        /// Kriterijum za pretragu je ime i prezime klijenta.
        /// </summary>
        /// <param name="imePrezime">ime i prezime klijenta kao string</param>
        /// <returns>stranica za pretragu klijenata</returns>
        public async Task<IActionResult> Pretrazi(string imePrezime)
        {
            List<PretraziKlijentaViewModel> model = jedinicaPosla
                .KlijentRepozitorijum
                .Pretrazi(imePrezime)
                .Select(k => new PretraziKlijentaViewModel
                {
                    KlijentID = k.KlijentID,
                    Ime = k.Ime,
                    Prezime = k.Prezime,
                    ImePrezime = k.ImePrezime,
                    Visina = k.Visina,
                    Kilaza = k.Kilaza,
                    Pol = k.Pol.PolNaziv,
                    Grupa = k.Grupa.GrupaIme
                })
                .ToList();
            if (model == null)
                return RedirectToAction("Index");

            return View(model);
            
        }

        /// <summary>
        /// Metoda koja vraca sve podatke o odredjenom klijentu na osnovu id-ja.
        /// 
        /// Pristup stranici ima trener.
        /// 
        /// </summary>
        /// <param name="id">id klijenta ciji podaci se prikazuju</param>
        /// <returns>Stranicu za prikaz detalja o klijentu ili vraca na stranicu sa svim klijentima</returns>
        [Authorize(Roles = "Trener")]
        public async Task<IActionResult> Detalji(int id)
        {
            List<KlijentViewModel> model = jedinicaPosla
                .KlijentRepozitorijum
                .VratiSve()
                .Select(k => new KlijentViewModel
                {
                    KlijentID = k.KlijentID,
                    Ime = k.Ime,
                    Prezime = k.Prezime,
                    ImePrezime = k.ImePrezime,
                    Visina = k.Visina,
                    Kilaza = k.Kilaza,
                    Pol = k.Pol.PolNaziv,
                    Grupa = k.Grupa.GrupaIme
                })
                .ToList();


            KlijentViewModel? kl = model.Single(t => t.KlijentID == id);

            if (kl == null)
                return RedirectToAction("Index");

            return View(kl);


        }

    }
}
