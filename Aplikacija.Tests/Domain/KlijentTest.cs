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
    public class KlijentTest
    {
        private IJedinicaPosla jedinica;
        private Context context;

        public KlijentTest()
        {
            this.jedinica = A.Fake<IJedinicaPosla>();
            this.context = A.Fake<Context>();
        }

        [Fact]
        public async Task KlijentController_Kreiraj_ImeNullException()

        {
            // Arrange
            KlijentController controller = new KlijentController(jedinica);
            KreirajKlijentaViewModel model = new KreirajKlijentaViewModel()
            {
                Ime = null,
                Prezime = "Peric",
                Kilaza = 90,
                Visina = 185,
                PolID = 1,
                GrupaID = 1
            };
            // Act
            // Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.Kreiraj(model), "Morate uneti vrednost za ime!");
        }

        [Fact]
        public void KlijentController_Kreiraj_ImeOgranicenjeException()
        {
            // Arrange
            KlijentController controller = new KlijentController(jedinica);
            KreirajKlijentaViewModel model = new KreirajKlijentaViewModel()
            {
                Ime = "Peraaaaaaaaaaaaaaaaaa",
                Prezime = "Periccc",
                Kilaza = 90,
                Visina = 185,
                PolID = 1,
                GrupaID = 1
            };

            // Act
            var result = controller.Kreiraj(model);
            var modelState = controller.ModelState;

            // Assert
            var modelStateEntry = modelState.GetValueOrDefault("Ime");
            var errorMessage = modelStateEntry.Errors[0].ErrorMessage;


            Assert.AreEqual("Ime mora imati do 20 karaktera", errorMessage);

        }

        [Fact]
        public async Task KlijentController_Kreiraj_PrezmeNullException()

        {
            // Arrange
            KlijentController controller = new KlijentController(jedinica);
            KreirajKlijentaViewModel model = new KreirajKlijentaViewModel()
            {
                Ime = "Pera",
                Prezime = null,
                Kilaza = 90,
                Visina = 185,
                PolID = 1,
                GrupaID = 1
            };
            // Act
            // Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.Kreiraj(model));
        }

        [Fact]
        public void KlijentController_Kreiraj_PrezimeOgranicenjeException()
        {
            // Arrange
            KlijentController controller = new KlijentController(jedinica);
            KreirajKlijentaViewModel model = new KreirajKlijentaViewModel()
            {
                Ime = "Pera",
                Prezime = "Pericccccccccccccccccccccccccccccc",
                Kilaza = 90,
                Visina = 185,
                PolID = 1,
                GrupaID = 1
            };

            // Act
            var result = controller.Kreiraj(model);
            var modelState = controller.ModelState;

            // Assert
            var modelStateEntry = modelState.GetValueOrDefault("Prezime");
            var errorMessage = modelStateEntry.Errors[0].ErrorMessage;


            Assert.AreEqual("Prezime mora imati do 30 karaktera", errorMessage);

        }

        [Fact]
        public void KlijentController_Kreiraj_KilazaNulaException()
        {
            // Arrange
            KlijentController controller = new KlijentController(jedinica);
            KreirajKlijentaViewModel model = new KreirajKlijentaViewModel()
            {
                Ime = "Pera",
                Prezime = "Peric",
                Kilaza = 0,
                Visina = 185,
                PolID = 1,
                GrupaID = 1
            };

            // Act
            var result = controller.Kreiraj(model);
            var modelState = controller.ModelState;

            // Assert
            var modelStateEntry = modelState.GetValueOrDefault("Kilaza");
            var errorMessage = modelStateEntry.Errors[0].ErrorMessage;


            Assert.AreEqual("Morate uneti kilazu!", errorMessage);

        }

        [Fact]
        public void KlijentController_Kreiraj_VisinaNulaException()
        {
            // Arrange
            KlijentController controller = new KlijentController(jedinica);
            KreirajKlijentaViewModel model = new KreirajKlijentaViewModel()
            {
                Ime = "Pera",
                Prezime = "Peric",
                Kilaza = 90,
                Visina = 0,
                PolID = 1,
                GrupaID = 1
            };

            // Act
            var result = controller.Kreiraj(model);
            var modelState = controller.ModelState;

            // Assert
            var modelStateEntry = modelState.GetValueOrDefault("Visina");
            var errorMessage = modelStateEntry.Errors[0].ErrorMessage;


            Assert.AreEqual("Morate uneti visinu!", errorMessage);

        }
    }
}
