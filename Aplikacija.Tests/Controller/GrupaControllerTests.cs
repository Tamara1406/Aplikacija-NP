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
    }
}
