using NUnit.Framework;
using FlashcardApplication.Console;
using static FlashcardApplication.Console.Program;
namespace Tests
{
    public class FlashcardTests
    {
        [Test]
        public void Show_WhenFrontSideIsZAndBackSideIsLowercaseD_ShouldReturnTheFrontSideThenAPipeCharacterThenTheBackSide()
        {
            Flashcard flashcard = new Flashcard { front = "Z", back = "d" };
            Assert.That(Show(flashcard), Is.EqualTo("Z | d"));
        }

        [Test]
        public void Show_WhenFrontSideIsABAndBackSideIsLowercaseABC_ShouldReturnTheFrontSideThenAPipeCharacterThenTheBackSide()
        {
            Flashcard flashcard = new Flashcard { front = "AB", back = "abc" };
            Assert.That(Show(flashcard), Is.EqualTo("AB | abc"));
        }

        [Test]
        public void ShowFront_WhenTheFrontSideIsOne_ReturnsOne()
        {
            Flashcard flashcard = new Flashcard { front = "one", back = "une" };
            string result = ShowFront(flashcard);
            Assert.That(result, Is.EqualTo("one"));
        }

        [Test]
        public void ShowFront_WhenTheFrontSideIsThree_ReturnsThree()
        {
            Flashcard flashcard = new Flashcard { front = "three", back = "h" };
            string result = ShowFront(flashcard);
            Assert.That(result, Is.EqualTo("three"));
        }

        [Test]
        public void ShowBack_WhenTheBackSideIsFive_ReturnsFive()
        {
            Flashcard flashcard = new Flashcard { front = "", back = "five" };
            string result = ShowBack(flashcard);
            Assert.That(result, Is.EqualTo("five"));
        }

        [Test]
        public void ShowBack_WhenBackSideIsAnEmptyString_ReturnsEmptyString()
        {
            Flashcard flashcard = new Flashcard { front="wh", back=string.Empty };
            string result = ShowBack(flashcard);
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void TabSeparatedValues_WhenBackAndFrontAreEmpty_ReturnsATabThenANewLine()
        {
            Flashcard flashcard = new Flashcard { front = string.Empty, back = string.Empty };
            string result = FlashcardTabSeparatedValues(flashcard);
            Assert.That(result, Is.EqualTo("\t\n"));
        }

        [Test]
        public void TabSeparatedValues_WhenFrontIsTurtleAndBackIsEmpty_ReturnsTurtleThenATabThenANewLine()
        {
            Flashcard flashcard = new Flashcard { front = "turtle", back = string.Empty };
            string result = FlashcardTabSeparatedValues(flashcard);
            Assert.That(result, Is.EqualTo("turtle\t\n"));
        }

        [Test]
        public void TabSeparatedValues_WhenFrontIsTurtleAndBackIsFox_ReturnsTurtleThenATabThenFoxThenANewLine()
        {
            Flashcard flashcard = new Flashcard { front = "turtle", back = "fox" };
            string result = FlashcardTabSeparatedValues(flashcard);
            Assert.That(result, Is.EqualTo("turtle\tfox\n"));
        }

        [Test]
        public void FromTabSeparatedValues_WhenGivenTurtleThenTabThenFoxThenNewLine_ShouldHaveGoodToString()
        {
            Flashcard flashcard = FlashcardFromTabSeparatedValues("turtle\tfox\n");
            string result = Show(flashcard);
            Assert.That(result, Is.EqualTo("turtle | fox"));
        }

        [Test]
        public void FromTabSeparatedValues_WhenGivenRabbitThenTabThenSnailThenNewLine_ShouldHaveGoodToString()
        {
            Flashcard flashcard = FlashcardFromTabSeparatedValues("rabbit\tsnail\n");
            string result = Show(flashcard);
            Assert.That(result, Is.EqualTo("rabbit | snail"));
        }

        [Test]
        public void FromTabSeparatedValues_WhenGivenRabbitThenNewLine_ShouldNotCrashButSetBackToEmptyString()
        {
            Flashcard flashcard = FlashcardFromTabSeparatedValues("rabbit\n");
            string result = Show(flashcard);
            Assert.That(result, Is.EqualTo("rabbit | "));
        }
    }
}
