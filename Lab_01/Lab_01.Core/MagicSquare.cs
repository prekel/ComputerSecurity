using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab_01.Core
{
    public class MagicSquare : IEnumerable<int>
    {
        private readonly int[,] _data;

        public MagicSquare(int n)
        {
            Count = n;
            _data = new int[n, n];
        }

        public MagicSquare(string s)
        {
            var rows = s.Trim('\n').Split('\n');
            Count = rows.Length;
            _data = new int[Count, Count];
            for (var i = 0; i < Count; i++)
            {
                var col = rows[i].Split();
                for (var j = 0; j < Count; j++)
                {
                    this[i, j] = Int32.Parse(col[j]);
                }
            }
        }

        public int Count { get; }

        public int this[int i, int j]
        {
            get => _data[i, j];
            set => _data[i, j] = value;
        }

        public bool IsMagic => IsMagicSum && IsDistinct;

        public bool IsMagicSum =>
            Enumerable.Range(0, Count - 1)
                .Select(SumRow)
                .Concat(Enumerable.Range(0, Count - 1)
                    .Select(SumColumn))
                .Append(SumMainDiagonal())
                .Append(SumAntiDiagonal())
                .Distinct()
                .Count()
                .Equals(1);

        public bool IsDistinct =>
            this.OrderBy(p => p)
                .SequenceEqual(Enumerable.Range(1, Count * Count));

        public IEnumerator<int> GetEnumerator() => _data.Cast<int>().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int SumRow(int i)
        {
            var s = 0;
            for (var j = 0; j < Count; j++)
            {
                s += this[i, j];
            }

            return s;
        }

        public int SumColumn(int j)
        {
            var s = 0;
            for (var i = 0; i < Count; i++)
            {
                s += this[i, j];
            }

            return s;
        }

        public int SumMainDiagonal()
        {
            var s = 0;
            for (var i = 0; i < Count; i++)
            {
                s += this[i, i];
            }

            return s;
        }

        public int SumAntiDiagonal()
        {
            var s = 0;
            for (var i = 0; i < Count; i++)
            {
                s += this[i, Count - i - 1];
            }

            return s;
        }
    }
}
