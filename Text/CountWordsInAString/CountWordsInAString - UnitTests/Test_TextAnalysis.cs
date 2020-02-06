using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Nagma.CountWordsInAString.UnitTests
{
    [TestFixture]
    public class Test_TextAnalysis
    {
        private static IEnumerable<TestCaseData> Words_TestCaseSource
        {
            get
            {
                yield return new TestCaseData("Hi!", new Dictionary<int, int>() { { 1, 0 }, { 2, 0 }, { 3, 1 } });
                yield return new TestCaseData("Hello World!", new Dictionary<int, int>() { { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 1 }, { 6, 1 } });
                yield return new TestCaseData("An Ox has a big box", new Dictionary<int, int>() { { 1, 1 }, { 2, 2 }, { 3, 3 } });
                yield return new TestCaseData("A banker returned quickly back to his house", new Dictionary<int, int>() { { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 1 }, { 5, 1 }, { 6, 1 }, { 7, 1 }, { 8, 1 } });
            }
        }

        private static IEnumerable<TestCaseData> WordsWithPattern_TestCaseSource
        {
            get
            {
                string pattern = @"[^\w]+";

                yield return new TestCaseData("Hi!", pattern, new Dictionary<int, int>() { { 1, 0 }, { 2, 1 } });
                yield return new TestCaseData("Hello World!", pattern, new Dictionary<int, int>() { { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 2 } });
                yield return new TestCaseData("An Ox, has a big box?", pattern, new Dictionary<int, int>() { { 1, 1 }, { 2, 2 }, { 3, 3 } });
                yield return new TestCaseData("A banker returned (quickly) back to his house.", pattern, new Dictionary<int, int>() { { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 1 }, { 5, 1 }, { 6, 1 }, { 7, 1 }, { 8, 1 } });
            }
        }

        [Test, TestCaseSource(nameof(Words_TestCaseSource))]
        public void WordLengthSummary_Words_ReturnsExpectedResult(string text, Dictionary<int, int> expected)
        {
            Dictionary<int, int> actual = TextAnalysis.WordLengthSummary(text);

            Assert.AreEqual(expected, actual);
        }

        [Test, TestCaseSource(nameof(WordsWithPattern_TestCaseSource))]
        public void WordLengthSummary_WordsWithString_ReturnsExpectedResult(string text, string pattern, Dictionary<int, int> expected)
        {
            Dictionary<int, int> actual = TextAnalysis.WordLengthSummary(text, pattern);

            Assert.AreEqual(expected, actual);
        }

        [Test, TestCaseSource(nameof(WordsWithPattern_TestCaseSource))]
        public void WordLengthSummary_WordsWithRegex_ReturnsExpectedResult(string text, string pattern, Dictionary<int, int> expected)
        {
            Dictionary<int, int> actual = TextAnalysis.WordLengthSummary(text, new Regex(pattern));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WordLengthSummary_EmptyText_ReturnsEmptyDictionary()
        {
            string input = String.Empty;
            Dictionary<int, int> expected = new Dictionary<int, int>();

            Dictionary<int, int> actual = TextAnalysis.WordLengthSummary(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WordLengthSummary_NullText_ThrowsNullReferenceException()
        {
            string input = null;

            TestDelegate test = (() => TextAnalysis.WordLengthSummary(input));

            Assert.Throws<NullReferenceException>(test);
        }

        [Test]
        public void WordLengthSummary_NullSplitterString_ThrowsNullReferenceException()
        {
            string input = String.Empty;
            string pattern = null;

            TestDelegate test = (() => TextAnalysis.WordLengthSummary(input, pattern));

            Assert.Throws<NullReferenceException>(test);
        }

        [Test]
        public void WordLengthSummary_NullSplitterRegex_ThrowsNullReferenceException()
        {
            string input = String.Empty;
            Regex pattern = null;

            TestDelegate test = (() => TextAnalysis.WordLengthSummary(input, pattern));

            Assert.Throws<NullReferenceException>(test);
        }
    }
}