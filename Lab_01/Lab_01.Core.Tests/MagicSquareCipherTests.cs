using NUnit.Framework;

namespace Lab_01.Core.Tests
{
    [TestFixture]
    public class MagicSquareCipherTests
    {
        [Test]
        public void Test1()
        {
            var a = new MagicSquare("2 7 6\n9 5 1\n4 3 8");

            var c = new MagicSquareCipher(a);

            const string t = "ABCQWEZXC";
            const string ct = "BZECWAQCX";

            var ct1 = c.Crypt(t);
            Assert.AreEqual(ct, ct1);

            var t1 = c.Encrypt(ct);
            Assert.AreEqual(t, t1);
        }

        [Test]
        public void Test2()
        {
            var a = new MagicSquare("2 7 6\n9 5 1\n4 3 8");

            var c = new MagicSquareCipher(a);

            const string t = "ABCQWEZX";
            const string ct = "BZE WAQCX";

            var ct1 = c.Crypt(t);
            Assert.AreEqual(ct, ct1);

            var t1 = c.Encrypt(ct);
            Assert.AreEqual(t, t1);
        }
    }
}
