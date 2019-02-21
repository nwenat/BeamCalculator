using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WpfApp1._0.UnitTests
{
    [TestClass]
    public class CrossSectionCharacteristicsUnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var characteristic = new CrossSectionCharacteristics();

            // Act
            characteristic.CountAs1 = 4;
            characteristic.FiAs1 = 12;
            characteristic.Calculate();
            var result = Math.Round(characteristic.AreaAs1, 2);

            // Assert
            Assert.AreEqual(4.52, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            var characteristic = new CrossSectionCharacteristics();

            // Act
            characteristic.CountAp = 4;
            characteristic.FiAp = 12;
            characteristic.Calculate();
            var result = Math.Round(characteristic.AreaAp, 2);

            // Assert
            Assert.AreEqual(4.52, result);
        }
    }
}
