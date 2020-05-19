using System.Numerics;

namespace Lab_02.Core
{
    public class RSAClient : AbstractRSA
    {
        public RSAClient(RSAOpenKey openkey) => OpenKey = openkey;

        public BigInteger Crypt(BigInteger m) => BigInteger.ModPow(m, OpenKey.S, OpenKey.N);
    }
}
