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
    public class TrenerTest
    {
        private IJedinicaPosla jedinica;
        private Context context;

        public TrenerTest()
        {
            this.jedinica = A.Fake<IJedinicaPosla>();
            this.context = A.Fake<Context>();
        }

        [Fact]
        public async Task TrenerController_Kreiraj_ImeNullException()

        {
            // Arrange
            TrenerController controller = new TrenerController(jedinica);
            KreirajTreneraViewModel model = new KreirajTreneraViewModel()
            {
                Prezime = "Peric",
                ObrazovanjeID = 1,
                Opis = "Ovo je trener",
                Slika = "slika"
            };
            // Act
            // Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.Kreiraj(model), "Morate uneti vrednost za ime!");
        }

        [Fact]
        public void TrenerController_Kreiraj_ImeOgranicenjeException()
        {
            // Arrange
            TrenerController controller = new TrenerController(jedinica);
            KreirajTreneraViewModel model = new KreirajTreneraViewModel()
            {
                Ime = "Peraaaaaaaaaaaaaaaaaa",
                Prezime = "Peric",
                ObrazovanjeID = 1,
                Opis = "Ovo je trener",
                Slika = "slika"
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
        public async Task TrenerController_Kreiraj_PrezmeNullException()

        {
            // Arrange
            TrenerController controller = new TrenerController(jedinica);
            KreirajTreneraViewModel model = new KreirajTreneraViewModel()
            {
                Ime = "Pera",
                ObrazovanjeID = 1,
                Opis = "Ovo je trener",
                Slika = "slika"
            };
            // Act
            // Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.Kreiraj(model));
        }

        [Fact]
        public void TrenerController_Kreiraj_PrezimeOgranicenjeException()
        {
            // Arrange
            TrenerController controller = new TrenerController(jedinica);
            KreirajTreneraViewModel model = new KreirajTreneraViewModel()
            {
                Ime = "Pera",
                Prezime = "Pericccccccccccccccccccccccccccccc",
                ObrazovanjeID = 1,
                Opis = "Ovo je trener",
                Slika = "slika"
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
        public async Task TrenerController_Kreiraj_OpisNullException()

        {
            // Arrange
            TrenerController controller = new TrenerController(jedinica);
            KreirajTreneraViewModel model = new KreirajTreneraViewModel()
            {
                Ime = "Pera",
                Prezime = "Peric",
                ObrazovanjeID = 1,
                Slika = "slika"
            };
            // Act
            // Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => controller.Kreiraj(model));
        }

        [Fact]
        public void TrenerController_Kreiraj_OpisOgranicenjeException()
        {
            // Arrange
            TrenerController controller = new TrenerController(jedinica);
            KreirajTreneraViewModel model = new KreirajTreneraViewModel()
            {
                Ime = "Pera",
                Prezime = "Peric",
                ObrazovanjeID = 1,
                Opis = "Ovo je treneraaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Slika = "slika"
            };

            // Act
            var result = controller.Kreiraj(model);
            var modelState = controller.ModelState;

            // Assert
            var modelStateEntry = modelState.GetValueOrDefault("Opis");
            var errorMessage = modelStateEntry.Errors[0].ErrorMessage;


            Assert.AreEqual("Opis mora imati do 50 karaktera", errorMessage);

        }
    }
}
