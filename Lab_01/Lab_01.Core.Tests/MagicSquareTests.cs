using NUnit.Framework;

namespace Lab_01.Core.Tests
{
    [TestFixture]
    public class MagicSquareTests
    {
        [Test]
        public void RotateToStringTest()
        {
            var a = new MagicSquare("2 7 6\n9 5 1\n4 3 8");
            var b = new MagicSquare("2 7 6\n9 5 1\n4 3 8");

            b.Rotate();
            b.Rotate();
            b.Rotate();
            b.Rotate();

            Assert.AreEqual(a.ToString(), b.ToString());
        }

        [Test]
        public void Test1()
        {
            var a = new MagicSquare(3);

            Assert.AreEqual(true, a.IsMagicSum);
            Assert.AreEqual(false, a.IsDistinct);
            Assert.AreEqual(false, a.IsMagic);

            a[0, 0] = 2;
            a[0, 1] = 7;
            a[0, 2] = 6;
            a[1, 0] = 9;
            a[1, 1] = 5;
            a[1, 2] = 1;
            a[2, 0] = 4;
            a[2, 1] = 3;
            a[2, 2] = 8;

            Assert.AreEqual(true, a.IsMagicSum);
            Assert.AreEqual(true, a.IsDistinct);
            Assert.AreEqual(true, a.IsMagic);

            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            var a = new MagicSquare("2 7 6\n9 5 1\n4 3 8");
            Assert.AreEqual(2, a[0, 0]);
            Assert.AreEqual(7, a[0, 1]);
            Assert.AreEqual(6, a[0, 2]);
            Assert.AreEqual(9, a[1, 0]);
            Assert.AreEqual(5, a[1, 1]);
            Assert.AreEqual(1, a[1, 2]);
            Assert.AreEqual(4, a[2, 0]);
            Assert.AreEqual(3, a[2, 1]);
            Assert.AreEqual(8, a[2, 2]);
        }
    }
}
