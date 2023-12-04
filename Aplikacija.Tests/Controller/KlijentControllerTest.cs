using Domen;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using PristupPodacima.Jedinica_Posla;
using PristupPodacima;
using WebAplikacija.Controllers;
using FluentAssertions;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using WebAplikacija.Models;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;
using PristupPodacima.Repozitorijumi.Interfejsi;
using Moq;

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

        

        [Fact]
        public void KlijentController_Kreiraj_ReturnSuccess2()
        {
            // Arrange.
            KlijentController controller = new KlijentController(jedinica);
            var klijent = new Klijent()
            {
                Ime = "Pera",
                Prezime = "Peric",
                Kilaza = 90,
                Visina = 90,
                PolID = 1,
                GrupaID = 1

            };
            A.CallTo(() => jedinica.KlijentRepozitorijum.Dodaj(klijent));
            // Act.
            var result = controller.Kreiraj();
            // Assert.
            Assert.IsNotNull(result);
        }

        [Fact]
        public async Task KlijentController_Index_Return2Clients()
        {
            // Arrange.
            var jedinica = A.Fake<IJedinicaPosla>();
            KlijentController controller = new KlijentController(jedinica);

            var k1 = new Klijent()
            {
                Ime = "Pera",
                Prezime = "Peric",
                Kilaza = 90,
                Visina = 190,
                PolID = 1,
                Pol = jedinica.PolRepozitorijum.Vrati(1),
                GrupaID = 1,
                Grupa = jedinica.GrupaRepozitorijum.Vrati(1)
            };
            var k2 = new Klijent()
            {
                Ime = "Mika",
                Prezime = "Mikic",
                Kilaza = 90,
                Visina = 190,
                PolID = 1,
                Pol = jedinica.PolRepozitorijum.Vrati(1),
                GrupaID = 1,
                Grupa = jedinica.GrupaRepozitorijum.Vrati(1)
            };

            A.CallTo(() => jedinica.KlijentRepozitorijum.Dodaj(k1));
            A.CallTo(() => jedinica.KlijentRepozitorijum.Dodaj(k2));

            A.CallTo(() => jedinica.KlijentRepozitorijum.VratiSve()).Returns(new List<Klijent> { k1, k2 });

            // Act.

            var result = await controller.Index();

            var viewResult = result as ViewResult;
            var model = viewResult.Model as List<KlijentViewModel>;

            // Assert.
            Assert.AreEqual(2, model.Count);
            result.Should().NotBeNull();
            Assert.AreEqual("Pera", model[0].Ime);
            Assert.AreEqual("Mika", model[1].Ime);
            Assert.AreEqual("Peric", model[0].Prezime);
            Assert.AreEqual("Mikic", model[1].Prezime);
            Assert.AreEqual(90, model[0].Kilaza);
            Assert.AreEqual(90, model[1].Kilaza);
            Assert.AreEqual(190, model[0].Visina);
            Assert.AreEqual(190, model[1].Visina);
        }

        [Fact]
        public async Task KlijentController_Delete_ReturnSuccess()
        {
            // Arrange.
            var jedinica = A.Fake<IJedinicaPosla>();
            KlijentController controller = new KlijentController(jedinica);

            var k1 = new Klijent()
            {
                KlijentID = 1,
                Ime = "Pera",
                Prezime = "Peric",
                Kilaza = 90,
                Visina = 190,
                PolID = 1,
                Pol = jedinica.PolRepozitorijum.Vrati(1),
                GrupaID = 1,
                Grupa = jedinica.GrupaRepozitorijum.Vrati(1)
            };
            var k2 = new Klijent()
            {
                KlijentID = 2,
                Ime = "Mika",
                Prezime = "Mikic",
                Kilaza = 90,
                Visina = 190,
                PolID = 1,
                Pol = jedinica.PolRepozitorijum.Vrati(1),
                GrupaID = 1,
                Grupa = jedinica.GrupaRepozitorijum.Vrati(1)
            };

            A.CallTo(() => jedinica.KlijentRepozitorijum.Dodaj(k1));
            A.CallTo(() => jedinica.KlijentRepozitorijum.Dodaj(k2));

            A.CallTo(() => jedinica.KlijentRepozitorijum.VratiSve()).Returns(new List<Klijent> { k1, k2 });

            //// Act.
            var obrisiResult = await controller.Obrisi(k1.KlijentID);
            var obrisiViewResult = obrisiResult as ViewResult;
            var obrisaniKlijent = obrisiViewResult.Model as ObrisiKlijentaViewModel;

            // Assert.
            obrisiResult.Should().NotBeNull();
            Assert.AreEqual("Pera", obrisaniKlijent.Ime);
            Assert.AreEqual("Peric", obrisaniKlijent.Prezime);
            Assert.AreEqual(90, obrisaniKlijent.Kilaza);
            Assert.AreEqual(190, obrisaniKlijent.Visina);

            //// Act.
            A.CallTo(() => jedinica.KlijentRepozitorijum.VratiSve()).Returns(new List<Klijent> { k2 });


            var result = await controller.Index();

            var viewResult = result as ViewResult;
            var model = viewResult.Model as List<KlijentViewModel>;


            // Assert.
            Assert.AreEqual(1, model.Count);
            result.Should().NotBeNull();
            Assert.AreEqual("Mika", model[0].Ime);
            Assert.AreEqual("Mikic", model[0].Prezime);
            Assert.AreEqual(90, model[0].Kilaza);
            Assert.AreEqual(190, model[0].Visina);
        }

        [Fact]
        public async Task KlijentController_Delete_Error()
        {
            // Arrange.
            var jedinica = A.Fake<IJedinicaPosla>();
            KlijentController controller = new KlijentController(jedinica);

            var k1 = new Klijent()
            {
                KlijentID = 1,
                Ime = "Pera",
                Prezime = "Peric",
                Kilaza = 90,
                Visina = 190,
                PolID = 1,
                Pol = jedinica.PolRepozitorijum.Vrati(1),
                GrupaID = 1,
                Grupa = jedinica.GrupaRepozitorijum.Vrati(1)
            };
            var k2 = new Klijent()
            {
                KlijentID = 2,
                Ime = "Mika",
                Prezime = "Mikic",
                Kilaza = 90,
                Visina = 190,
                PolID = 1,
                Pol = jedinica.PolRepozitorijum.Vrati(1),
                GrupaID = 1,
                Grupa = jedinica.GrupaRepozitorijum.Vrati(1)
            };

            A.CallTo(() => jedinica.KlijentRepozitorijum.Dodaj(k1));
            A.CallTo(() => jedinica.KlijentRepozitorijum.Dodaj(k2));

            A.CallTo(() => jedinica.KlijentRepozitorijum.VratiSve()).Returns(new List<Klijent> { k1, k2 });

            //// Act.

            // Assert.
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.Obrisi(3));
        }

        [Fact]
        public async Task KlijentController_Index_UpdateReturnSuccess()
        {
            // Arrange.
            var jedinica = A.Fake<IJedinicaPosla>();
            KlijentController controller = new KlijentController(jedinica);

            var k1 = new Klijent()
            {
                KlijentID = 1,
                Ime = "Pera",
                Prezime = "Peric",
                Kilaza = 90,
                Visina = 190,
                PolID = 1,
                Pol = jedinica.PolRepozitorijum.Vrati(1),
                GrupaID = 1,
                Grupa = jedinica.GrupaRepozitorijum.Vrati(1)
            };
            var k2 = new Klijent()
            {
                KlijentID = 2,
                Ime = "Mika",
                Prezime = "Mikic",
                Kilaza = 90,
                Visina = 190,
                PolID = 1,
                Pol = jedinica.PolRepozitorijum.Vrati(1),
                GrupaID = 1,
                Grupa = jedinica.GrupaRepozitorijum.Vrati(1)
            };

            A.CallTo(() => jedinica.KlijentRepozitorijum.Dodaj(k1));
            A.CallTo(() => jedinica.KlijentRepozitorijum.Dodaj(k2));

            k1.Ime = "Zika";
            k1.Kilaza = 95;

            A.CallTo(() => jedinica.KlijentRepozitorijum.Izmeni(k1));


            A.CallTo(() => jedinica.KlijentRepozitorijum.VratiSve()).Returns(new List<Klijent> { k1, k2 });

            // Act.

            var result = await controller.Index();

            var viewResult = result as ViewResult;
            var model = viewResult.Model as List<KlijentViewModel>;

            // Assert.
            Assert.AreEqual(2, model.Count);
            result.Should().NotBeNull();
            Assert.AreEqual("Zika", model[0].Ime);
            Assert.AreEqual("Mika", model[1].Ime);
            Assert.AreEqual("Peric", model[0].Prezime);
            Assert.AreEqual("Mikic", model[1].Prezime);
            Assert.AreEqual(95, model[0].Kilaza);
            Assert.AreEqual(90, model[1].Kilaza);
            Assert.AreEqual(190, model[0].Visina);
            Assert.AreEqual(190, model[1].Visina);
        }

        [Fact]
        public async Task KlijentController_Pretrazi_ReturnSuccess()
        {
            // Arrange.
            var jedinica = A.Fake<IJedinicaPosla>();
            KlijentController controller = new KlijentController(jedinica);

            var k1 = new Klijent()
            {
                KlijentID = 1,
                Ime = "Pera",
                Prezime = "Peric",
                Kilaza = 90,
                Visina = 190,
                PolID = 1,
                Pol = jedinica.PolRepozitorijum.Vrati(1),
                GrupaID = 1,
                Grupa = jedinica.GrupaRepozitorijum.Vrati(1)
            };
            var k2 = new Klijent()
            {
                KlijentID = 2,
                Ime = "Mika",
                Prezime = "Mikic",
                Kilaza = 90,
                Visina = 190,
                PolID = 1,
                Pol = jedinica.PolRepozitorijum.Vrati(1),
                GrupaID = 1,
                Grupa = jedinica.GrupaRepozitorijum.Vrati(1)
            };
            var k3 = new Klijent()
            {
                KlijentID = 3,
                Ime = "Mika",
                Prezime = "Zikic",
                Kilaza = 90,
                Visina = 190,
                PolID = 1,
                Pol = jedinica.PolRepozitorijum.Vrati(1),
                GrupaID = 1,
                Grupa = jedinica.GrupaRepozitorijum.Vrati(1)
            };

            A.CallTo(() => jedinica.KlijentRepozitorijum.Dodaj(k1));
            A.CallTo(() => jedinica.KlijentRepozitorijum.Dodaj(k2));
            A.CallTo(() => jedinica.KlijentRepozitorijum.Dodaj(k3));


            A.CallTo(() => jedinica.KlijentRepozitorijum.Pretrazi("Mika")).Returns(new List<Klijent> { k2, k3 }); ;

            A.CallTo(() => jedinica.KlijentRepozitorijum.VratiSve()).Returns(new List<Klijent> { k1, k2, k3 });

            // Act.

            var result = await controller.Pretrazi("Mika");

            var viewResult = result as ViewResult;
            var model = viewResult.Model as List<PretraziKlijentaViewModel>;

            // Assert.
            Assert.AreEqual(2, model.Count);
            result.Should().NotBeNull();
            Assert.AreEqual("Mika", model[0].Ime);
            Assert.AreEqual("Mika", model[1].Ime);
            Assert.AreEqual("Mikic", model[0].Prezime);
            Assert.AreEqual("Zikic", model[1].Prezime);
            Assert.AreEqual(90, model[0].Kilaza);
            Assert.AreEqual(90, model[1].Kilaza);
            Assert.AreEqual(190, model[0].Visina);
            Assert.AreEqual(190, model[1].Visina);
        }
    }
}
