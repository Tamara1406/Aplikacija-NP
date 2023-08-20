using Microsoft.AspNetCore.Mvc;
using PristupPodacima.Jedinica_Posla;
using WebAplikacija.Models;

namespace WebAplikacija.Controllers
{
    public class TerminController : Controller
    {
        /// <summary>
        /// Predstavlja jedinincu posla koja upravlja repozitorijumima.
        /// </summary>
        private readonly IJedinicaPosla jedinicaPosla;

        /// <summary>
        /// Konstruktor kojim se dodeljuje vrednost jedinici posla.
        /// </summary>
        /// <param name="jedinicaPosla">Jedinica posla koja upravlja repozitorijumima</param>
        public TerminController(IJedinicaPosla jedinicaPosla)
        {
            this.jedinicaPosla = jedinicaPosla;
        }

        public async Task<IActionResult> Index()
        {
            List<TerminViewModel> model = jedinicaPosla
                .TerminRepozitorijum
                .VratiSve()
                .Select(t => new TerminViewModel
                {
                    TerminID = t.TerminID,
                    VremeTermina = t.VremeTermina,
                    Grupa = t.Grupa.GrupaIme
                })
                .ToList();

            return View(model);
        }
    }
}
