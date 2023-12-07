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
using System.Text.RegularExpressions;
using NUnit.Framework.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using WebAplikacija.Models;
using NuGet.Protocol;

namespace Aplikacija.Tests.Controller
{
    public class GrupaControllerTests
    {
        private IJedinicaPosla jedinica;
        private Context context;

        public GrupaControllerTests()
        {
            this.jedinica = A.Fake<IJedinicaPosla>();
            this.context = A.Fake<Context>();
        }

        [Fact]
        public void GrupaController_Index_ReturnSuccess()
        {
            //Arrange
            GrupaController controller = new GrupaController(jedinica);
            var grupe = A.Fake<List<Grupa>>();
            A.CallTo(() => jedinica.GrupaRepozitorijum.VratiSve()).Returns<List<Grupa>>(grupe);
            //Act
            var result = controller.Index();
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void GrupaController_IndexAdmin_ReturnSuccess()
        {
            //Arrange
            GrupaController controller = new GrupaController(jedinica);
            var grupe = A.Fake<List<Grupa>>();
            A.CallTo(() => jedinica.GrupaRepozitorijum.VratiSve()).Returns<List<Grupa>>(grupe);
            //Act
            var result = controller.IndexAdmin();
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void GrupaController_Kreiraj_ReturnSuccess()
        {
            // Arrange.
            GrupaController controller = new GrupaController(jedinica);
            var g = new Grupa()
            {
                GrupaIme = "Ime grupe",
                TrenerID = 1,
                MestoID = 1
            };
            A.CallTo(() => jedinica.GrupaRepozitorijum.Dodaj(g));
            // Act.
            var result = controller.Kreiraj();
            // Assert.
            result.Should().BeOfType<Task<IActionResult>>();
        }

        

        [Fact]
        public void GrupaController_Kreiraj_ReturnSuccess2()
        {
            // Arrange.
            GrupaController controller = new GrupaController(jedinica);
            var g = new Grupa()
            {
                GrupaIme = "Ime grupe",
                TrenerID = 1,
                MestoID = 1
            };
            A.CallTo(() => jedinica.GrupaRepozitorijum.Dodaj(g));
            // Act.
            var result = controller.Kreiraj();
            // Assert.
            Assert.IsNotNull(result);
        }

        [Fact]
        public async Task GrupaController_Index_Return2Groups()
        {
            // Arrange.
            var jedinica = A.Fake<IJedinicaPosla>();
            GrupaController controller = new GrupaController(jedinica);
            
            var g1 = new Grupa()
            {
                GrupaIme = "Prva grupa",
                TrenerID =1002,
                Trener = jedinica.TrenerRepozitorijum.Vrati(1002),
                MestoID = 1,
                Mesto = jedinica.MestoRepozitorijum.Vrati(1)
            };
            var g2 = new Grupa()
            {
                GrupaIme = "Druga grupa",
                TrenerID = 1002,
                Trener = jedinica.TrenerRepozitorijum.Vrati(1002),
                MestoID = 1,
                Mesto = jedinica.MestoRepozitorijum.Vrati(1)
            };

            A.CallTo(() => jedinica.GrupaRepozitorijum.Dodaj(g1));
            A.CallTo(() => jedinica.GrupaRepozitorijum.Dodaj(g2));

            A.CallTo(() => jedinica.GrupaRepozitorijum.VratiSve()).Returns(new List<Grupa> { g1, g2 });

            // Act.

            var result = await controller.Index();

            var viewResult = result as ViewResult;
            var model = viewResult.Model as List<GrupaViewModel>;

            // Assert.
            Assert.AreEqual(2, model.Count);
            result.Should().NotBeNull();
            Assert.AreEqual("Prva grupa", model[0].GrupaIme);
            Assert.AreEqual("Druga grupa", model[1].GrupaIme);
        }

        [Fact]
        public async Task GrupaController_Delete_ReturnSuccess()
        {
            // Arrange.
            var jedinica = A.Fake<IJedinicaPosla>();
            GrupaController controller = new GrupaController(jedinica);

            var g1 = new Grupa()
            {
                GrupaID = 1,
                GrupaIme = "Prva",
                TrenerID = 1,
                Trener = jedinica.TrenerRepozitorijum.Vrati(1),
                MestoID = 1,
                Mesto = jedinica.MestoRepozitorijum.Vrati(1)
            };
            var g2 = new Grupa()
            {
                GrupaID = 2,
                GrupaIme = "Druga",
                TrenerID = 1,
                Trener = jedinica.TrenerRepozitorijum.Vrati(1),
                MestoID = 1,
                Mesto = jedinica.MestoRepozitorijum.Vrati(1)
            };

            A.CallTo(() => jedinica.GrupaRepozitorijum.Dodaj(g1));
            A.CallTo(() => jedinica.GrupaRepozitorijum.Dodaj(g2));

            A.CallTo(() => jedinica.GrupaRepozitorijum.VratiSve()).Returns(new List<Grupa> { g1, g2 });

            //// Act.
            var obrisiResult = controller.Obrisi(g1.GrupaID);
            var obrisiViewResult = obrisiResult as ViewResult;
            var obrisanaGrupa = obrisiViewResult.Model as ObrisiGrupuViewModel;

            // Assert.
            obrisiResult.Should().NotBeNull();
            Assert.AreEqual("Prva", obrisanaGrupa.GrupaIme);

            //// Act.
            A.CallTo(() => jedinica.GrupaRepozitorijum.VratiSve()).Returns(new List<Grupa> { g2 });


            var result = await controller.Index();

            var viewResult = result as ViewResult;
            var model = viewResult.Model as List<GrupaViewModel>;


            // Assert.
            Assert.AreEqual(1, model.Count);
            result.Should().NotBeNull();
            Assert.AreEqual("Druga", model[0].GrupaIme);
        }

        [Fact]
        public async Task GrupaController_Delete_Error()
        {
            // Arrange.
            var jedinica = A.Fake<IJedinicaPosla>();
            GrupaController controller = new GrupaController(jedinica);

            var g1 = new Grupa()
            {
                GrupaID = 1,
                GrupaIme = "Prva",
                TrenerID = 1,
                Trener = jedinica.TrenerRepozitorijum.Vrati(1),
                MestoID = 1,
                Mesto = jedinica.MestoRepozitorijum.Vrati(1)
            };
            var g2 = new Grupa()
            {
                GrupaID = 2,
                GrupaIme = "Druga",
                TrenerID = 1,
                Trener = jedinica.TrenerRepozitorijum.Vrati(1),
                MestoID = 1,
                Mesto = jedinica.MestoRepozitorijum.Vrati(1)
            };

            A.CallTo(() => jedinica.GrupaRepozitorijum.Dodaj(g1));
            A.CallTo(() => jedinica.GrupaRepozitorijum.Dodaj(g2));

            A.CallTo(() => jedinica.GrupaRepozitorijum.VratiSve()).Returns(new List<Grupa> { g1, g2 });

            //// Act.

            // Assert.
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(() => (Task)controller.Obrisi(3));
        }

        [Fact]
        public void GrupaController_Pretrazi_ReturnSuccess()
        {
            // Arrange.
            var jedinica = A.Fake<IJedinicaPosla>();
            GrupaController controller = new GrupaController(jedinica);


            var g1 = new Grupa()
            {
                GrupaID = 1,
                GrupaIme = "Prva",
                TrenerID = 1,
                Trener = jedinica.TrenerRepozitorijum.Vrati(1),
                MestoID = 1,
                Mesto = new Mesto() { Naziv = "prvo"},
                
            };
            var g2 = new Grupa()
            {
                GrupaID = 2,
                GrupaIme = "Druga",
                TrenerID = 1,
                Trener = jedinica.TrenerRepozitorijum.Vrati(1),
                MestoID = 1,
                Mesto = new Mesto() { Naziv = "drugo" }
            };
            var g3 = new Grupa()
            {
                GrupaID = 3,
                GrupaIme = "Druga 2",
                TrenerID = 1,
                Trener = jedinica.TrenerRepozitorijum.Vrati(1),
                MestoID = 1,
                Mesto = new Mesto() { Naziv = "drugo" }
            };

            A.CallTo(() => jedinica.GrupaRepozitorijum.Dodaj(g1));
            A.CallTo(() => jedinica.GrupaRepozitorijum.Dodaj(g2));


            A.CallTo(() => jedinica.GrupaRepozitorijum.VratiSve()).Returns(new List<Grupa> { g1, g2, g3 });

            // Act.
            // proverava sa Equals

            var result =  controller.Pretrazi("drugo");

            var viewResult = result as ViewResult;
            var model = viewResult.Model as List<PretraziGrupuViewModel>;

            // Assert.
            result.Should().NotBeNull();
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual("Druga", model[0].GrupaIme);
            Assert.AreEqual("Druga 2", model[1].GrupaIme);
        }

        [Fact]
        public void GrupaController_PretraziTrener_ReturnSuccess()
        {
            // Arrange.
            var jedinica = A.Fake<IJedinicaPosla>();
            GrupaController controller = new GrupaController(jedinica);


            var g1 = new Grupa()
            {
                GrupaID = 1,
                GrupaIme = "Prva",
                TrenerID = 2,
                Trener = new Trener() { TrenerID = 2, Ime = "Mika", Prezime = "Mikic"},
                MestoID = 1,
                Mesto = new Mesto() { Naziv = "prvo" },

            };
            var g2 = new Grupa()
            {
                GrupaID = 2,
                GrupaIme = "Druga",
                TrenerID = 1,
                Trener = new Trener() { TrenerID = 1, Ime = "Pera", Prezime = "Peric" },
                MestoID = 1,
                Mesto = new Mesto() { Naziv = "drugo" }
            };
            var g3 = new Grupa()
            {
                GrupaID = 3,
                GrupaIme = "Druga 2",
                TrenerID = 1,
                Trener = new Trener() { TrenerID = 1, Ime = "Pera", Prezime = "Peric" },
                MestoID = 1,
                Mesto = new Mesto() { Naziv = "trece" }
            };

            A.CallTo(() => jedinica.GrupaRepozitorijum.Dodaj(g1));
            A.CallTo(() => jedinica.GrupaRepozitorijum.Dodaj(g2));

            A.CallTo(() => jedinica.GrupaRepozitorijum.VratiSve()).Returns(new List<Grupa> { g1, g2, g3 });

            // Act.
            // proverava sa Equals

            var result = controller.PretraziTrener(1);

            var viewResult = result as ViewResult;
            var model = viewResult.Model as List<PretraziGrupuViewModel>;

            // Assert.
            result.Should().NotBeNull();
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual("Druga", model[0].GrupaIme);
            Assert.AreEqual("Druga 2", model[1].GrupaIme);
        }

        [Fact]
        public async Task GrupaController_Kreiraj_ImeNullException()
        {
            // Arrange
            GrupaController controller = new GrupaController(jedinica);
            KreirajGrupuViewModel model = new KreirajGrupuViewModel()
            {
                GrupaIme = null,
                TrenerID = 1,
                MestoID = 1,
            };
            // Act
            // Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.Kreiraj(model));
        }

        [Fact]
        public void GrupaController_Kreiraj_ImeOgranicenjeException()
        {
            // Arrange
            GrupaController controller = new GrupaController(jedinica);
            KreirajGrupuViewModel model = new KreirajGrupuViewModel()
            {
                GrupaIme = "Tstststatatatatatatata",
                TrenerID = 1,
                MestoID = 1,
            };

            //Act
            var result = controller.Kreiraj(model);
            var modelState = controller.ModelState;

            // Assert
            var modelStateEntry = modelState.GetValueOrDefault("GrupaIme");
            var errorMessage = modelStateEntry.Errors[0].ErrorMessage;


            Assert.AreEqual("Ime grupe mora imati do 20 karaktera", errorMessage);
        }
    }
}
