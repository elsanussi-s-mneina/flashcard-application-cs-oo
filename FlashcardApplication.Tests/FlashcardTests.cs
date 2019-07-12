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
    }
}