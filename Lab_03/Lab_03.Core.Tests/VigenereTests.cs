using System.Linq;

using NUnit.Framework;

namespace Lab_03.Core.Tests
{
    public class VigenereTests
    {
        [Test]
        public void TestSample1()
        {
            var c = new VigenereDecrypter("ВЙИИОЗР") {Key = "АБВ"};

            Assert.That(c.Text, Is.EqualTo("ВИЖИНЕР"));
        }

        [Test]
        public void TestVar1()
        {
            var t = Variants.GetVariantByNumber(1);
            var an = new VigenereAnalysis(t);

            var pm = an.PossibleMus();

            an.SuggestMu(pm.First());
            an.SuggestMostOccuring(0, 'О');
            an.SuggestMostOccuring(1, 'О');
            an.SuggestMostOccuring(2, 'Е');
            an.SuggestMostOccuring(3, 'О');
            an.SuggestMostOccuring(4, 'О');
            an.SuggestMostOccuring(5, 'О');
            an.SuggestMostOccuring(6, 'О');

            Assert.That(an.VigenereDecrypter.Key, Is.EqualTo("КОЛОДЕЦ"));

            Assert.That(an.VigenereDecrypter.Text?.Split(" ").First(), Is.EqualTo("МОЛОДОЙ"));
        }


        [Test]
        public void TestVar14()
        {
            var v14 = Variants.GetVariantByNumber(14);
            var v = new VigenereDecrypter(v14);

            var an = new VigenereAnalysis(v14);
            var pm = an.PossibleMus();

            an.SuggestMu(pm.First());
            an.SuggestMostOccuring(0, 'О');
            an.SuggestMostOccuring(1, 'О');
            an.SuggestMostOccuring(2, 'О');
            an.SuggestMostOccuring(3, 'О');
            an.SuggestMostOccuring(4, 'О');
            an.SuggestMostOccuring(5, 'О');

            Assert.That(an.VigenereDecrypter.Key, Is.EqualTo("КРУЖКА"));

            Assert.That(an.VigenereDecrypter.Text?.Split(" ").Skip(1).First(), Is.EqualTo("ПОЧИТАЮ"));
        }

        [Test]
        public void TestVar12()
        {
            var v12 = Variants.GetVariantByNumber(12);
            var an = new VigenereAnalysis(v12);
            var pm = an.PossibleMus();

            an.SuggestMu(pm.First());
            an.SuggestMostOccuring(0, 'Е');
            an.SuggestMostOccuring(1, 'А');
            an.SuggestMostOccuring(2, 'О');
            an.SuggestMostOccuring(3, 'О');
            an.SuggestMostOccuring(4, 'О');

            Assert.That(an.VigenereDecrypter.Key, Is.EqualTo("ЧЕСТЦ"));
            Assert.That(an.VigenereDecrypter.Text?.Split(" ").Skip(1).First(), Is.EqualTo("ДВЕУАДЦАШЬ"));

            const string post = "В ДВЕНАДЦАШЬ";
            an.FixKey(post);

            Assert.That(an.VigenereDecrypter.Key, Is.EqualTo("ЧЕСТЬ"));
            Assert.That(an.VigenereDecrypter.Text?.Split(" ").Skip(1).First(), Is.EqualTo("ДВЕНАДЦАТЬ"));
        }

        [Test]
        public void TestAnswers()
        {
            var starts = new[]
            {
                "МОЛОДОЙ ЧАРТКОВ",
                "ОДИНОКО В СТОРОНЕ",
                "ДЕД МОЙ",
                "КАК ТОЛЬКО РЫЦАРЬ",
                "НЕБО ЗВЕЗДИЛОСЬ",
                "ОТРЯД МИНУЛ ГОРОД",
                "Я ОЧЕНЬ ЛЮБЛЮ",
                "НИГДЕ НЕ ОСТАНАВЛИВАЛОСЬ",
                "ЗА САДОМ НАХОДИЛСЯ",
                "САМОЕ ТОРЖЕСТВЕННОЕ",
                "ФИЛОСОФ НАЧАЛ НА",
                "В ДВЕНАДЦАТЬ ЧАСОВ",
                "НО ПРЕЖДЕ НЕЖЕЛИ",
                "Я ПОЧИТАЮ НЕ ИЗЛИШНИМ",
                "С ДОСАДОЮ ЗАКУСИВ"
            };
            for (var i = 0; i < Variants.GetVariantsCount(); i++)
            {
                var v = Variants.GetVariantByNumber(i + 1);
                var an = new VigenereAnalysis(v);

                an.VigenereDecrypter.Key = Variants.GetAnswerByNumber(i + 1);

                Assert.That(an.VigenereDecrypter.Text?.Substring(0, starts[i].Length), Is.EqualTo(starts[i]));
            }
        }
    }
}
