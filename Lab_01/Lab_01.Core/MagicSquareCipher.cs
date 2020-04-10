using System.Text;

namespace Lab_01.Core
{
    public class MagicSquareCipher
    {
        public MagicSquareCipher(MagicSquare key, char emptyChar = ' ')
        {
            Key = key;
            CipherTextMatrix = new char[Key.Count, Key.Count];
            EmptyChar = emptyChar;
        }

        public int MaxLength => Key.Count * Key.Count;

        public MagicSquare Key { get; }

        public char[,] CipherTextMatrix { get; }

        public string Text { get; set; }

        public char EmptyChar { get; set; }

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
