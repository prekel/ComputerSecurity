using System;
using System.Numerics;

using NUnit.Framework;

namespace Lab_02.Core.Tests
{
    [TestFixture]
    public class RSATests
    {
        [Test]
        public void RsaStringTest1()
        {
            var rs = new RSADecrypter(31);
            var rc = new RSACrypter(rs.OpenKey);

            const string m = "qwerty";
            var c = rc.Crypt(m);
            var md = rs.Decrypt(c);

            Assert.AreEqual(m, md);
        }

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
            var rs = new RSADecrypter(31);
            var rc = new RSACrypter(rs.OpenKey);

            var r = new Random();
            for (var i = 0; i < 100; i++)
            {
                var m = new BigInteger(r.Next(1, 10000));
                Assert.AreEqual(m, rs.Decrypt(rc.Crypt(m)));
            }
        }
    }
}
