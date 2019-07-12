namespace FlashcardApplication.Integration
{
    public class Flashcard
    {
        private string front;
        private string back;

        public Flashcard(string front, string back)
        {
            this.front = front;
            this.back = back;
        }

        /// <summary>
        /// The front and back of a single flashcard.
        /// </summary>
        public override string ToString()
        {
            return front + " | " + back;
        }
    }
}
