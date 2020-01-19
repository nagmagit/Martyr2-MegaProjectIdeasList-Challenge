using System;
using System.Collections.Generic;
using System.Linq;

namespace Nagma.CountVowels
{
    public static class Helpers
    {
        /// <summary>
        /// Returns a dictionary with the amount of times that each vowel appears.
        /// </summary>
        public static Dictionary<char, int> CountVowels(this string str)
        {
            return str.ToLower().CountChars("aeiou");
        }

        /// <summary>
        /// Returns a dictionary with the amount of times that each character from the array appears.
        /// </summary>
        public static Dictionary<char, int> CountChars(this string str, char[] charsToCount)
        {
            if (charsToCount is null) return new Dictionary<char, int>();

            return str.CountChars(String.Join(String.Empty, charsToCount));
        }

        /// <summary>
        /// Returns a dictionary with the amount of times that each character from the string appears.
        /// </summary>
        public static Dictionary<char, int> CountChars(this string str, string charsToCount)
        {
            if (charsToCount is null) return new Dictionary<char, int>();

            return (Dictionary<char, int>)str.CountChars().Where(pair => charsToCount.Contains(pair.Key));
        }

        /// <summary>
        /// Returns a dictionary with the amount of times that each character on it appears.
        /// </summary>
        public static Dictionary<char, int> CountChars(this string str)
        {
            throw new NotImplementedException();
        }
    }
}
