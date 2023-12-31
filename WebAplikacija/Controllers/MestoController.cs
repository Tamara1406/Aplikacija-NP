﻿using Microsoft.AspNetCore.Mvc;
using PristupPodacima;
using PristupPodacima.Jedinica_Posla;
using System.Text.Json;
using WebAplikacija.Models;

namespace WebAplikacija.Controllers
{
    /// <summary>
    /// Predstavlja klasu koja upravlja stranicama o mestima .
    /// 
    /// Nasledjuje klasu Controller.
    /// 
    /// @author Tamara Maksimovic
    /// 
    /// </summary>
    public class MestoController : Controller
    {
        /// <summary>
        /// Predstavlja jedinincu posla koja upravlja repozitorijumima.
        /// </summary>
        private readonly IJedinicaPosla jedinicaPosla;

        /// <summary>
        /// Konstruktor kojim se dodeljuje vrednost jedinici posla.
        /// </summary>
        /// <param name="jedinicaPosla">Jedinica posla koja upravlja repozitorijumima</param>
        public MestoController(IJedinicaPosla jedinicaPosla)
        {
            this.jedinicaPosla = jedinicaPosla;
        }

        /// <summary>
        /// Metoda koja vraca stranicu sa listom svih mesta u kojima se nalazi teretana.
        /// </summary>
        /// <returns>stranica sa listom mesta</returns>
        public async Task<IActionResult> Index()
        {
            List<MestoViewModel> model = jedinicaPosla
                .MestoRepozitorijum
                .VratiSve()
                .Select(m => new MestoViewModel
                {
                    MestoID = m.MestoID,
                    Naziv = m.Naziv,
                })
                .ToList();

            string fileName = "Mesta.txt";
            string jsonString = JsonSerializer.Serialize(model);

            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                await streamWriter.WriteAsync(jsonString);
            }
            return View(model);
        }
    }
}
