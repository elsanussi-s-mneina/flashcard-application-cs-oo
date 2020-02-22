using System;

namespace FlashcardApplication.Web.ASP.Models
{
    public class FlashcardModel
    {
        public string RequestId { get; set; }

        public string FrontSide { get; set; }

        public string BackSide { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
