using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FlashcardApplication.Services;
using FlashcardApplication.Web.ASP.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlashcardApplication.Web.ASP.Controllers
{
    public class LessonController : Controller
    {
        public IList<FlashcardDTO> flashcards = new List<FlashcardDTO>();
        private IFlashcardServices services;

        public LessonController(IFlashcardServices services)
        {
            this.services = services;
            flashcards = services.GetFlashcards();
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
                var addition = new FlashcardDTO
                {
                    FrontSide = model.FrontSide,
                    BackSide = model.BackSide
                };

                services.AddFlashcard(addition);

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