using System.Collections.Generic;
using FlashcardApplication.Integration;

namespace FlashcardApplication.Services
{
    public class FlashcardServices : IFlashcardServices
    {
        private IDatabaseBridge databaseBridge;

        public FlashcardServices()
        {
            this.databaseBridge = new DatabaseBridge();
        }

        public void AddFlashcard(FlashcardDTO addition)
        {
            var card = new Flashcard(addition.FrontSide, addition.BackSide);

            databaseBridge.AddFlashcard(card);
        }

        public IList<FlashcardDTO> GetFlashcards()
        {
            IList<Flashcard> flashcards = databaseBridge.GetFlashcards();

            IList<FlashcardDTO> results = new List<FlashcardDTO>();

            foreach (Flashcard flashcard in flashcards)
            {
                results.Add(new FlashcardDTO
                {
                    ID = flashcard.ID,
                    FrontSide = flashcard.ShowFront(),
                    BackSide = flashcard.ShowBack()
                });
            }

            return results;
        }
    }
}
