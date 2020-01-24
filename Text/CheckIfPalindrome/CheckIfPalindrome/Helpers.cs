using System;
using System.Linq;

namespace Nagma.CheckIfPalindrome
{
    public static class Helpers
    {
        /// <summary>
        /// Checks if a string is palindrome; that is, if the string reads
        /// the same in reverse.
        /// </summary>
        /// <param name="text">The string to check.</param>
        /// <exception cref="NullReferenceException"></exception>
        public static bool IsPalindrome(this string text)
        {
            if (text is null) throw new NullReferenceException("Input string can't be null.");

            string reversedText = String.Join(String.Empty, text.Reverse());

            return (reversedText == text);
        }
    }
}
