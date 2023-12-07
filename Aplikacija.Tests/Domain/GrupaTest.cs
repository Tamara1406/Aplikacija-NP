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
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        public void GrupaController_Kreiraj_ImeNullException()
        {
            // Arrange
            GrupaController controller = new GrupaController(jedinica);
            
            // Act
            try
            {
                Grupa grupa = new Grupa()
                {
                    GrupaIme = null,
                    TrenerID = 1,
                    MestoID = 1,
                };
                Assert.IsTrue(false, "Expected exception, but none was thrown.");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Value cannot be null. (Parameter 'Morate uneti vrednost za ime!')", ex.Message);
            }
        }

        [Fact]
        public void GrupaController_Kreiraj_ImeOgranicenjeException()
        {
            // Arrange
            GrupaController controller = new GrupaController(jedinica);
            

            //Act
            try
            {
                Grupa grupa = new Grupa()
                {
                    GrupaIme = "Tstststatatatatatatata",
                    TrenerID = 1,
                    MestoID = 1,
                };
                Assert.IsTrue(false, "Expected exception, but none was thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Ime je ograniceno na 20 karaktera!", ex.Message);
            }
        }
    }
}
