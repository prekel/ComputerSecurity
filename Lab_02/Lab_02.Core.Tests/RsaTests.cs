using System;
using System.Numerics;

using NUnit.Framework;

namespace Lab_02.Core.Tests
{
    [TestFixture]
    public class RsaTests
    {
        [Test]
        public void RsaStringTest1()
        {
            var rs = new RsaDecrypter(31);
            var rc = new RsaCrypter(rs.OpenKey);

            const string m = "qwerty";
            var c = rc.Crypt(m);
            var md = rs.Decrypt(c);

            Assert.AreEqual(m, md);
        }

        [Test]
        public void RsaTest2()
        {
            var rs = new RsaDecrypter(31);
            var rc = new RsaCrypter(rs.OpenKey);

            var r = new Random();
            for (var i = 0; i < 100; i++)
            {
                var m = new BigInteger(r.Next(1, 10000));
                Assert.AreEqual(m, rs.Decrypt(rc.Crypt(m)));
            }
        }
    }
}
