using NUnit.Framework;
using FlashcardApplication.Integration;

namespace Tests
{
    public class LessonTests
    {
        [Test]
        public void LessonSummary_ShouldReturnExactlyTheValue_ForTwoFlashcards()
        {
            Lesson lesson = new Lesson();
            Assert.AreEqual(lesson.LessonSummary(), "the | le/la \n a | un/une\n");
        }
    }
}