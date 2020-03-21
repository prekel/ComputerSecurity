using System.Linq;
using System;

namespace Lab_01.Core
{
    public class MagicSquare
    {
        public int Count => _data.Length;
        private readonly int[,] _data;

        public MagicSquare(int[,] data)
        {
            _data = data;
        }

        public int this[int i, int j]
        {
            get => _data[i, j];
            set => _data[i, j] = value;
        }

        public bool IsMagic
        {
            get { return true; }
        }

        private int SumRow(int i)
        {
            var s = 0;
            for (var j = 0; j < Count; j++)
            {
                s += this[i, j];
            }

            return s;
        }

        private int SumColumn(int j)
        {
            var s = 0;
            for (var i = 0; i < Count; i++)
            {
                s += this[i, j];
            }

            return s;
        }

        private int SumMainDiagonal()
        {
            var s = 0;
            for (var i = 0; i < Count; i++)
            {
                s += this[i, i];
            }

            return s;
        }

        private int SumAntiDiagonal()
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