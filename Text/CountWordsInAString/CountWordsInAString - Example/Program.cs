using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Nagma.CountWordsInAString.Example
{
    internal class Program
    {
        private static readonly int BAR_LENGTH = 60;

        private static void Main(string[] args)
        {
            #region Fields
            string input = null;
            string delimiter;
            Dictionary<int, int> summary;

            StringBuilder barGraphBuilder = new StringBuilder();
            #endregion

            #region Read the input file (if it has been passed) or ask for text
            if (args.Length == 1 && File.Exists(args[0]))
            {
                #region Read the input file
                input = ReadFromFile(args[0]);
                delimiter = @"(?:[^\w]|\r?\n)+";
                #endregion
            }
            else
            {
                #region Ask the user to enter some text
                input = AskUser();
                delimiter = @"[^\w]+";
                #endregion
            }
            #endregion

            #region Feed the text to WordLengthSummary
            summary = TextAnalysis.WordLengthSummary(input, delimiter);
            #endregion

            #region Create a bar graph showing the results
            // Format: "{length} - {words} ********"
            // Format example: 50 - 12 **********

            if (summary.Count > 0)
            {
                #region Take the maximum length and map it to BAR_LENGTH
                float maximumLength = summary.Values.Max();
                float barSizeCoefficient = BAR_LENGTH / maximumLength;
                #endregion

                #region For each length, add it as a percentile of the maximum length
                foreach (KeyValuePair<int, int> pair in summary)
                {
                    #region Add length and the count of words
                    barGraphBuilder.Append($"{pair.Key} - {pair.Value} ");
                    #endregion

                    #region Add *s
                    int barLength = (int)(pair.Value * barSizeCoefficient);
                    IEnumerable<string> bar = Enumerable.Repeat("*", barLength);

                    barGraphBuilder.AppendJoin(String.Empty, bar);
                    #endregion

                    barGraphBuilder.AppendLine();
                }
                #endregion

            }
            else
            {
                barGraphBuilder.AppendLine("No words found");
            }
            #endregion

            #region Display the results
            Console.WriteLine();    // Empty line to separate from the input
            Console.WriteLine("Summary:");
            Console.WriteLine(barGraphBuilder.ToString());
            #endregion

            #region Pause to read
            Console.Read();
            #endregion
        }

        private static string ReadFromFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        private static string AskUser()
        {
            string input = null;

            while (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input a text and hit enter to see the results: ");

                input = Console.ReadLine();
            }

            return input;
        }
    }
}
