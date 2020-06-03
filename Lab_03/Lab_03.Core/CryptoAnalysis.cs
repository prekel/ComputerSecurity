using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_03.Core
{
    public class CryptoAnalysis
    {
        public CryptoAnalysis(string cipherText) => CipherText = new CipherText(cipherText);

        public CipherText CipherText { get; }

        private static int GCD(IEnumerable<int> numbers) => numbers.Aggregate(GCD);

        private static int GCD(int a, int b) =>
            // ReSharper disable once TailRecursiveCall
            b == 0 ? a : GCD(b, a % b);

        public int MuFromIndeces(IEnumerable<int> indeces)
        {
            var enumerable = indeces as int[] ?? indeces.ToArray();
            return GCD(enumerable.Skip(1).Zip(enumerable.SkipLast(1), (a, b) => a - b));
        }

        public Dictionary<string, IEnumerable<int>> Trigrams()
        {
            var res = new Dictionary<string, IEnumerable<int>>();
            for (var i = 0; i < CipherText.CipherTextOnlyLetters.Length - 3; i++)
            {
                var tri = CipherText.CipherTextOnlyLetters.Substring(i, 3);
                if (res.ContainsKey(tri))
                {
                    continue;
                }

                var list = new List<int>();
                res[tri] = list;

                var k = 0;
                while (true)
                {
                    var f = CipherText.CipherTextOnlyLetters.IndexOf(tri, k, StringComparison.Ordinal);
                    if (f == -1)
                    {
                        break;
                    }

                    list.Add(f);
                    k = f + 1;
                }
            }

            return res;
        }
    }
}
