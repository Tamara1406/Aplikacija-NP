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
    }
}
