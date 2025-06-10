using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgTechTDD_getAlmaAr2;
using ProgTechTDD_getAlmaAr2.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgTechTDD_getAlmaAr2.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void VasarcsarnokTest() // 1: build error -> 2: green
        {
            var vasarcsarnok = new Vasarcsarnok();
            Assert.IsNotNull(vasarcsarnok);
        }

        [TestMethod()]
        public void AlmaArPropExistenceTest() // 3: build error -> 4: green
        {
            var vasarcsarnok = new Vasarcsarnok();
            vasarcsarnok.AlmaAr = 1000;
            Assert.AreEqual(1000, vasarcsarnok.AlmaAr);
        }

        [TestMethod()]
        public void GetAlmaArExistenceTest() // 5: build error -> 6: green
        {
            var vasarcsarnok = new Vasarcsarnok();
            double result = vasarcsarnok.GetAlmaAr(5);
        }

        [TestMethod()]
        public void GetAlmaArBasicPriceTest() // 7: red -> 8: green
        {
            var vasarcsarnok = new Vasarcsarnok { AlmaAr = 1000 };
            double result = vasarcsarnok.GetAlmaAr(3);
            Assert.AreEqual(3000, result);
        }

        [TestMethod()]
        public void GetAlmaAr10PercentDiscountTest() // 9: red -> 10: green
        {
            var vasarcsarnok = new Vasarcsarnok { AlmaAr = 1000 };
            double result = vasarcsarnok.GetAlmaAr(5);
            Assert.AreEqual(4500, result);
        }

        [TestMethod()]
        public void GetAlmaAr20PercentDiscountTest() // 11: red -> 12: green
        {
            var vasarcsarnok = new Vasarcsarnok { AlmaAr = 1000 };
            double result = vasarcsarnok.GetAlmaAr(20);
            Assert.AreEqual(16000, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(AlmaWeightException))]
        public void AlmaWeightExceptionLowTest() // 13: build error -> 14: green
        {
            var vasarcsarnok = new Vasarcsarnok { AlmaAr = 1000 };
            vasarcsarnok.GetAlmaAr(0);
        }

        [TestMethod()]
        [ExpectedException(typeof(AlmaWeightException))]
        public void AlmaWeightExceptionHeighTest()
        {
            var vasarcsarnok = new Vasarcsarnok { AlmaAr = 1000 };
            vasarcsarnok.GetAlmaAr(100.01);
        }



    }
}