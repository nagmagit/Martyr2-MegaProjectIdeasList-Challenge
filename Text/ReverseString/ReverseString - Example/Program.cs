using System;

namespace Nagma.ReverseString.Example
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Input text to be reversed: ");
            string text = Console.ReadLine();

            string reversedText = StringReverser.Reverse(text);
            Console.WriteLine($"Result: {reversedText}");
        }
    }
}