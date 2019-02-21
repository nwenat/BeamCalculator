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
            var assert = 4.52;

            // Assert
            Assert.AreEqual(4.52, result);
        }
    }
}
