namespace FlashcardApplication.Integration
{
    public class Lesson
    {
        private const string Flashcard1 = "the | le/la";
        private const string Flashcard2 = "a | un/une";

        public string LessonSummary()
        {
            return Flashcard1 + " \n " + Flashcard2 + "\n";
        }
    }
}
