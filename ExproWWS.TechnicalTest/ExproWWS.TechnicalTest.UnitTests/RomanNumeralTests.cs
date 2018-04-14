// ***********************************************************************
// <copyright file="RomanNumeralTests.cs" company="Expro North Sea Ltd">
//     Copyright (c) Expro North Sea Ltd. All rights reserved.
// </copyright>
// ***********************************************************************
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExproWWS.TechnicalTest.UnitTests
{
    /// <summary>
    /// Unit tests for the <see cref="RomanNumeral"/> class
    /// </summary>
    [TestClass]
    public class RomanNumeralTests
    {
        /// <summary>
        /// Tests that when the <see cref="RomanNumeral"/> class is instantiated
        /// with an integer, it gets converted to the expected string
        /// </summary>
        /// <param name="integerValue">Integer value to use</param>
        /// <param name="expectedNumeralValue">Numeral (string) value to expect</param>
        [DataTestMethod]
        [DataRow(-1, "?")]
        [DataRow(0, "?")]
        [DataRow(47, "XLVII")]
        [DataRow(123, "CXXIII")]
        [DataRow(1998, "MCMXCVIII")]
        [DataRow(2345, "MMCCCXLV")]
        public void Can_Parse_Integers_Test(int integerValue, string expectedNumeralValue)
        {
            var numeral = new RomanNumeral(integerValue);
            Assert.AreEqual(expectedNumeralValue, numeral, $"Integer value {integerValue} did not give the expected result.");
        }
    
    }
}
