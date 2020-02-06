using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Nagma.CountWordsInAString
{
    /// <summary>
    /// Contains methods to analyze text strings.
    /// </summary>
    public static class TextAnalysis
    {
        /// <summary>
        /// Splits the text with spaces and returns a dictionary, where its keys are character-counts
        /// and its values are the amount of words with that character-count.
        /// </summary>
        public static Dictionary<int, int> WordLengthSummary(string text)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Splits the text with a given Regex pattern that matches the delimeter
        /// between words and returns a dictionary, where its keys are character-counts
        /// and its values are the amount of words with that character-count.
        /// </summary>
        public static Dictionary<int, int> WordLengthSummary(string text, string splitterPattern)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Splits the text with a given Regex pattern that matches the delimeter
        /// between words and returns a dictionary, where its keys are character-counts
        /// and its values are the amount of words with that character-count.
        /// </summary>
        public static Dictionary<int, int> WordLengthSummary(string text, Regex splitterPattern)
        {
            throw new NotImplementedException();
        }
    }
}
