using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlashcardApplication.Integration;
using FlashcardApplication.Web.ASP.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlashcardApplication.Web.ASP.Controllers
{
    public class LessonController : Controller
    {
        public IList<Flashcard> flashcards = new List<Flashcard>
        {
            new Flashcard("the", "le/la"),
            new Flashcard("I", "je"),
            new Flashcard("we", "nous")
        };

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(new FlashcardModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                        Flashcards = flashcards});
        }
    }
}
