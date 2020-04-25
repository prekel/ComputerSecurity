using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab_01.Core
{
    /// <summary>
    ///     Магический квадрат.
    /// </summary>
    public class MagicSquare : IEnumerable<int>
    {
        /// <summary>
        ///     Значения магического квадрата.
        /// </summary>
        private readonly int[,] _data;

        /// <summary>
        ///     Инициализирует новый экземпляр магического квадрата, заполняя нулями.
        /// </summary>
        /// <param name="n">Размер квадрата.</param>
        public MagicSquare(int n)
        {
            Count = n;
            _data = new int[n, n];
        }

        /// <summary>
        ///     Инициализирует новый экземпляр магического квадрата, заполняя значения из строки.
        ///     Перевод строки между строками, пробел между рядами.
        /// </summary>
        /// <param name="s">Магический квадрат в виде строки.</param>
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

        /// <summary>
        ///     Размер квадрата (N).
        /// </summary>
        public int Count { get; }

        public int this[int i, int j]
        {
            get => _data[i, j];
            set => _data[i, j] = value;
        }

        /// <summary>
        ///     Является ли квадрат магическим.
        /// </summary>
        public bool IsMagic => IsMagicSum && IsDistinct;

        /// <summary>
        ///     Правда ли, что сумма чисел в каждой строке, каждом столбце и на обеих диагоналях одинакова.
        /// </summary>
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

        /// <summary>
        ///     Являются ли элементы в квадрате от 1 до N*N.
        /// </summary>
        public bool IsDistinct =>
            this.OrderBy(p => p)
                .SequenceEqual(Enumerable.Range(1, Count * Count));

        public IEnumerator<int> GetEnumerator() => _data.Cast<int>().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        ///     Сумма строки с индексом i.
        /// </summary>
        /// <param name="i">Индекс строки.</param>
        /// <returns>Сумма строки.</returns>
        public int SumRow(int i)
        {
            var s = 0;
            for (var j = 0; j < Count; j++)
            {
                s += this[i, j];
            }

            return s;
        }

        /// <summary>
        ///     Сумма ряда с индексом j.
        /// </summary>
        /// <param name="j">Индекс ряда.</param>
        /// <returns>Сумма ряда.</returns>
        public int SumColumn(int j)
        {
            var s = 0;
            for (var i = 0; i < Count; i++)
            {
                s += this[i, j];
            }

            return s;
        }

        /// <summary>
        ///     Сумма главной диагонали.
        /// </summary>
        /// <returns>Сумма главной диагонали.</returns>
        public int SumMainDiagonal()
        {
            var s = 0;
            for (var i = 0; i < Count; i++)
            {
                s += this[i, i];
            }

            return s;
        }

        /// <summary>
        ///     Сумма побочной диагонали.
        /// </summary>
        /// <returns>Сумма побочной диагонали.</returns>
        public int SumAntiDiagonal()
        {
            var s = 0;
            for (var i = 0; i < Count; i++)
            {
                s += this[i, Count - i - 1];
            }

            return s;
        }

        /// <summary>
        ///     Поворачивает квадрат на 90 градусов против часовой.
        /// </summary>
        public void Rotate()
        {
            for (var x = 0; x < Count / 2; x++)
            {
                for (var y = x; y < Count - x - 1; y++)
                {
                    var temp = this[x, y];
                    this[x, y] = this[y, Count - 1 - x];
                    this[y, Count - 1 - x] = this[Count - 1 - x, Count - 1 - y];
                    this[Count - 1 - x, Count - 1 - y] = this[Count - 1 - y, x];
                    this[Count - 1 - y, x] = temp;
                }
            }
        }

        public override string ToString()
        {
            return String.Join("\n",
                Enumerable.Range(0, Count)
                    .Select(p =>
                    {
                        var a = new int[Count];
                        for (var i = 0; i < Count; i++)
                        {
                            a[i] = this[p, i];
                        }

                        return String.Join(" ", a.Select(u => u.ToString()));
                    }));
        }
    }
}
