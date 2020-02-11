using System;
using System.Collections.Generic;
using System.Linq;
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
            if (splitterPattern is null) throw new NullReferenceException("Value cannot be null. (Parameter 'splitterPattern')");

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
            #region Handle edge cases
            if (text is null) throw new NullReferenceException("Value cannot be null. (Parameter 'text')");
            if (splitterPattern is null) throw new NullReferenceException("Value cannot be null. (Parameter 'splitterPattern')");
            #endregion

            #region Split the string using Regex: words
            string[] words = splitterPattern.Split(text);
            #endregion

            #region Select the string-lengths from words: lengths
            int[] lengths = words
                .Select(word => word.Length)
                .Where(length => length > 0)
                .ToArray();
            #endregion

            #region Handle edge cases
            // If there are no lengths in the array (either because it was an empty string or
            // it only contained delimiters) return an empty dictionary.
            if (lengths.Length == 0) return new Dictionary<int, int>();
            #endregion

            #region Select max value (as maxValue) from lengths and create a dictionary with keys 1 to maxValue: summary
            int maxValue = lengths.Max();

            Dictionary<int, int> summary = new Dictionary<int, int>();

            foreach (int number in Enumerable.Range(1, maxValue))
            {
                summary.Add(number, 0);
            }
            #endregion

            #region Iterate over lengths (as length) and add 1 to the corresponding dictionary-key
            foreach (int length in lengths)
            {
                summary[length]++;
            }
            #endregion
            
            return summary;
        }
    }
}
