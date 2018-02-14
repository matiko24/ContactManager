using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Helpers.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void Add_ExpectedFour Test()
        {
            //Arrange
            int a = 0, b = 1, c= 3;
            Calculator calculator = new Calculator();
            //Act
            int result = calculator.Add(a, b, c);
            //Assert
            Assert.AreEqual(4, result);
        }
    }
}