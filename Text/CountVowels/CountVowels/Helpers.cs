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
            if (str is null)
            {
                return new Dictionary<char, int>();
            }

            return str.ToLower().CountChars("aeiou");
        }

        /// <summary>
        /// Returns a dictionary with the amount of times that each character from the array appears.
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        public static Dictionary<char, int> CountChars(this string str, char[] charsToCount)
        {
            if (charsToCount is null)
            {
                throw new NullReferenceException("The array \"charsToCount\" can't be null.");
            }

            return str.CountChars(String.Join(String.Empty, charsToCount));
        }

        /// <summary>
        /// Returns a dictionary with the amount of times that each character from the string appears.
        /// </summary>
        public static Dictionary<char, int> CountChars(this string str, string charsToCount)
        {
            if (charsToCount is null)
            {
                throw new NullReferenceException("The string \"charsToCount\" can't be null.");
            }

            return str.CountChars()
                .Where(pair => charsToCount.Contains(pair.Key))
                .ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        /// <summary>
        /// Returns a dictionary with the amount of times that each character on it appears.
        /// </summary>
        public static Dictionary<char, int> CountChars(this string str)
        {
            Dictionary<char, int> charsCounted = new Dictionary<char, int>();

            if (!String.IsNullOrEmpty(str))
            {
                foreach (char ch in str)
                {
                    if (!charsCounted.ContainsKey(ch))
                    {
                        charsCounted.Add(ch, 0);
                    }

                    charsCounted[ch]++;
                }
            }

            return charsCounted;
        }
    }
}
