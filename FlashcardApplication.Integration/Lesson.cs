namespace FlashcardApplication.Integration
{
    public class Lesson
    {
        private const string Flashcard1 = "the | le/la";
        private const string Flashcard2 = "a | un/une";

        public string LessonSummary()
        {
            return ShowFlashcard(Flashcard1) + ShowFlashcard(Flashcard2);
        }

        public string ShowFlashcard(string flashcard)
        {
            return flashcard + " \n ";
        }
    }
}
