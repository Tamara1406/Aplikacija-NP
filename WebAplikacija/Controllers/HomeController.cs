using Microsoft.AspNetCore.Mvc;

namespace WebAplikacija.Controllers
{
    /// <summary>
    /// Predstavlja klasu koja upravlja pocetnom stranicom.
    /// 
    /// Nasledjuje klasu Controller.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Metoda koja vraca pocetnu stranicu u aplikaciji.
        /// </summary>
        /// <returns>Pocetna stranica</returns>
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
