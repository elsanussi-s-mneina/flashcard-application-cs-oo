using System.Collections.Generic;
using NUnit.Framework;
using FlashcardApplication.Integration;
using static FlashcardApplication.Integration.Lesson;

namespace Tests
{
    public class LessonTests
    {
        [Test]
        public void LessonSummary_ShouldReturnExactlyTheValue_ForTwoFlashcards()
        {

            var flashcards = new List<Flashcard>
            {
                new Flashcard("the", "le/la"),
                new Flashcard("a", "un/une")
            };

            Assert.That(LessonSummary(flashcards), Is.EqualTo("the | le/la\na | un/une\n"));
        }


        [Test]
        public void FrontSummary_WhenGivenAnEmptyList_ReturnsEmptyString()
        {
            var flashcards = new List<Flashcard> { };
            string result = FrontSummary(flashcards);
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void FrontSummary_WhenGivenAListWithOneFlashcardWhoseFrontSideIsOne_ReturnsOneFollowedByANewLine()
        {
            var flashcards = new List<Flashcard>();
            flashcards.Add(new Flashcard("one", "une"));
            string result = FrontSummary(flashcards);
            Assert.That(result, Is.EqualTo("one\n"));
        }

        [Test]
        public void FrontSummary_WhenGivenAListWithTwoFlashcardsTheFirstWhoseFrontSideIsAAndWhoseSecondCardHasAFrontSideWithB_ShouldReturnAFollowedByANewLineFollowedByAB()
        {
            var flashcards = new List<Flashcard>();
            flashcards.Add(new Flashcard("a", "sf"));
            flashcards.Add(new Flashcard("b", "wh"));
            string result = FrontSummary(flashcards);
            Assert.That(result, Is.EqualTo("a\nb\n"));
        }

        [Test]
        public void BackSummary_WhenGivenAnEmptyList_ReturnsAnEmptyString()
        {
            var flashcards = new List<Flashcard>();
            string result = BackSummary(flashcards);
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void FrontSummary_WhenGivenAListWithTwoFlashcardsTheFirstWhoseFrontSideIsRedAndWhoseSecondCardHasAFrontSideWithBlue_ShouldReturnRedFollowedByANewLineFollowedByBlue()
        {
            var flashcards = new List<Flashcard>();
            flashcards.Add(new Flashcard("a", "red"));
            flashcards.Add(new Flashcard("b", "blue"));
            string result = BackSummary(flashcards);
            Assert.That(result, Is.EqualTo("red\nblue\n"));
        }

        [Test]
        public void TabSeparatedValues_WhenGivenAnEmptyList_ReturnsAnEmptyString()
        {
            var flashcards = new List<Flashcard>();
            string result = TabSeparatedValues(flashcards);
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void TabSeparatedValues_WhenGivenAThreeElementList()
        {
            var flashcards = new List<Flashcard>();
            flashcards.Add(new Flashcard("a", "1"));
            flashcards.Add(new Flashcard("ab", "2"));
            flashcards.Add(new Flashcard("abc", "3"));
            string result = TabSeparatedValues(flashcards);
            Assert.That(result, Is.EqualTo("a\t1\nab\t2\nabc\t3\n"));
        }

        [Test]
        public void FromTabSeparatedValues_WhenGivenAnEmptyString_ReturnsAnEmptyList()
        {
            IList<Flashcard> flashcards = FromTabSeparatedValues(string.Empty);
            Assert.That(flashcards, Is.Empty);
        }

        [Test]
        public void FromTabSeparatedValues_WhenGivenThreeWellFormedLines_ReturnsAThreeElementList()
        {
            IList<Flashcard> flashcards = FromTabSeparatedValues("a\tb\nc\td\ne\tf\n");
            Assert.That(flashcards.Count, Is.EqualTo(3));
        }

    }
}