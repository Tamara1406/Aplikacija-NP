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
using WebAplikacija.Models;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

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


        [Fact]
        public void TrenerController_Kreiraj_ReturnSuccess2()
        {
            // Arrange.
            TrenerController controller = new TrenerController(jedinica);
            var trener = new Trener()
            {
                Ime = "Pera",
                Prezime = "Peric",
                ObrazovanjeID = 1,
                Opis = "Ovo je trenera",
                Slika = "slika"

            };
            A.CallTo(() => jedinica.TrenerRepozitorijum.Dodaj(trener));
            // Act.
            var result = controller.Kreiraj();
            // Assert.
            Assert.IsNotNull(result);
        }

        [Fact]
        public async Task TrenerController_Index_Return2Trainers()
        {
            // Arrange.
            var jedinica = A.Fake<IJedinicaPosla>();
            TrenerController controller = new TrenerController(jedinica);

            var t1 = new Trener()
            {
                Ime = "Pera",
                Prezime = "Peric",
                ObrazovanjeID = 1,
                Obrazovanje = jedinica.ObrazovanjeRepozitorijum.Vrati(1),
                Opis = "Ovo je opis trenera",
                Slika = "slika1"
            };
            var t2 = new Trener()
            {
                Ime = "Mika",
                Prezime = "Mikic",
                ObrazovanjeID = 1,
                Obrazovanje = jedinica.ObrazovanjeRepozitorijum.Vrati(1),
                Opis = "Ovo je opis drugog trenera",
                Slika = "slika2"
            };

            A.CallTo(() => jedinica.TrenerRepozitorijum.Dodaj(t1));
            A.CallTo(() => jedinica.TrenerRepozitorijum.Dodaj(t2));

            A.CallTo(() => jedinica.TrenerRepozitorijum.VratiSve()).Returns(new List<Trener> { t1, t2 });

            // Act.

            var result = await controller.Index();

            var viewResult = result as ViewResult;
            var model = viewResult.Model as List<TrenerViewModel>;

            // Assert.
            Assert.AreEqual(2, model.Count);
            result.Should().NotBeNull();
            Assert.AreEqual("Pera", model[0].Ime);
            Assert.AreEqual("Mika", model[1].Ime);
            Assert.AreEqual("Peric", model[0].Prezime);
            Assert.AreEqual("Mikic", model[1].Prezime);
            Assert.AreEqual("Ovo je opis trenera", model[0].Opis);
            Assert.AreEqual("Ovo je opis drugog trenera", model[1].Opis);
            Assert.AreEqual("slika1", model[0].Slika);
            Assert.AreEqual("slika2", model[1].Slika);
        }
    }
}
