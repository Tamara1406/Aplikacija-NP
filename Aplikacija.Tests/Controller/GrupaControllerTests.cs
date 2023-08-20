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
    }
}
