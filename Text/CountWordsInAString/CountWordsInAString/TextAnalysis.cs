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
            return WordLengthSummary(text, " ");
        }

        /// <summary>
        /// Splits the text with a given Regex pattern that matches the delimiter
        /// between words and returns a dictionary, where its keys are character-counts
        /// and its values are the amount of words with that character-count.
        /// </summary>
        public static Dictionary<int, int> WordLengthSummary(string text, string splitterPattern)
        {
            Regex regex = new Regex(splitterPattern);

            return WordLengthSummary(text, regex);
        }

        /// <summary>
        /// Splits the text with a given Regex pattern that matches the delimiter
        /// between words and returns a dictionary, where its keys are character-counts
        /// and its values are the amount of words with that character-count.
        /// </summary>
        public static Dictionary<int, int> WordLengthSummary(string text, Regex splitterPattern)
        {
            #region Split the string using Regex: words

            #endregion

            #region Select the string-lengths from words: lengths

            #endregion

            #region Select max value (as maxValue) from lengths and create a dictionary with keys 1 to maxValue: summary

            #endregion

            #region Iterate over lengths (as wordLength) and add 1 to the corresponding dictionary-key

            #endregion
        }
    }
}
