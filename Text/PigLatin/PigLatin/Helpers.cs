using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Nagma.Text
{
    public static class Helpers // Make ToPigLatin an extension method for strings
    {
        /// <summary>
        /// Convert the words in a string to pig latin and returns the result in lowercase.
        /// </summary>
        /// <returns>String, with its words converted to pig latin, in lowercase.</returns>
        public static string ToPigLatin(this string text)
        {
            #region Fields
            StringBuilder outputBuilder = new StringBuilder();
            Regex regex;
            MatchCollection matches;
            #endregion

            #region Handle null-empty case
            // If null or empty, return text
            if (String.IsNullOrEmpty(text)) return text;
            #endregion

            #region Match all the "PigLatin-able" words (sequences of letters)
            // Use regex to only match letters
            regex = new Regex("[a-zA-Z]+");
            matches = regex.Matches(text);

            // If no matches, return original text
            if (matches.Count == 0) return text;
            #endregion

            #region Normalize text
            text = text.ToLowerInvariant();
            #endregion

            #region Generate output
            #region Add preceding text
            outputBuilder.Append(text.Substring(0, matches[0].Index));
            #endregion

            #region Convert matches to PigLatin and replace them in the string
            foreach (Match match in matches)
            {
                // Convert to PigLatin
                string pigLatinnedMatch = PigLatin.WordToPigLatin(match.Value);

                // Append pigLatinnedMatch
                outputBuilder.Append(pigLatinnedMatch);

                Match next = match.NextMatch();
                // If there's a next match...
                if (next.Success)
                {
                    // ...append the text between this match and the next
                    int textIndex = match.Index + match.Length;
                    int textLength = next.Index - textIndex;

                    outputBuilder.Append(text.Substring(textIndex, textLength));
                }
            }
            #endregion

            #region Add succeeding text
            Match lastMatch = matches[matches.Count - 1];
            int succeedingTextIndex = lastMatch.Index + lastMatch.Length;
            int succeedingTextLength = text.Length - succeedingTextIndex;

            if (succeedingTextIndex >= text.Length) outputBuilder.Append(text.Substring(succeedingTextIndex, succeedingTextLength));
            #endregion
            #endregion

            return outputBuilder.ToString();
        }
    }
}
