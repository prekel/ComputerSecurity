using System;
using System.Linq;
using System.Text;

namespace Lab_03.Core
{
    public class CipherText
    {
        public CipherText(string cipherTextOriginal) => CipherTextOriginal = cipherTextOriginal;

        public string CipherTextOriginal { get; }

        public string CipherTextOnlyLetters =>
            new string(CipherTextOriginal.Where(Char.IsLetter).ToArray());

        public string TextOnlyLetters { get; set; } = "";

        public string? Text
        {
            get
            {
                if (TextOnlyLetters.Length != CipherTextOriginal.Length)
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
    }
}
