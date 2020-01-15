using System;
using Nagma;

namespace Nagma.PigLatin.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("NOTE - This translator follows the rules from the following Wikipedia article:");
            Console.WriteLine("https://en.wikipedia.org/w/index.php?title=Pig_Latin&oldid=930806418#Rules \n");
            
            Console.Write("Input the text to be converted into pig latin: ");

            string text = Console.ReadLine();
            string result = text.ToPigLatin();

            Console.WriteLine("Result: {0}", result);

            //WaitForKeyToExit(true);
        }

        private static void WaitForKeyToExit(bool showPressKeyMsg)
        {
            if (showPressKeyMsg) Console.WriteLine("Press any key to exit...");

            Console.Read();

            Environment.Exit(0);
        }
    }
}
