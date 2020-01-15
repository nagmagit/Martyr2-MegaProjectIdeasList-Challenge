using System;
using System.Linq;

namespace ReverseString
{
    public static class StringReverser
    {
        public static string Reverse(string str) => String.Join("", str.Reverse());
    }
}
