using NUnit.Framework;

namespace Nagma.Text.UnitTests
{
    internal class TestToPigLatin
    {
        [Test]
        public void TestGroundTruth()
        {
            string expected = "igpay atinlay";
            string actual = "Pig latin".ToPigLatin();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestNoSpaces()
        {
            string expected = "igpay1atinlay";
            string actual = "Pig1latin".ToPigLatin();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestNoLetters()
        {
            string expected = "123456789";
            string actual = "123456789".ToPigLatin();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestNull()
        {
            string actual = ((string)null).ToPigLatin();

            Assert.IsNull(actual);
        }

        [Test]
        public void TestEmpty()
        {
            string actual = string.Empty.ToPigLatin();

            Assert.IsEmpty(actual);
        }
    }
}
