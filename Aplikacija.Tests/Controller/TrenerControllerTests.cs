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

        [Fact]
        public async Task TrenerController_Delete_ReturnSuccess()
        {
            // Arrange.
            var jedinica = A.Fake<IJedinicaPosla>();
            TrenerController controller = new TrenerController(jedinica);

            var t1 = new Trener()
            {
                TrenerID = 1,
                Ime = "Pera",
                Prezime = "Peric",
                Opis = "opis",
                Slika = "slika",
                ObrazovanjeID = 1,
                Obrazovanje = jedinica.ObrazovanjeRepozitorijum.Vrati(1)
            };
            var t2 = new Trener()
            {
                TrenerID = 2,
                Ime = "Mika",
                Prezime = "Mikic",
                Opis = "opis",
                Slika = "slika",
                ObrazovanjeID = 1,
                Obrazovanje = jedinica.ObrazovanjeRepozitorijum.Vrati(1)
            };

            A.CallTo(() => jedinica.TrenerRepozitorijum.Dodaj(t1));
            A.CallTo(() => jedinica.TrenerRepozitorijum.Dodaj(t2));

            A.CallTo(() => jedinica.TrenerRepozitorijum.VratiSve()).Returns(new List<Trener> { t1, t2 });

            //// Act.
            var obrisiResult = controller.Obrisi(t1.TrenerID);
            var obrisiViewResult = obrisiResult as ViewResult;
            var obrisaniTrener = obrisiViewResult.Model as ObrisiTreneraViewModel;

            // Assert.
            obrisiResult.Should().NotBeNull();
            Assert.AreEqual("Pera", obrisaniTrener.Ime);
            Assert.AreEqual("Peric", obrisaniTrener.Prezime);
            Assert.AreEqual("opis", obrisaniTrener.Opis);
            Assert.AreEqual("slika", obrisaniTrener.Slika);

            //// Act.
            A.CallTo(() => jedinica.TrenerRepozitorijum.VratiSve()).Returns(new List<Trener> { t2 });


            var result = await controller.Index();

            var viewResult = result as ViewResult;
            var model = viewResult.Model as List<TrenerViewModel>;


            // Assert.
            Assert.AreEqual(1, model.Count);
            result.Should().NotBeNull();
            Assert.AreEqual("Mika", model[0].Ime);
            Assert.AreEqual("Mikic", model[0].Prezime);
            Assert.AreEqual("opis", obrisaniTrener.Opis);
            Assert.AreEqual("slika", obrisaniTrener.Slika);
        }

        [Fact]
        public async Task TrenerController_Delete_Error()
        {
            // Arrange.
            var jedinica = A.Fake<IJedinicaPosla>();
            TrenerController controller = new TrenerController(jedinica);

            var t1 = new Trener()
            {
                TrenerID = 1,
                Ime = "Pera",
                Prezime = "Peric",
                Opis = "opis",
                Slika = "slika",
                ObrazovanjeID = 1,
                Obrazovanje = jedinica.ObrazovanjeRepozitorijum.Vrati(1)
            };
            var t2 = new Trener()
            {
                TrenerID = 2,
                Ime = "Mika",
                Prezime = "Mikic",
                Opis = "opis",
                Slika = "slika",
                ObrazovanjeID = 1,
                Obrazovanje = jedinica.ObrazovanjeRepozitorijum.Vrati(1)
            };

            A.CallTo(() => jedinica.TrenerRepozitorijum.Dodaj(t1));
            A.CallTo(() => jedinica.TrenerRepozitorijum.Dodaj(t2));

            A.CallTo(() => jedinica.TrenerRepozitorijum.VratiSve()).Returns(new List<Trener> { t1, t2 });

            //// Act.

            // Assert.
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => (Task)controller.Obrisi(3));
        }


        [Fact]
        public async Task TrenerController_Index_UpdateReturnSuccess()
        {
            // Arrange.
            var jedinica = A.Fake<IJedinicaPosla>();
            TrenerController controller = new TrenerController(jedinica);

            var t1 = new Trener()
            {
                TrenerID = 1,
                Ime = "Pera",
                Prezime = "Peric",
                ObrazovanjeID = 1,
                Obrazovanje = jedinica.ObrazovanjeRepozitorijum.Vrati(1),
                Opis = "Ovo je opis prvog trenera",
                Slika = "slika1"
            };
            var t2 = new Trener()
            {
                TrenerID = 2,
                Ime = "Mika",
                Prezime = "Mikic",
                ObrazovanjeID = 1,
                Obrazovanje = jedinica.ObrazovanjeRepozitorijum.Vrati(1),
                Opis = "Ovo je opis drugog trenera",
                Slika = "slika2"
            };

            A.CallTo(() => jedinica.TrenerRepozitorijum.Dodaj(t1));
            A.CallTo(() => jedinica.TrenerRepozitorijum.Dodaj(t2));

            t1.Ime = "Zika";
            t1.Opis = "Novi opis";

            A.CallTo(() => jedinica.TrenerRepozitorijum.Izmeni(t1));


            A.CallTo(() => jedinica.TrenerRepozitorijum.VratiSve()).Returns(new List<Trener> { t1, t2 });

            // Act.

            var result = await controller.Index();

            var viewResult = result as ViewResult;
            var model = viewResult.Model as List<TrenerViewModel>;

            // Assert.
            Assert.AreEqual(2, model.Count);
            result.Should().NotBeNull();
            Assert.AreEqual("Zika", model[0].Ime);
            Assert.AreEqual("Mika", model[1].Ime);
            Assert.AreEqual("Peric", model[0].Prezime);
            Assert.AreEqual("Mikic", model[1].Prezime);
            Assert.AreEqual("Novi opis", model[0].Opis);
            Assert.AreEqual("Ovo je opis drugog trenera", model[1].Opis);
            Assert.AreEqual("slika1", model[0].Slika);
            Assert.AreEqual("slika2", model[1].Slika);
        }

        [Fact]
        public async Task TrenerController_Pretrazi_ReturnSuccess()
        {
            // Arrange.
            var jedinica = A.Fake<IJedinicaPosla>();
            TrenerController controller = new TrenerController(jedinica);

            var t1 = new Trener()
            {
                TrenerID = 1,
                Ime = "Pera",
                Prezime = "Peric",
                ObrazovanjeID = 1,
                Obrazovanje = jedinica.ObrazovanjeRepozitorijum.Vrati(1),
                Opis = "Ovo je opis prvog trenera",
                Slika = "slika1"
            };
            var t2 = new Trener()
            {
                TrenerID = 2,
                Ime = "Mika",
                Prezime = "Mikic",
                ObrazovanjeID = 1,
                Obrazovanje = jedinica.ObrazovanjeRepozitorijum.Vrati(1),
                Opis = "Ovo je opis drugog trenera",
                Slika = "slika2"
            };
            var t3 = new Trener()
            {
                TrenerID = 3,
                Ime = "Mika",
                Prezime = "Zikic",
                ObrazovanjeID = 1,
                Obrazovanje = jedinica.ObrazovanjeRepozitorijum.Vrati(1),
                Opis = "Ovo je opis treceg trenera",
                Slika = "slika3"
            };

            A.CallTo(() => jedinica.TrenerRepozitorijum.Dodaj(t1));
            A.CallTo(() => jedinica.TrenerRepozitorijum.Dodaj(t2));
            A.CallTo(() => jedinica.TrenerRepozitorijum.Dodaj(t3));


            A.CallTo(() => jedinica.TrenerRepozitorijum.VratiSve()).Returns(new List<Trener> { t1, t2, t3 });

            // Act.
            // vraca firstOrDefault

            var result = await controller.Pretrazi("Mika");

            var viewResult = result as ViewResult;
            var model = viewResult.Model as PretraziTreneraViewModel;

            // Assert.
            result.Should().NotBeNull();
            Assert.AreEqual("Mika", model.Ime);
            Assert.AreEqual("Mikic", model.Prezime);
            Assert.AreEqual("Ovo je opis drugog trenera", model.Opis);
            Assert.AreEqual("slika2", model.Slika);
        }

    }
}
