using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Nagma.CountVowels
{
    [TestFixture]
    public class Test_ExtensionMethods
    {
        [Test]
        public void CountVowels_AllVowelsOnce_ReturnsOneForEach()
        {
            Dictionary<char, int> actual;
            Dictionary<char, int> expected = new Dictionary<char, int>
            {
                { 'a', 1 },
                { 'e', 1 },
                { 'i', 1 },
                { 'o', 1 },
                { 'u', 1 }
            };

            actual = "aeiou".CountVowels();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountVowels_AllVowelsTwice_ReturnsTwoForEach()
        {
            Dictionary<char, int> actual;
            Dictionary<char, int> expected = new Dictionary<char, int>
            {
                { 'a', 2 },
                { 'e', 2 },
                { 'i', 2 },
                { 'o', 2 },
                { 'u', 2 }
            };

            actual = "aeiouaeiou".CountVowels();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountVowels_AllVowelsCapitalizedOnce_ReturnsOneForEach()
        {
            Dictionary<char, int> actual;
            Dictionary<char, int> expected = new Dictionary<char, int>
            {
                { 'a', 1 },
                { 'e', 1 },
                { 'i', 1 },
                { 'o', 1 },
                { 'u', 1 }
            };

            actual = "AEIOU".CountVowels();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountVowels_EmptyString_ReturnsEmptyDictionary()
        {
            Dictionary<char, int> actual;
            Dictionary<char, int> expected = new Dictionary<char, int>();

            actual = String.Empty.CountVowels();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountVowels_NullString_ReturnsEmptyDictionary()
        {
            Dictionary<char, int> actual;
            Dictionary<char, int> expected = new Dictionary<char, int>();

            actual = ((string)null).CountVowels();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountChars_CharsToCountIsNull_ThrowNullReferenceException()
        {
            TestDelegate test = () => "aeiou".CountChars((string)null);

            Assert.Throws<NullReferenceException>(test);
        }
    }
}