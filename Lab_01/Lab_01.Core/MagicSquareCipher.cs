using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Lab_01.Core
{
    public class MagicSquareCipher
    {
        public MagicSquare Key { get; }
        
        public char[,] CipherTextMatrix { get; }
        
        public string Text { get; set; } 

        public string CipherText
        {
            get => new string(CipherTextMatrix.Cast<char>().ToArray());

            private set
            {
                for (var i = 0; i < Key.Count; i++)
                {
                    for (var j = 0; j < Key.Count; j++)
                    {
                        CipherTextMatrix[i, j] = value[i * Key.Count + j];
                    }
                }
            }
        } 

        public MagicSquareCipher(MagicSquare key)
        {
            Key = key;
            CipherTextMatrix = new char[Key.Count, Key.Count];
        }

        public string Crypt(string text)
        {
            Text = text;
            
            for (var i = 0; i < Key.Count; i++)
            {
                for (var j = 0; j < Key.Count; j++)
                {
                    CipherTextMatrix[i, j] = text[Key[i, j] - 1];
                }
            }

            return CipherText;
        }
        
        public string Encrypt(string cipherText)
        {
            CipherText = cipherText;

            var sb = new StringBuilder(Key.Count * Key.Count);
            for (var k = 0; k < Key.Count * Key.Count; k++)
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

            Text = sb.ToString();
            return Text;
        }
    }
}
