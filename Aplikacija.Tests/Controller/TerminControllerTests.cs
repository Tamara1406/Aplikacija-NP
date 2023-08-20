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
    }
}
