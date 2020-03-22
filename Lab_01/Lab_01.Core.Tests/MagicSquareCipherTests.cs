using NUnit.Framework;

namespace Lab_01.Core.Tests
{
    public class MagicSquareCipherTests
    {
        [Test] 
        public void Test1()
        {
            var a = new MagicSquare("2 7 6\n9 5 1\n4 3 8");
            Assert.AreEqual(2, a[0,0]);
            Assert.AreEqual(7, a[0,1]);
            Assert.AreEqual(6, a[0,2]);
            Assert.AreEqual(9, a[1,0]);
            Assert.AreEqual(5, a[1,1]);
            Assert.AreEqual(1, a[1,2]);
            Assert.AreEqual(4, a[2,0]);
            Assert.AreEqual(3, a[2,1]);
            Assert.AreEqual(8, a[2,2]);
            
            
            var c = new MagicSquareCipher(a);
            
            var ct = c.Crypt("ABCQWEZXC");

            var t = c.Encrypt("ABCQWEZXC");
            
            var t1 = c.Encrypt("BZECWAQCX");
            
            Assert.Pass();
        }
    }
}
