using System.Text;

namespace Lab_01.Core
{
    /// <summary>
    ///     Шифрования методом магических квадратов.
    /// </summary>
    public class MagicSquareCipher
    {
        /// <summary>
        ///     Инициализирует новый экземпляр класса шифрования методом магических квадратов.
        /// </summary>
        /// <param name="key">Ключ (магический квадрат).</param>
        /// <param name="emptyChar">Символ, используемый на месте пустых ячеек.</param>
        public MagicSquareCipher(MagicSquare key, char emptyChar = ' ')
        {
            Key = key;
            CipherTextMatrix = new char[Key.Count, Key.Count];
            EmptyChar = emptyChar;
        }

        /// <summary>
        ///     Максимальная и рекомендуемая длина текста, возможная шифрованием данным ключом.
        /// </summary>
        public int MaxLength => Key.Count * Key.Count;

        /// <summary>
        ///     Ключ (магический квадрат).
        /// </summary>
        public MagicSquare Key { get; }

        /// <summary>
        ///     Матрица шифротекста (здесь шифротекст хранится).
        /// </summary>
        private char[,] CipherTextMatrix { get; }

        /// <summary>
        ///     Текст.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        ///     Символ, используемый на месте пустых ячеек.
        /// </summary>
        public char EmptyChar { get; set; }

        /// <summary>
        ///     Шифротекст (вычисляется из матрицы шифротекста).
        /// </summary>
        public string CipherText
        {
            get
            {
                var sb = new StringBuilder();
                for (var i = 0; i < Key.Count; i++)
                {
                    for (var j = 0; j < Key.Count; j++)
                    {
                        sb.Append(CipherTextMatrix[i, j]);
                    }
                }

                return sb.ToString();
            }

            private set
            {
                for (var i = 0; i < Key.Count; i++)
                {
                    for (var j = 0; j < Key.Count; j++)
                    {
                        var index = i * Key.Count + j;
                        if (index >= value.Length)
                        {
                            CipherTextMatrix[i, j] = EmptyChar;
                        }
                        else
                        {
                            CipherTextMatrix[i, j] = value[index];
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Зашифровывает текст.
        /// </summary>
        /// <param name="text">Текст для шифрования.</param>
        /// <returns>Шифротекст.</returns>
        public string Crypt(string text)
        {
            Text = text;

            for (var i = 0; i < Key.Count; i++)
            {
                for (var j = 0; j < Key.Count; j++)
                {
                    if (Key[i, j] - 1 >= text.Length)
                    {
                        CipherTextMatrix[i, j] = EmptyChar;
                    }
                    else
                    {
                        CipherTextMatrix[i, j] = text[Key[i, j] - 1];
                    }
                }
            }

            return CipherText;
        }

        /// <summary>
        ///     Расшифровывает текст.
        /// </summary>
        /// <param name="cipherText">Шифротекст для расшифрованиaя.</param>
        /// <returns>Текст.</returns>
        public string Encrypt(string cipherText)
        {
            CipherText = cipherText;

            var sb = new StringBuilder(MaxLength);
            for (var k = 0; k < MaxLength; k++)
            {
                for (var i = 0; i < Key.Count; i++)
                {
                    for (var j = 0; j < Key.Count; j++)
                    {
                        if (Key[i, j] == k + 1)
                        {
                            sb.Append(CipherTextMatrix[i, j]);
                        }
                    }
                }
            }

            Text = sb.ToString().TrimEnd(EmptyChar);
            return Text;
        }
    }
}
