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
using WebAplikacija.Models;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Aplikacija.Tests.Controller
{
    public class MestoControllerTests
    {
        private IJedinicaPosla jedinica;
        private Context context;

        public MestoControllerTests()
        {
            this.jedinica = A.Fake<IJedinicaPosla>();
            this.context = A.Fake<Context>();
        }

        [Fact]
        public void MestoController_Index_ReturnSuccess()
        {
            //Arrange
            MestoController controller = new MestoController(jedinica);
            var mesta = A.Fake<List<Mesto>>();
            A.CallTo(() => jedinica.MestoRepozitorijum.VratiSve()).Returns<List<Mesto>>(mesta);
            //Act
            var result = controller.Index();
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public async Task MestoController_Index_Return2Mesta()
        {
            // Arrange.
            var jedinica = A.Fake<IJedinicaPosla>();
            MestoController controller = new MestoController(jedinica);

            var m1 = new Mesto()
            {
                Naziv = "Mesto 1"
            };
            var m2 = new Mesto()
            {
               Naziv = "Mesto 2"
            };

            A.CallTo(() => jedinica.MestoRepozitorijum.Dodaj(m1));
            A.CallTo(() => jedinica.MestoRepozitorijum.Dodaj(m2));

            A.CallTo(() => jedinica.MestoRepozitorijum.VratiSve()).Returns(new List<Mesto> { m1, m2 });

            // Act.

            var result = await controller.Index();

            var viewResult = result as ViewResult;
            var model = viewResult.Model as List<MestoViewModel>;

            // Assert.
            Assert.AreEqual(2, model.Count);
            result.Should().NotBeNull();
            Assert.AreEqual("Mesto 1", model[0].Naziv);
            Assert.AreEqual("Mesto 2", model[1].Naziv);
        }
    }
}
