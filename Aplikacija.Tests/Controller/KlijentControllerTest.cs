using Domen;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PristupPodacima;
using PristupPodacima.Jedinica_Posla;
using System.Diagnostics;
using System.Net.Http;
using WebAplikacija.Controllers;
using WebAplikacija.Models;

namespace Aplikacija.Tests.Controller
{
    public class KlijentControllerTest
    {
        private IJedinicaPosla jedinica;
        private Context context;

        public KlijentControllerTest()
        {
            this.jedinica = A.Fake<IJedinicaPosla>();
            this.context = A.Fake<Context>();
        }

        [Fact]
        public void KlijentController_Index_ReturnSuccess()
        {
            //Arrange
            KlijentController controller = new KlijentController(jedinica);
            var klijenti = A.Fake<List<Klijent>>();
            A.CallTo(() => jedinica.KlijentRepozitorijum.VratiSve()).Returns<List<Klijent>>(klijenti);
            //Act
            var result = controller.Index();
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void KlijentController_Detalji_ReturnSuccess()
        {
            //Arrange
            KlijentController controller = new KlijentController(jedinica);
            var id = 1;
            var klijent = A.Fake<Klijent>();
            A.CallTo(() => jedinica.KlijentRepozitorijum.Vrati(id)).Returns<Klijent>(klijent);
            //Act
            var result = controller.Detalji(id);
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }


        [Fact]
        public void KlijentController_Kreiraj_ReturnSuccess()
        {
            // Arrange.
            KlijentController controller = new KlijentController(jedinica);
            var kl = new Klijent()
            {
                Ime = "Pera",
                Prezime = "Peric",
                Kilaza = 90,
                Visina = 185,
                PolID = 1,
                GrupaID = 1
            };
            A.CallTo(() => jedinica.KlijentRepozitorijum.Dodaj(kl));
            // Act.
            var result = controller.Kreiraj();
            // Assert.
            result.Should().BeOfType<Task<IActionResult>>();
        }

        
    }
}
