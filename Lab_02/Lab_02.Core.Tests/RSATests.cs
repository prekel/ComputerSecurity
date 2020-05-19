using System.Numerics;

using NUnit.Framework;

namespace Lab_02.Core.Tests
{
    [TestFixture]
    public class RSATests
    {
        [Test]
        public void RSATest1()
        {
            // var rsa = new AbstractRSA();
            //
            // rsa.P = 7;
            // rsa.Q = 13;
            // rsa.N = rsa.P * rsa.Q;
            // rsa.d = rsa.fi();
            // rsa.S = 11;
            // rsa.E = 59;
            //
            // var m1 = 8;
            // var m2 = 27;
            // var m3 = 5;
            //
            // var c1 = BigInteger.ModPow(m1, rsa.S, rsa.N);
            // var c2 = BigInteger.ModPow(m2, rsa.S, rsa.N);
            // var c3 = BigInteger.ModPow(m3, rsa.S, rsa.N);
            //
            // Assert.AreEqual(c1, new BigInteger(57));
            // Assert.AreEqual(c2, new BigInteger(27));
            // Assert.AreEqual(c3, new BigInteger(73));
            //
            // var m1d = BigInteger.ModPow(c1, rsa.E, rsa.N);
            // var m2d = BigInteger.ModPow(c2, rsa.E, rsa.N);
            // var m3d = BigInteger.ModPow(c3, rsa.E, rsa.N);
            //
            // Assert.AreEqual(m1d, new BigInteger(m1));
            // Assert.AreEqual(m2d, new BigInteger(m2));
            // Assert.AreEqual(m3d, new BigInteger(m3));
        }

        [Test]
        public void RSATest2()
        {
            var rs = new RSAServer(31);
            var rc = new RSAClient(rs.OpenKey);

            var m1 = new BigInteger(8);
            var m2 = new BigInteger(27);
            var m3 = new BigInteger(5);
            var c1 = rc.Crypt(m1);
            var c2 = rc.Crypt(m2);
            var c3 = rc.Crypt(m3);
            var m1d = rs.Decrypt(c1);
            var m2d = rs.Decrypt(c2);
            var m3d = rs.Decrypt(c3);
        }
    }
}
