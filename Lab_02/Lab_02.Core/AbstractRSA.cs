using System.Numerics;

namespace Lab_02.Core
{
    public abstract class AbstractRSA
    {
        public RSAOpenKey OpenKey { get; } = new RSAOpenKey();

        public class RSAOpenKey
        {
            public BigInteger S { get; internal set; }
            public BigInteger N { get; internal set; }
        }
    }
}
