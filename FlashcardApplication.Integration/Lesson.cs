using System.Collections.Generic;

namespace FlashcardApplication.Integration
{
    public class Lesson
    {
        private const string Flashcard1 = "the | le/la";
        private const string Flashcard2 = "a | un/une";
        private readonly IList<string> Flashcards = new List<string> { Flashcard1, Flashcard2};

        public string LessonSummary()
        {
            string result = string.Empty;
            foreach (string flashcard in Flashcards)
            {
                result += ShowFlashcard(flashcard);
            }

            return result;
        }

        public string ShowFlashcard(string flashcard)
        {
            return flashcard + " \n ";
        }
    }
}
