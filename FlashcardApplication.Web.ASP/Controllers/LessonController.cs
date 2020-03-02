using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FlashcardApplication.Integration;
using FlashcardApplication.Web.ASP.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlashcardApplication.Web.ASP.Controllers
{
    public class LessonController : Controller
    {
        public IList<Flashcard> flashcards = new List<Flashcard>();


        public LessonController(IDatabaseBridge database)
        {
            flashcards = database.GetFlashcards();
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(new FlashcardModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                        Flashcards = flashcards});
        }

        public IActionResult Fronts()
        {
            return View(new FlashcardModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                Flashcards = flashcards
            });
        }

        public IActionResult Backs()
        {
            return View(new FlashcardModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                Flashcards = flashcards
            });
        }



        [HttpGet]
        public IActionResult AddFlashcard()
        {
            return View(new FlashcardModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
 
 
        [HttpPost]
        public IActionResult AddFlashcard(FlashcardModel model)
        {
            string message = "";
           
            if (ModelState.IsValid)
            {
                var addition = new Flashcard(model.FrontSide, model.BackSide);

                new DatabaseBridge().AddFlashcard(addition);

                 message = "Flashcard was added successfully:\n\n"
                    + "front side: " + model.FrontSide
                    + "\n back side: " + model.BackSide;
            }
            else
            {
                 message = "Failed to create the flashcard. Please try again";
            }
            return Content(message);
        }

    }
}