using NUnit.Framework;
using FlashcardApplication.Integration;

namespace Tests
{
    public class FlashcardTests
    {
        [Test]
        public void ToString_WhenFrontSideIsZAndBackSideIsLowercaseD_ShouldReturnTheFrontSideThenAPipeCharacterThenTheBackSide()
        {
            Flashcard flashcard = new Flashcard("Z", "d");
            Assert.That(flashcard.ToString(), Is.EqualTo("Z | d"));
        }

        [Test]
        public void ToString_WhenFrontSideIsABAndBackSideIsLowercaseABC_ShouldReturnTheFrontSideThenAPipeCharacterThenTheBackSide()
        {
            Flashcard flashcard = new Flashcard("AB", "abc");
            Assert.That(flashcard.ToString(), Is.EqualTo("AB | abc"));
        }

        [Test]
        public void ShowFront_WhenTheFrontSideIsOne_ReturnsOne()
        {
            Flashcard flashcard = new Flashcard("one", "une");
            string result = flashcard.ShowFront();
            Assert.That(result, Is.EqualTo("one"));
        }

        [Test]
        public void ShowFront_WhenTheFrontSideIsThree_ReturnsThree()
        {
            Flashcard flashcard = new Flashcard("three", "h");
            string result = flashcard.ShowFront();
            Assert.That(result, Is.EqualTo("three"));
        }

        [Test]
        public void ShowBack_WhenTheBackSideIsFive_ReturnsFive()
        {
            Flashcard flashcard = new Flashcard("", "five");
            string result = flashcard.ShowBack();
            Assert.That(result, Is.EqualTo("five"));
        }

        [Test]
        public void ShowBack_WhenBackSideIsAnEmptyString_ReturnsEmptyString()
        {
            Flashcard flashcard = new Flashcard("wh", string.Empty);
            string result = flashcard.ShowBack();
            Assert.That(result, Is.EqualTo(string.Empty));
        }
    }
}