using System.Collections.Generic;
using NUnit.Framework;
using FlashcardApplication.Integration;

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

            Lesson lesson = new Lesson();
            Assert.That(lesson.LessonSummary(flashcards), Is.EqualTo("the | le/la\na | un/une\n"));
        }


        [Test]
        public void FrontSummary_WhenGivenAnEmptyList_ReturnsEmptyString()
        {
            var flashcards = new List<Flashcard> { };
            var lesson = new Lesson();
            string result = lesson.FrontSummary(flashcards);
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void FrontSummary_WhenGivenAListWithOneFlashcardWhoseFrontSideIsOne_ReturnsOneFollowedByANewLine()
        {
            var flashcards = new List<Flashcard>();
            flashcards.Add(new Flashcard("one", "une"));
            var lesson = new Lesson();
            string result = lesson.FrontSummary(flashcards);
            Assert.That(result, Is.EqualTo("one\n"));
        }

        [Test]
        public void FrontSummary_WhenGivenAListWithTwoFlashcardsTheFirstWhoseFrontSideIsAAndWhoseSecondCardHasAFrontSideWithB_ShouldReturnAFollowedByANewLineFollowedByAB()
        {
            var flashcards = new List<Flashcard>();
            flashcards.Add(new Flashcard("a", "sf"));
            flashcards.Add(new Flashcard("b", "wh"));
            var lesson = new Lesson();
            string result = lesson.FrontSummary(flashcards);
            Assert.That(result, Is.EqualTo("a\nb\n"));
        }

        [Test]
        public void BackSummary_WhenGivenAnEmptyList_ReturnsAnEmptyString()
        {
            var flashcards = new List<Flashcard>();
            var lesson = new Lesson();
            string result = lesson.BackSummary(flashcards);
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void FrontSummary_WhenGivenAListWithTwoFlashcardsTheFirstWhoseFrontSideIsRedAndWhoseSecondCardHasAFrontSideWithBlue_ShouldReturnRedFollowedByANewLineFollowedByBlue()
        {
            var flashcards = new List<Flashcard>();
            flashcards.Add(new Flashcard("a", "red"));
            flashcards.Add(new Flashcard("b", "blue"));
            var lesson = new Lesson();
            string result = lesson.BackSummary(flashcards);
            Assert.That(result, Is.EqualTo("red\nblue\n"));
        }

        [Test]
        public void TabSeparatedValues_WhenGivenAnEmptyList_ReturnsAnEmptyString()
        {
            var flashcards = new List<Flashcard>();
            var lesson = new Lesson();
            string result = lesson.TabSeparatedValues(flashcards);
            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        public void TabSeparatedValues_WhenGivenAThreeElementList()
        {
            var flashcards = new List<Flashcard>();
            flashcards.Add(new Flashcard("a", "1"));
            flashcards.Add(new Flashcard("ab", "2"));
            flashcards.Add(new Flashcard("abc", "3"));
            var lesson = new Lesson();
            string result = lesson.TabSeparatedValues(flashcards);
            Assert.That(result, Is.EqualTo("a\t1\nab\t2\nabc\t3\n"));
        }


    }
}