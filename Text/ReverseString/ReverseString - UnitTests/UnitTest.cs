using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using static ReverseString.UnitTests.Helpers;

namespace ReverseString.UnitTests
{
    [TestClass]
    public class UnitTest
    {
        readonly string[] GROUNDTRUTH_SAMPLES  = { "onlylower", "ONLYUPPER", "UPPERAndlower", "123456", "lowerand123456", "UPPERAND123456", "UPPERlowerand123456", "\"·$%&/()=", "lowerand!\"·$%&/()=", "UPPERAND\"·$%&/()=", "UPPERlowerAnd\"·$%&/()=", "lower123456and\"·$%&/()=", "UPPER123456AND\"·$%&/()=", "UPPERlower123456And\"·$%&/()=" };
        readonly string[] GROUNDTRUTH_EXPECTED = { "rewolylno", "REPPUYLNO", "rewoldnAREPPU", "654321", "654321dnarewol", "654321DNAREPPU", "654321dnarewolREPPU", "=)(/&%$·\"", "=)(/&%$·\"!dnarewol", "=)(/&%$·\"DNAREPPU", "=)(/&%$·\"dnArewolREPPU", "=)(/&%$·\"dna654321rewol", "=)(/&%$·\"DNA654321REPPU", "=)(/&%$·\"dnA654321rewolREPPU" };
        readonly int RANDOMTESTS_STRINGLENGTH = 20;
        readonly int RANDOMTESTS_COUNT = 20;

        [TestMethod]
        public void TestGroundTruth()
        {
            for (int i = 0; i < GROUNDTRUTH_SAMPLES.Length; i++)
            {
                string str = GROUNDTRUTH_SAMPLES[i];
                string expected = GROUNDTRUTH_EXPECTED[i];

                string result = StringReverser.Reverse(str);

                Assert.AreEqual(expected, result, $"Ground truth test failed on sample \"{str}\".");
            }
        }

        [TestMethod]
        public void TestRandomStrings()
        {
            for (int i = 0; i < RANDOMTESTS_COUNT; i++)
            {
                string str = RandomString(RANDOMTESTS_STRINGLENGTH);
                string expected = String.Join("", str.Reverse());

                string result = StringReverser.Reverse(str);

                Assert.AreEqual(expected, result, $"Random test failed with string \"{str}\".");
            }
        }
    }
}
