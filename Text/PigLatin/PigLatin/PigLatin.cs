using System;
using System.Text.RegularExpressions;

namespace Nagma.PigLatin
{
    public static class PigLatin
    {
        /// <summary>
        /// Converts a letter-only word to pig latin.
        /// Throws an ArgumentException if the input word contains any non letter character <c>[a-zA-Z]</c>.
        /// </summary>
        /// <returns>String converted to pig latin in lowercase.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string WordToPigLatin(string word)
        {
            #region Fields
            Regex regex;
            Match match;
            #endregion

            #region Check for null or empty
            if (String.IsNullOrEmpty(word)) return word;
            #endregion

            #region Lowercase the word parameter
            word = word.ToLowerInvariant();
            #endregion

            #region Check for illegal character
            regex = new Regex("[^a-z]");    // Match any non letter
            match = regex.Match(word);
            if (match.Success) throw new ArgumentException($"Argument \"word\" contains the non letter character: \"{match.Value}\".");
            #endregion

            #region If it starts with a vowel
            regex = new Regex("^[aeiou]");
            if (regex.IsMatch(word)) return word + "yay";
            #endregion

            #region If it starts with consonants
            regex = new Regex("^([^aeiou]+)([aeiou].*)$");
            if (regex.IsMatch(word)) return regex.Replace(word, "$2$1ay");
            #endregion

            // If it didn't return yet, either the word contained only consonants or some other shannanigan
            // In any case, it's not our bussiness. Return the word (in lowercase).
            return word;
        }
    }
}
