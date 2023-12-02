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
    public class TerminControllerTests
    {
        private IJedinicaPosla jedinica;
        private Context context;

        public TerminControllerTests()
        {
            this.jedinica = A.Fake<IJedinicaPosla>();
            this.context = A.Fake<Context>();
        }

        [Fact]
        public void TerminController_Index_ReturnSuccess()
        {
            //Arrange
            TerminController controller = new TerminController(jedinica);
            var termini = A.Fake<List<Termin>>();
            A.CallTo(() => jedinica.TerminRepozitorijum.VratiSve()).Returns<List<Termin>>(termini);
            //Act
            var result = controller.Index();
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public async Task TerminController_Index_Return2Termini()
        {
            // Arrange.
            var jedinica = A.Fake<IJedinicaPosla>();
            TerminController controller = new TerminController(jedinica);

            var t1 = new Termin()
            {
                VremeTermina = new DateTime(2015, 12, 25, 10, 30, 45),
                GrupaID = 1,
                Grupa = jedinica.GrupaRepozitorijum.Vrati(1)
            };
            var t2 = new Termin()
            {
                VremeTermina = new DateTime(2015, 12, 25, 10, 30, 45),
                GrupaID = 1,
                Grupa = jedinica.GrupaRepozitorijum.Vrati(1)
            };

            A.CallTo(() => jedinica.TerminRepozitorijum.Dodaj(t1));
            A.CallTo(() => jedinica.TerminRepozitorijum.Dodaj(t2));

            A.CallTo(() => jedinica.TerminRepozitorijum.VratiSve()).Returns(new List<Termin> { t1, t2 });

            // Act.

            var result = await controller.Index();

            var viewResult = result as ViewResult;
            var model = viewResult.Model as List<TerminViewModel>;

            // Assert.
            Assert.AreEqual(2, model.Count);
            result.Should().NotBeNull();
            Assert.AreEqual(new DateTime(2015, 12, 25, 10, 30, 45), model[0].VremeTermina);
            Assert.AreEqual(new DateTime(2015, 12, 25, 10, 30, 45), model[1].VremeTermina);
        }
    }
}
