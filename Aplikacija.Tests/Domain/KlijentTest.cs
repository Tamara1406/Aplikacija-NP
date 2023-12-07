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

            try
            {
                Klijent model = new Klijent()
                {
                    Ime = null,
                    Prezime = "Peric",
                    Kilaza = 90,
                    Visina = 185,
                    PolID = 1,
                    GrupaID = 1
                };
                Assert.IsTrue(false, "Expected exception, but none was thrown.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null. (Parameter 'Morate uneti vrednost za ime!')", ex.Message);
            }
        }

        [Fact]
        public void KlijentController_Kreiraj_ImeOgranicenjeException()
        {
            // Arrange
            KlijentController controller = new KlijentController(jedinica);
            try
            {
                Klijent model = new Klijent()
                {
                    Ime = "Peraaaaaaaaaaaaaaaaaa",
                    Prezime = "Periccc",
                    Kilaza = 90,
                    Visina = 185,
                    PolID = 1,
                    GrupaID = 1
                }; 
                Assert.IsTrue(false, "Expected exception, but none was thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Ime je ograniceno na 20 karaktera!", ex.Message);

            }

        }

        [Fact]
        public async Task KlijentController_Kreiraj_PrezmeNullException()

        {
            // Arrange
            KlijentController controller = new KlijentController(jedinica);
            try
            {
                Klijent model = new Klijent()
                {
                    Ime = "Pera",
                    Prezime = null,
                    Kilaza = 90,
                    Visina = 185,
                    PolID = 1,
                    GrupaID = 1
                };
                Assert.IsTrue(false, "Expected exception, but none was thrown.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null. (Parameter 'Morate uneti vrednost za prezime!')", ex.Message);
            }
        }

        [Fact]
        public void KlijentController_Kreiraj_PrezimeOgranicenjeException()
        {
            // Arrange
            KlijentController controller = new KlijentController(jedinica);
            try
            {
                Klijent model = new Klijent()
                {
                    Ime = "Pera",
                    Prezime = "Pericccccccccccccccccccccccccccccc",
                    Kilaza = 90,
                    Visina = 185,
                    PolID = 1,
                    GrupaID = 1
                };
                Assert.IsTrue(false, "Expected exception, but none was thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Prezime je ograniceno na 30 karaktera!", ex.Message);

            }
        }

        [Fact]
        public void KlijentController_Kreiraj_KilazaNulaException()
        {
            // Arrange
            KlijentController controller = new KlijentController(jedinica);
            try
            {
                Klijent model = new Klijent()
                {
                    Ime = "Pera",
                    Prezime = "Peric",
                    Kilaza = 0,
                    Visina = 185,
                    PolID = 1,
                    GrupaID = 1
                };
                Assert.IsTrue(false, "Expected exception, but none was thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Morate uneti vrednost za kilazu!", ex.Message);
            }

        }

        [Fact]
        public void KlijentController_Kreiraj_VisinaNulaException()
        {
            // Arrange
            KlijentController controller = new KlijentController(jedinica);
            
            try
            {
                Klijent model = new Klijent()
                {
                    Ime = "Pera",
                    Prezime = "Peric",
                    Kilaza = 90,
                    Visina = 0,
                    PolID = 1,
                    GrupaID = 1
                };
                Assert.IsTrue(false, "Expected exception, but none was thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Morate uneti vrednost za visinu!", ex.Message);

            }
        }
    }
}
