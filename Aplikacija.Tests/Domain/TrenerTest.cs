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
using Domen;

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
            try
            {
                Trener model = new Trener()
                {
                    Ime = null,
                    Prezime = "Peric",
                    ObrazovanjeID = 1,
                    Opis = "Ovo je trener",
                    Slika = "slika"
                }; 
                Assert.IsTrue(false, "Expected exception, but none was thrown.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null. (Parameter 'Morate uneti vrednost za ime!')", ex.Message);
            }
        }

        [Fact]
        public void TrenerController_Kreiraj_ImeOgranicenjeException()
        {
            // Arrange
            TrenerController controller = new TrenerController(jedinica);
            
            try
            {
                Trener model = new Trener()
                {
                    Ime = "Peraaaaaaaaaaaaaaaaaa",
                    Prezime = "Peric",
                    ObrazovanjeID = 1,
                    Opis = "Ovo je trener",
                    Slika = "slika"
                };
                Assert.IsTrue(false, "Expected exception, but none was thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Ime je ograniceno na 20 karaktera!", ex.Message);
            }
        }

        [Fact]
        public async Task TrenerController_Kreiraj_PrezmeNullException()

        {
            // Arrange
            TrenerController controller = new TrenerController(jedinica);
             try
            {
                Trener model = new Trener()
                {
                    Ime = "Pera",
                    Prezime = null,
                    ObrazovanjeID = 1,
                    Opis = "Ovo je trener",
                    Slika = "slika"
                };
                Assert.IsTrue(false, "Expected exception, but none was thrown.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null. (Parameter 'Morate uneti vrednost za prezime!')", ex.Message);
            }
        }

        [Fact]
        public void TrenerController_Kreiraj_PrezimeOgranicenjeException()
        {
            // Arrange
            TrenerController controller = new TrenerController(jedinica);
            try
            {
                Trener model = new Trener()
                {
                    Ime = "Pera",
                    Prezime = "Pericccccccccccccccccccccccccccccc",
                    ObrazovanjeID = 1,
                    Opis = "Ovo je trener",
                    Slika = "slika"
                };
                Assert.IsTrue(false, "Expected exception, but none was thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Prezime je ograniceno na 30 karaktera!", ex.Message);
            }
        }

        [Fact]
        public async Task TrenerController_Kreiraj_OpisNullException()

        {
            // Arrange
            TrenerController controller = new TrenerController(jedinica);
            try
            {
                Trener model = new Trener()
                {
                    Ime = "Pera",
                    Prezime = "Peric",
                    ObrazovanjeID = 1,
                    Opis = null,
                    Slika = "slika"
                };
                Assert.IsTrue(false, "Expected exception, but none was thrown.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null. (Parameter 'Morate uneti opis!')", ex.Message);
            }
        }

        [Fact]
        public void TrenerController_Kreiraj_OpisOgranicenjeException()
        {
            // Arrange
            TrenerController controller = new TrenerController(jedinica);
            
            try
            {
                Trener model = new Trener()
                {
                    Ime = "Pera",
                    Prezime = "Peric",
                    ObrazovanjeID = 1,
                    Opis = "Ovo je treneraaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                    Slika = "slika"
                };
                Assert.IsTrue(false, "Expected exception, but none was thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Opis je ogranicen na 50 karaktera!", ex.Message);
            }

        }
    }
}
