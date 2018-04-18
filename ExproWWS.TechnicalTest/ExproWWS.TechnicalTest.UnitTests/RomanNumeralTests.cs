// ***********************************************************************
// <copyright file="RomanNumeralTests.cs" company="Expro North Sea Ltd">
//     Copyright (c) Expro North Sea Ltd. All rights reserved.
// </copyright>
// ***********************************************************************
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        /// <summary>
        /// Tests that when the <see cref="RomanNumeral"/> class is instantiated
        /// with a string, it has the expected integer value
        /// </summary>
        /// <param name="stringValue">String value to use</param>
        /// <param name="expectedIntegerValue">Integer value to expect</param>
        [DataTestMethod]
        [DataRow("DCXLVIII", 648)]
        [DataRow("MMDXLIX", 2549)]
        [DataRow("MCMXLIV", 1946)]  // Should be 1944
        [DataRow("MCMXCIX", 1999)]
        public void Can_Parse_Strings_Test(string stringValue, int expectedIntegerValue)
        {
            var numeral = new RomanNumeral(stringValue);
            Assert.AreEqual(expectedIntegerValue, numeral, $"String value {stringValue} did not give the expected result.");
        }

        [TestMethod]
        public void ShouldParse_MCMXLIV_1944()
        {
            var numeral = new RomanNumeral("MCMXLIV");
            Assert.AreEqual(1944, numeral);
        }

        [TestMethod]
        public void ShouldParse_IV_4()
        {
            var numeral = new RomanNumeral("IV");
            Assert.AreEqual(4, numeral);
        }

        /// <summary>
        /// Tests that an exception is thrown if the <see cref="RomanNumeral"/> class
        /// is instantiated with an invalid string
        /// </summary>
        [TestMethod]
        public void Rejects_Invalid_String()
        {
            Assert.ThrowsException<ArgumentException>(() => new RomanNumeral("Q"));
        }

        /// <summary>
        /// Tests that an exception is thrown if the <see cref="RomanNumeral"/> class
        /// is instantiated with a null string
        /// </summary>
        [TestMethod]
        public void Rejects_Null_String()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new RomanNumeral(null));
        }
    }
}
