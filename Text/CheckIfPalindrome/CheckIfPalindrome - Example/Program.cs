using System;

namespace Nagma.CheckIfPalindrome
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region Ask nicely
            Console.Write("Enter a word I will tell you if it's palindrome: ");
            #endregion

            #region Read user input
            string text = Console.ReadLine();
            #endregion

            #region Evaluate result
            string isOrIsNot = text.IsPalindrome() ? "IS" : "IS NOT";
            #endregion

            #region Print results
            string results = $"\"{text}\" {isOrIsNot} palindrome.";

            Console.WriteLine(results);
            #endregion
        }
    }
}
