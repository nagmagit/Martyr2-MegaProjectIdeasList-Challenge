using System;
using System.Text;

namespace Nagma.ReverseString.UnitTests
{
    public static class Helpers
    {
        public static string RandomString(int length)
        {
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                char randomChar = (char)random.Next(32, 126);
                stringBuilder.Append(randomChar);
            }

            return stringBuilder.ToString();
        }
    }
}
