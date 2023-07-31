using Domen;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PristupPodacima.Jedinica_Posla;
using WebAplikacija.Models;

namespace WebAplikacija.Controllers
{
    /// <summary>
    /// Predstavlja klasu pomocu koje se vrsi prijava na stranicu.
    /// 
    /// Nasledjuje klasu Controller.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class LoginController : Controller
    {
        /// <summary>
        /// Predstavlja api pomocu kog se korisnik prijavljuje u aplikaciji.
        /// </summary>
        private readonly SignInManager<User> signInManager;
        /// <summary>
        /// Konstruktor u kom se dodeljuje vrednost promenljivoj signInManager
        /// </summary>
        /// <param name="signInManager">api za prijavljivanje</param>
        public LoginController(SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
        }

        /// <summary>
        /// Vraca stranicu za prijavljivanje korisnika.
        /// </summary>
        /// <returns>stranica za prijavljivanje</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Metoda koja poziva stranicu za prijavljivanje na sistem i prikuplja podatke za prijavu.
        /// </summary>
        /// <param name="model">model korisnika koji se prijavljuje na sistem</param>
        /// <returns>pocetna stranica ili stranica za prijavu</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(model.KorisnickoIme != null && model.Lozinka != null)
            {
                var result = await signInManager.PasswordSignInAsync(model.KorisnickoIme, model.Lozinka, false, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }
                
            ModelState.AddModelError("KorisnickoIme", "Proverite da li ste dobro uneli korisničko ime.");
            ModelState.AddModelError("Lozinka", "Niste dobro uneli lozinku!");
            return View("Index");
        }
    }
}
