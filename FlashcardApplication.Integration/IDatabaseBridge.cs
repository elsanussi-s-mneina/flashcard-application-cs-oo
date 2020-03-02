using System.Collections.Generic;

namespace FlashcardApplication.Integration
{
    public interface IDatabaseBridge
    {
        IList<Flashcard> GetFlashcards();

        void AddFlashcard(Flashcard addition);
    }
}