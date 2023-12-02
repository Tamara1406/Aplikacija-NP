using FakeItEasy;
using PristupPodacima.Jedinica_Posla;
using PristupPodacima;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAplikacija.Controllers;
using WebAplikacija.Models;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Aplikacija.Tests.Domain
{
    public class GrupaTest
    {
        private IJedinicaPosla jedinica;
        private Context context;

        public GrupaTest()
        {
            this.jedinica = A.Fake<IJedinicaPosla>();
            this.context = A.Fake<Context>();
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
