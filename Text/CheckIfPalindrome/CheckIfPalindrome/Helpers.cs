using NeoSmart.Unicode;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

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

            string reversedText = ReverseUnicode(text);

            return (reversedText == text);
        }

        private static string ReverseUnicode(string text)
        {
            List<string> lettersList = new List<string>();

            Codepoint[] codepoints = text.Codepoints().ToArray();

            for (int i = 0; i < codepoints.Length; i++)
            {
                // If this is the last codepoint in the string
                if (i + 1 >= codepoints.Length)
                {
                    lettersList.Add(codepoints[i].AsString());
                    continue;
                }

                Codepoint codepoint = codepoints[i];
                Codepoint nextCodepoint = codepoints[i+1];

                // If it's an actual emoji, add it combined
                if (TryCombinedEmoji(out SingleEmoji combinedEmoji, codepoint, nextCodepoint))
                {
                    i++;    // Skip next emoji
                    lettersList.Add(combinedEmoji.ToString());
                }
                else
                {
                    lettersList.Add(codepoint.AsString());
                }
            }

            lettersList.Reverse();

            return String.Join(String.Empty, lettersList);
        }

        private static bool TryCombinedEmoji(out SingleEmoji combinedEmoji, params Codepoint[] codepoints)
        {
            // Attemp to create a single emoji by joining them all
            combinedEmoji = new SingleEmoji(new UnicodeSequence(codepoints), String.Empty, null, -1);

            // Check if the resulting emoji actually exists
            return Emoji.All.Contains(combinedEmoji);
        }
    }
}
