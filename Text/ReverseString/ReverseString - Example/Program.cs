using System;

namespace ReverseString.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input text to be reversed: ");
            string text = Console.ReadLine();

            string reversedText = StringReverser.Reverse(text);
            Console.WriteLine($"Result: {reversedText}");

            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }
    }
}
