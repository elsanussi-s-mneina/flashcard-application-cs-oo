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
    }
}