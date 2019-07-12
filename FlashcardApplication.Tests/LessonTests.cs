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
    }
}