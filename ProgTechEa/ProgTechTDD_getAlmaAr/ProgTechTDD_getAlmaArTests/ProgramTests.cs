using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgTechTDD_getAlmaAr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgTechTDD_getAlmaAr.Tests
{
    [TestClass()]   // 2. create test project/file
    public class ProgramTests
    {
        [TestMethod()]  // 3. test the Vasarcsarnok class - I.: build error, II.: green
        public void VasarcsarnokClassTest()
        {
            Vasarcsarnok vasarcsarnok = new Vasarcsarnok();

            Assert.IsNotNull(vasarcsarnok);
        }

        [TestMethod()]  // 6. test the AlmaAr property - I.: build error, II.: green
        public void VasarcsarnokAlmaArTest()
        {
            Vasarcsarnok vasarcsarnok = new Vasarcsarnok();
            double almaAr = vasarcsarnok.AlmaAr = 1000;
            double expectedAlmaPrice = 1000;
            
            Assert.AreEqual(expectedAlmaPrice, almaAr);
        }

        [TestMethod()]  // 8. test the AlmaAr property - I.: build error, II.: green
        public void VasarcsarnokAlmaArTipusTest()
        {
            var propertyInfo = typeof(Vasarcsarnok).GetProperty("AlmaAr");

            Assert.AreEqual(typeof(double), propertyInfo.PropertyType);
        }

        [TestMethod()]  // 10. test the getAlmaAr method - I.: build error, , II.: green
        public void GetAlmaArExistenceTest()
        {
            Vasarcsarnok vasarcsarnok = new Vasarcsarnok();
            double kg = 1;

            Assert.IsNotNull(vasarcsarnok.GetAlmaAr(kg));
        }

        [TestMethod()]  // 12. test the type of GetAlmaAr - I.: red, II.: green
        public void GetAlmaArTypeTest()
        {
            var methodInfo = typeof(Vasarcsarnok).GetMethod("GetAlmaAr");

            Assert.AreEqual(typeof(double), methodInfo.ReturnType);
        }

        [TestMethod()]  // 14. test the AlmaAr property - I.: red, II.: green
        public void GetAlmaArBasicTest()
        {
            Vasarcsarnok vasarcsarnok = new Vasarcsarnok();
            vasarcsarnok.AlmaAr = 5;
            double weight = 3;
            double price = weight * vasarcsarnok.AlmaAr;

            Assert.AreEqual(3 * 5, vasarcsarnok.GetAlmaAr(weight));
        }

        [TestMethod()]  // 12. test the AlmaAr property - I.: red, II.: green
        public void GetAlmaArAtleast5kgsTest()
        {
            Vasarcsarnok vasarcsarnok = new Vasarcsarnok();
            vasarcsarnok.AlmaAr = 5;
            double weight = 5;
            double price = weight * vasarcsarnok.AlmaAr;
            if (weight >= 5)
            {
                price *= 0.9;
            }

            Assert.AreEqual(5 * 5 * 0.9, vasarcsarnok.GetAlmaAr(weight));
        }

        [TestMethod()]  // 12. test the AlmaAr property - I.: red, II.: green
        public void GetAlmaArAtleast20kgsTest()
        {
            Vasarcsarnok vasarcsarnok = new Vasarcsarnok();
            vasarcsarnok.AlmaAr = 5;
            double weight = 20;
            double expectedPrice = weight * vasarcsarnok.AlmaAr;
            if (weight >= 20)
            {
                expectedPrice *= 0.8;
            }

            Assert.AreEqual(expectedPrice, vasarcsarnok.GetAlmaAr(weight));
        }

        [TestMethod()]  // 12. test the AlmaAr property - I.: red, II.: green
        public void GetAlmaArPositiveParamTest()
        {
        }


    }
}
