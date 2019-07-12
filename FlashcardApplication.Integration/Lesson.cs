using System.Collections.Generic;

namespace FlashcardApplication.Integration
{
    public class Lesson
    {
        public string LessonSummary(IList<Flashcard> flashcards)
        {
            string result = string.Empty;
            foreach (Flashcard flashcard in flashcards)
            {
                result += flashcard + "\n";
            }

            return result;
        }
    }
}
