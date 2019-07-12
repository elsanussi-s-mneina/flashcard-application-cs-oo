using System.Collections.Generic;

namespace FlashcardApplication.Integration
{
    public class Lesson
    {
        private IList<Flashcard> Flashcards =
            new List<Flashcard>
            {
                new Flashcard("the", "le/la"),
                new Flashcard("a", "un/une")
            };

        public string LessonSummary()
        {
            string result = string.Empty;
            foreach (Flashcard flashcard in Flashcards)
            {
                result += flashcard + "\n";
            }

            return result;
        }
    }
}
