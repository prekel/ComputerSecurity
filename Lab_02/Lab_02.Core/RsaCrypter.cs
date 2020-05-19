using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Lab_02.Core
{
    public class RsaCrypter : AbstractRsa
    {
        public RsaCrypter(RSAOpenKey openkey)
        {
            OpenKey.N = openkey.N;
            OpenKey.S = openkey.S;
        }

        public BigInteger Crypt(BigInteger m) => BigInteger.ModPow(m, OpenKey.S, OpenKey.N);

        public IEnumerable<BigInteger> Crypt(string a)
        {
            return a.Select(i => Crypt(i));
        }
    }
}
