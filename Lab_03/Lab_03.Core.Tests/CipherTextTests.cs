using NUnit.Framework;

namespace Lab_03.Core.Tests
{
    public class CipherTextTests
    {
        [Test]
        public void Test1()
        {
            var c = new CipherText("я хочу, пицу!");

            Assert.That(c.CipherTextOriginal, Is.EqualTo("я хочу, пицу!"));
            Assert.That(c.CipherTextOnlyLetters, Is.EqualTo("яхочупицу"));

            c.TextOnlyLetters = "имогугиху";
            Assert.That(c.TextOnlyLetters, Is.EqualTo("имогугиху"));

            Assert.That(c.Text, Is.EqualTo("и могу, гиху!"));
        }
    }
}
