// ***********************************************************************
// <copyright file="RomanNumeral.cs" company="Expro North Sea Ltd">
//     Copyright (c) Expro North Sea Ltd. All rights reserved.
// </copyright>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExproWWS.TechnicalTest
{
    /// <summary>
    /// Class representing a Roman numeral.
    /// </summary>
    public class RomanNumeral
    {
        private const string InvalidValue = "?";
        private readonly int _integerValue;
        private readonly string _stringValue;
        private static readonly List<KeyValuePair<string, int>> _tokens;

        /// <summary>
        /// Static constructor for the <see cref="RomanNumeral"/> class.
        /// </summary>
        static RomanNumeral()
        {
            _tokens = GenerateTokens();
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="RomanNumeral"/> class
        /// </summary>
        /// <param name="integerValue">Integer value to represent as a Roman numeral</param>
        public RomanNumeral(int integerValue)
        {
            _integerValue = integerValue;
            _stringValue = ParseInteger(integerValue);
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="RomanNumeral"/> class
        /// </summary>
        /// <param name="stringValue">Roman numeral string</param>
        public RomanNumeral(string stringValue)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                throw new ArgumentNullException(nameof(stringValue));
            }

            _stringValue = stringValue;
            _integerValue = ParseString(stringValue);
        }

        /// <summary>
        /// Converts a <see cref="RomanNumeral"/> object to a string
        /// </summary>
        /// <param name="r">Roman Numeral object to convert</param>
        public static implicit operator string(RomanNumeral r)
        {
            return r._stringValue;
        }

        /// <summary>
        /// Converts a <see cref="RomanNumeral"/> object to an integer
        /// </summary>
        /// <param name="r">Roman Numeral object to convert</param>
        public static implicit operator int(RomanNumeral r)
        {
            return r._integerValue;
        }

        /// <summary>
        /// Generates a list of valid Roman numeral tokens
        /// </summary>
        /// <returns>List of valid Roman numeral tokens</returns>
        private static List<KeyValuePair<string, int>> GenerateTokens()
        {
            var tokens = new List<KeyValuePair<string, int>>();
            tokens.Add(new KeyValuePair<string, int>("M", 1000));
            tokens.Add(new KeyValuePair<string, int>("CM", 900));
            tokens.Add(new KeyValuePair<string, int>("D", 500));
            tokens.Add(new KeyValuePair<string, int>("CD", 400));
            tokens.Add(new KeyValuePair<string, int>("C", 100));
            tokens.Add(new KeyValuePair<string, int>("XC", 90));
            tokens.Add(new KeyValuePair<string, int>("L", 50));
            tokens.Add(new KeyValuePair<string, int>("XL", 40));
            tokens.Add(new KeyValuePair<string, int>("X", 10));
            tokens.Add(new KeyValuePair<string, int>("IX", 9));
            tokens.Add(new KeyValuePair<string, int>("V", 5));
            tokens.Add(new KeyValuePair<string, int>("I", 1));
            return tokens;
        }

        /// <summary>
        /// Parses an integer value to a Roman numeral string
        /// </summary>
        /// <param name="integerValue">Integer value to parse</param>
        /// <returns>Roman numeral string representing the integer value</returns>
        private string ParseInteger(int integerValue)
        {
            if (integerValue <=0)
            {
                return InvalidValue;
            }

            var orderedTokens = _tokens.OrderByDescending(t => t.Value).ToList();
            var romanNumeral = new StringBuilder();

            while(integerValue > 0)
            {
                var closestToken = orderedTokens.First(t => t.Value <= integerValue);
                romanNumeral.Append(closestToken.Key);
                integerValue -= closestToken.Value;
            }

            return romanNumeral.ToString();
        }

        /// <summary>
        /// Parses a Roman numeral string to an integer value
        /// </summary>
        /// <param name="stringValue">Roman numeral string to parse</param>
        /// <returns>Integer value of the Roman numeral string</returns>
        private int ParseString(string stringValue)
        {
            int value = 0;
            var orderedTokens = _tokens.OrderByDescending(t => t.Value).ToList();
            while (stringValue.Length > 0)
            {
                bool foundToken = false;
                foreach(var token in orderedTokens)
                {
                    if (stringValue.StartsWith(token.Key))
                    {
                        value += token.Value;
                        stringValue = stringValue.Substring(token.Key.Length);
                        foundToken = true;
                        break;
                    }
                }

                if (!foundToken)
                {
                    throw new ArgumentException($"{stringValue} cannot be parsed as a Roman numeral");
                }
            }

            return value;
        }
    }
}
