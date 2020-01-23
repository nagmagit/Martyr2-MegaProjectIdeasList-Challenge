using NUnit.Framework;
using System;

namespace Nagma.CheckIfPalindrome
{
    [TestFixture]
    public class Test_ExtensionMethods
    {
        [Test]
        public void IsPalindrome_NonPalindromeNormalWord_ReturnsFalse()
        {
            string input = "aeea yo soy sabalero";

            bool actual = input.IsPalindrome();

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsPalindrome_PalindromeNormalWord_ReturnsTrue()
        {
            string input = "anitalavalatina";

            bool actual = input.IsPalindrome();

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsPalindrome_NonPalindromeWithCombinedChars_ReturnsFalse()
        {
            string input = "😎🦅";

            bool actual = input.IsPalindrome();

            Assert.IsFalse(actual);
        }

        [Test]
        public void IsPalindrome_PalindromeWithCombinedChars_ReturnsTrue()
        {
            // Depending on the IDE, it may not be noticeable that the faces
            // get increasingly paler towards the middle. This is to test
            // the compatibility with Unicode's combined characters.
            string input = "👨🏿👨🏾👨🏽👨🏼👨🏻👨👨🏻👨🏼👨🏽👨🏾👨🏿";

            bool actual = input.IsPalindrome();

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsPalindrome_EmptyString_ReturnsTrue()
        {
            string input = String.Empty;

            bool actual = input.IsPalindrome();

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsPalindrome_NullString_ThrowsNullReferenceException()
        {
            string input = null;

            TestDelegate test = (() => input.IsPalindrome());

            Assert.Throws<NullReferenceException>(test);
        }
    }
}