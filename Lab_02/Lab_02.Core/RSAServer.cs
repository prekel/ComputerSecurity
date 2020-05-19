using System.Numerics;
using System.Security.Cryptography;

namespace Lab_02.Core
{
    public class RSAServer : AbstractRSA
    {
        public RSAServer(int nLength)
        {
            var p = RandomPrimeBigInt(nLength / 2);
            var q = RandomPrimeBigInt(nLength - nLength / 2);
            OpenKey.N = p * q;
            var d = (p - 1) * (q - 1);
            OpenKey.S = CoprimeLessBigInt(d);
            E = E2(OpenKey.S, d);
        }

        public BigInteger E { get; set; }

        private RandomNumberGenerator Random { get; } = RandomNumberGenerator.Create();

        private bool IsProbablePrime(BigInteger source, int certainty)
        {
            if (source == 2 || source == 3)
            {
                return true;
            }

            if (source < 2 || source % 2 == 0)
            {
                return false;
            }

            var d = source - 1;
            var s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            var bytes = new byte[source.ToByteArray().LongLength];
            BigInteger a;

            for (var i = 0; i < certainty; i++)
            {
                do
                {
                    Random.GetBytes(bytes);
                    a = new BigInteger(bytes);
                } while (a < 2 || a >= source - 2);

                var x = BigInteger.ModPow(a, d, source);
                if (x == 1 || x == source - 1)
                {
                    continue;
                }

                for (var r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, source);
                    if (x == 1)
                    {
                        return false;
                    }

                    if (x == source - 1)
                    {
                        break;
                    }
                }

                if (x != source - 1)
                {
                    return false;
                }
            }

            return true;
        }

        private BigInteger RandomBigInt(int length) =>
            RandomBigInt(BigInteger.Pow(new BigInteger(10), length - 1),
                BigInteger.Pow(new BigInteger(10), length));

        private BigInteger RandomBigInt(BigInteger min, BigInteger max)
        {
            var bytes = max.ToByteArray();
            while (true)
            {
                Random.GetBytes(bytes);
                bytes[^1] &= 0x7F;
                var randomBigInt = new BigInteger(bytes);

                if (min <= randomBigInt && randomBigInt < max)
                {
                    return randomBigInt;
                }
            }
        }

        private BigInteger RandomPrimeBigInt(int length)
        {
            while (true)
            {
                var r = RandomBigInt(length);
                if (IsProbablePrime(r, length * 3))
                {
                    return r;
                }
            }
        }

        private BigInteger CoprimeLessBigInt(BigInteger d)
        {
            while (true)
            {
                var r = RandomBigInt(0, d);
                if (BigInteger.GreatestCommonDivisor(r, d) == 1)
                {
                    return r;
                }
            }
        }

        public static BigInteger gcd(BigInteger a, BigInteger b, ref BigInteger x, ref BigInteger y)
        {
            if (a == 0)
            {
                x = 0;
                y = 1;
                return b;
            }

            BigInteger x1, y1;
            var d = gcd(b % a, a, ref x1, ref y1);
            x = y1 - b / a * x1;
            y = x1;
            return d;
        }

        private BigInteger E2(BigInteger s, BigInteger d)
        {
            while (true)
            {
                var r = RandomBigInt(0, d);

                BigInteger x1, y1;
                var b = gcd(r * s, d, ref x1, ref y1);
                if (b == 1)
                {
                    return r;
                }
            }
        }

        public BigInteger Decrypt(BigInteger s) => BigInteger.ModPow(s, E, OpenKey.N);
    }
}
