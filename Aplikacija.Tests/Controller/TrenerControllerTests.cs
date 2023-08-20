using Domen;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using PristupPodacima.Jedinica_Posla;
using PristupPodacima;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAplikacija.Controllers;
using FluentAssertions;
using FluentAssertions.Equivalency.Tracing;

namespace Aplikacija.Tests.Controller
{
    public class TrenerControllerTests
    {
        private IJedinicaPosla jedinica;
        private Context context;

        public TrenerControllerTests()
        {
            this.jedinica = A.Fake<IJedinicaPosla>();
            this.context = A.Fake<Context>();
        }

        [Fact]
        public void TrenerController_Index_ReturnSuccess()
        {
            //Arrange
            TrenerController controller = new TrenerController(jedinica);
            var treneri = A.Fake<List<Trener>>();
            A.CallTo(() => jedinica.TrenerRepozitorijum.VratiSve()).Returns<List<Trener>>(treneri);
            //Act
            var result = controller.Index();
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void TrenerController_IndexAdmin_ReturnSuccess()
        {
            //Arrange
            TrenerController controller = new TrenerController(jedinica);
            var treneri = A.Fake<List<Trener>>();
            A.CallTo(() => jedinica.TrenerRepozitorijum.VratiSve()).Returns<List<Trener>>(treneri);
            //Act
            var result = controller.IndexAdmin();
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void TrenerController_Kreiraj_ReturnSuccess()
        {
            // Arrange.
            TrenerController controller = new TrenerController(jedinica);
            var tr = new Trener()
            {
                Ime = "Pera",
                Prezime = "Peric",
                ObrazovanjeID = 1,
                Opis = "Ovo je trener",
                Slika = "slika"
            };
            A.CallTo(() => jedinica.TrenerRepozitorijum.Dodaj(tr));
            // Act.
            var result = controller.Kreiraj();
            // Assert.
            result.Should().BeOfType<Task<IActionResult>>();
        }
    }
}
