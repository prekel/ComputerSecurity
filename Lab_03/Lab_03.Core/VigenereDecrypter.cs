using System;
using System.Linq;
using System.Text;

namespace Lab_03.Core
{
    public class VigenereDecrypter
    {
        private const string RussianLetters = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        public VigenereDecrypter(string cipherTextOriginal)
        {
            CipherTextOriginal = cipherTextOriginal;
            CipherTextOnlyLetters = new string(CipherTextOriginal.Where(Char.IsLetter).ToArray());
        }

        public string CipherTextOriginal { get; }

        public string CipherTextOnlyLetters { get; }

        public string TextOnlyLetters { get; private set; } = "";

        public string? Text
        {
            get
            {
                Decrypt();
                if (TextOnlyLetters.Length != CipherTextOnlyLetters.Length)
                {
                    return null;
                }

                var sb = new StringBuilder();
                var k = 0;
                foreach (var i in CipherTextOriginal)
                {
                    sb.Append(Char.IsLetter(i) ? TextOnlyLetters[k++] : i);
                }

                return sb.ToString();
            }
        }


        public string Key { get; set; } = "А";

        public static char Decrypt(char i, char p)
        {
            var e = RussianLetters.IndexOf(i);
            var k = RussianLetters.IndexOf(p);
            var m = RussianLetters.Length;

            var o = (e - k) % m;
            if (o < 0)
            {
                o = m + o;
            }

            var ch = RussianLetters[o];
            return ch;
        }

        public static char Crypt(char i, char p)
        {
            var e = RussianLetters.IndexOf(i);
            var k = RussianLetters.IndexOf(p);
            var m = RussianLetters.Length;

            var o = (e + k) % m;

            var ch = RussianLetters[o];
            return ch;
        }

        private void Decrypt()
        {
            var text = new StringBuilder();
            var j = 0;
            foreach (var i in CipherTextOnlyLetters)
            {
                var ch = Decrypt(i, Key[j++]);
                j %= Key.Length;
                var m = RussianLetters.Length;
                text.Append(ch);
            }

            TextOnlyLetters = text.ToString();
        }
    }
}
