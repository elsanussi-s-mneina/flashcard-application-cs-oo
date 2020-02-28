using System;
using System.Collections.Generic;
using FlashcardApplication.Integration;

namespace FlashcardApplication.Web.ASP.Models
{
    public class FlashcardModel
    {
        public string RequestId { get; set; }

        public IList<Flashcard> Flashcards { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string FrontSide { get; set; }

        public string BackSide { get; set; }
    }
}
