using System;
using System.Linq;

namespace Nagma.ReverseString
{
    public static class StringReverser
    {
        public static string Reverse(string str) => String.Join(String.Empty, str.Reverse());
    }
}