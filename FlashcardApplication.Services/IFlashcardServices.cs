using System.Collections.Generic;

namespace FlashcardApplication.Services
{
    public interface IFlashcardServices
    {
        IList<FlashcardDTO> GetFlashcards();
        void AddFlashcard(FlashcardDTO addition);
    }
}