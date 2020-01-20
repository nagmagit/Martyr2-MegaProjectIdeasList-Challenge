using System;
using System.Collections.Generic;
using System.Text;

namespace Nagma.CountVowels
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region Ask nicely
            Console.WriteLine("Enter some text and I will tell you how many vowels it has:");
            #endregion

            #region Read user input
            string text = Console.ReadLine();
            #endregion

            #region Print results
            string results = $"Results:\n{ GetDictionaryString(text.CountVowels()) }";
            Console.WriteLine(results);
            #endregion
        }

        private static string GetDictionaryString(Dictionary<char, int> dictionary)
        {
            StringBuilder dictionaryString = new StringBuilder();

            if (dictionary.Count == 0) dictionaryString.AppendLine("There are no vowels in the text.");

            foreach (KeyValuePair<char, int> pair in dictionary)
            {
                string sIfPlural = (pair.Value != 1 ? "s" : String.Empty);

                dictionaryString.AppendLine($"\"{pair.Key}\" appears {pair.Value} time{sIfPlural}.");
            }

            return dictionaryString.ToString();
        }
    }
}
