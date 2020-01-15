using System;
using System.Text;
using NUnit.Framework;
using Nagma.PigLatin;

namespace Nagma.PigLatin.UnitTests
{
    [TestFixture]
    [Description("Tests for the method \"Nagma.PigLatin.PigLatin.WordToPigLatin\"")]
    public class TestWordToPigLatin
    {
        readonly string[] GroundTruth_Samples = { "pig", "latin", "banana", "happy", "duck", "me", "too", "bagel", "smile", "string", "stupid", "glove", "trash", "floor", "store", "eat", "omelet", "are", "explain", "always", "ends", "honest", "I" };
        readonly string[] GroundTruth_Expected = { "igpay", "atinlay", "ananabay", "appyhay", "uckday", "emay", "ootay", "agelbay", "ilesmay", "ingstray", "upidstay", "oveglay", "ashtray", "oorflay", "orestay", "eatyay", "omeletyay", "areyay", "explainyay", "alwaysyay", "endsyay", "onesthay", "iyay" };

        readonly int HugeValidStrings_StringLength = 10000000;

        [Test]
        public void TestGroundTruth()
        {
            string actual, expected;

            for (int i = 0; i < GroundTruth_Samples.Length; i++)
            {
                actual = PigLatin.WordToPigLatin(GroundTruth_Samples[i]);
                expected = GroundTruth_Expected[i];

                Assert.AreEqual(expected, actual);
            }
        }

        [Test]
        public void TestHugeValidStrings()
        {
            StringBuilder sampleBuilder = new StringBuilder();
            StringBuilder expectedBuilder = new StringBuilder();

            sampleBuilder.Append("P");

            for (int i = 0; i < HugeValidStrings_StringLength-1; i++)
            {
                sampleBuilder.Append("A");
                expectedBuilder.Append("a");
            }

            expectedBuilder.Append("pay");

            string actual = PigLatin.WordToPigLatin(sampleBuilder.ToString());
            string expected = expectedBuilder.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestNull()
        {
            string actual = PigLatin.WordToPigLatin(null);

            Assert.IsNull(actual);
        }

        [Test]
        public void TestEmpty()
        {
            string actual = PigLatin.WordToPigLatin(string.Empty);

            Assert.IsEmpty(actual);
        }

        [Test]
        public void TestWordsWithOnlyNonLetters()
        {
            string sample = "//**//**--++--++..--..--,,çç,,çç´´++´´++``¡¡``¡¡¿¿''¿¿''??==??==))(())((&&%%&&$$··$$··\"\"\"\"!!||@@||@@##¬¬##¬¬ººªªººªª[[]][[]]{{}}{{}}<<>><<>>";

            Assert.Throws(typeof(ArgumentException), () => 
            {
                PigLatin.WordToPigLatin(sample);
            }, "If the string contains any non letter characters it MUST throw an ArgumentException");
        }

        [Test]
        public void TestWordsWithLettersAndNonLetters()
        {
            string[] samples = {
                "da//**//**--++--++..--..--,,çç,,çç´´++´´++``¡¡``¡¡¿¿''¿¿''??==??==))(())((&&%%&&$$··$$··\"\"\"\"!!||@@||@@##¬¬##¬¬ººªªººªª[[]][[]]{{}}{{}}<<>><<>>",
                "ad//**//**--++--++..--..--,,çç,,çç´´++´´++``¡¡``¡¡¿¿''¿¿''??==??==))(())((&&%%&&$$··$$··\"\"\"\"!!||@@||@@##¬¬##¬¬ººªªººªª[[]][[]]{{}}{{}}<<>><<>>",
                "a/a/a*a*a/a/a*a*a-a-a+a+a-a-a+a+a.a.a-a-a.a.a-a-a,a,açaça,a,açaça´a´a+a+a´a´a+a+a`a`a¡a¡a`a`a¡a¡a¿a¿a'a'a¿a¿a'a'a?a?a=a=a?a?a=a=a)a)a(a(a)a)a((a&&a%a%a&a&a$a$a·a·a$a$a·a·a\"a\"a\"a\"a!a!a|a|a@a@a|a|a@a@a#a#a¬a¬#a#a¬a¬aºaºaªaªaºaºaªaªa[a[a]a]a[a[a]a]a{a{a}a}a{a{a}a}a<a<a>a>a<a<a>a>a",
                "ad/ad/ad*ad*ad/ad/ad*ad*ad-ad-ad+ad+ad-ad-ad+ad+ad.ad.ad-ad-ad.ad.ad-ad-ad,ad,adçadçad,ad,adçadçad´ad´ad+ad+ad´ad´ad+ad+ad`ad`ad¡ad¡ad`ad`ad¡ad¡ad¿ad¿ad'ad'ad¿ad¿ad'ad'ad?ad?ad=ad=ad?ad?ad=ad=ad)ad)ad(ad(ad)ad)ad((ad&&ad%ad%ad&ad&ad$ad$ad·ad·ad$ad$ad·ad·ad\"ad\"ad\"ad\"ad!ad!ad|ad|ad@ad@ad|ad|ad@ad@ad#ad#ad¬ad¬#ad#ad¬ad¬adºadºadªadªadºadºadªadªad[ad[ad]ad]ad[ad[ad]ad]ad{ad{ad}ad}ad{ad{ad}ad}ad<ad<ad>ad>ad<ad<ad>ad>ad",
                "da/da/da*da*da/da/da*da*da-da-da+da+da-da-da+da+da.da.da-da-da.da.da-da-da,da,daçdaçda,da,daçdaçda´da´da+da+da´da´da+da+da`da`da¡da¡da`da`da¡da¡da¿da¿da'da'da¿da¿da'da'da?da?da=da=da?da?da=da=da)da)da(da(da)da)da((da&&da%da%da&da&da$da$da·da·da$da$da·da·da\"da\"da\"da\"da!da!da|da|da@da@da|da|da@da@da#da#dda¬dda¬#dda#dda¬dda¬ddaºddaºddaªddaªddaºddaºddaªddaªdda[dda[dda]dda]dda[dda[dda]dda]dda{dda{dda}dda}dda{dda{dda}dda}dda<dda<dda>dda>dda<dda<dda>dda>dda"
            };

            foreach (string sample in samples)
            {
                Assert.Throws(typeof(ArgumentException), () =>
                {
                    PigLatin.WordToPigLatin(sample);
                }, "If the string contains any non letter characters it MUST throw an ArgumentException");
            }
        }
    }
}