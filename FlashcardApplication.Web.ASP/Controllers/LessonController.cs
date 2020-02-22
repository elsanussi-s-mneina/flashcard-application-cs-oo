using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlashcardApplication.Integration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlashcardApplication.Web.ASP.Controllers
{
    public class LessonController : Controller
    {
        IList<Flashcard> flashcards = new List<Flashcard>
        {
            new Flashcard("the", "le/la"),
            new Flashcard("I", "je"),
            new Flashcard("we", "nous")
        };

        // GET: /<controller>/
        public string Index()
        {
            return new Lesson().LessonSummary(flashcards);
        }
    }
}
