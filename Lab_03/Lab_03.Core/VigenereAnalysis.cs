using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Lab_03.Core
{
    public class VigenereAnalysis
    {
        public VigenereAnalysis(string cipherText) => VigenereDecrypter = new VigenereDecrypter(cipherText);

        public VigenereDecrypter VigenereDecrypter { get; }

        public int Mu { get; private set; }

        public void SuggestMu(int mu)
        {
            Mu = mu;
            VigenereDecrypter.Key = new string('А', mu);
        }

        public void SuggestMostOccuring(int index, char letter)
        {
            var most = Enumerable.Range(0, VigenereDecrypter.CipherTextOnlyLetters.Length / Mu)
                .Select(i => VigenereDecrypter.CipherTextOnlyLetters.Substring(i * Mu, Mu))
                .Select(i => i[index])
                .Aggregate(new Dictionary<char, int>(),
                    (charcouner, c) =>
                    {
                        charcouner[c] = charcouner.ContainsKey(c) ? charcouner[c] + 1 : 1;
                        return charcouner;
                    })
                .OrderByDescending(pair => pair.Value)
                .First()
                .Key;

            var keychar = VigenereDecrypter.Decrypt(most, letter);

            VigenereDecrypter.Key =
                new string(VigenereDecrypter.Key.Select((c, i) => i == index ? keychar : c).ToArray());
        }

        private static int GCD(IEnumerable<int> numbers) => numbers.Aggregate(GCD);

        private static int GCD(int a, int b) =>
            // ReSharper disable once TailRecursiveCall
            b == 0 ? a : GCD(b, a % b);

        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public static int MuFromIndeces(IEnumerable<int> indeces) =>
            GCD(indeces.Skip(1).Zip(indeces.SkipLast(1), (a, b) => a - b));

        public Dictionary<string, IEnumerable<int>> Subgrams(int length)
        {
            var res = new Dictionary<string, IEnumerable<int>>();
            for (var i = 0; i < VigenereDecrypter.CipherTextOnlyLetters.Length - length; i++)
            {
                var tri = VigenereDecrypter.CipherTextOnlyLetters.Substring(i, length);
                if (res.ContainsKey(tri))
                {
                    continue;
                }

                var list = new List<int>();
                res[tri] = list;

                var k = 0;
                while (true)
                {
                    var f = VigenereDecrypter.CipherTextOnlyLetters.IndexOf(tri, k, StringComparison.Ordinal);
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

        public IEnumerable<int> PossibleMus() =>
            Enumerable.Range(2, 8)
                .GroupJoin(Subgrams(3)
                    .Where(pair => pair.Value.Count() >= 2)
                    .Select(pair => MuFromIndeces(pair.Value)), i => i, j => j, (i, ints) => (i, ints.Count()))
                .OrderByDescending(i => i.Item2)
                .Select(i => i.i);
    }
}
