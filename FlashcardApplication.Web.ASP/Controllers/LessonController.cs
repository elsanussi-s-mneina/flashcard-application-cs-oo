﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlashcardApplication.Integration;
using FlashcardApplication.Web.ASP.Models;
using System.Data.SQLite;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlashcardApplication.Web.ASP.Controllers
{
    public class LessonController : Controller
    {
        public IList<Flashcard> flashcards = new List<Flashcard>();


        public LessonController()
        {
            // We will do this for now. I realize,
            // there is a pattern called dependency injection,
            // perhaps I will do that later when I refactor.
            flashcards = new DatabaseBridge().GetFlashcards();
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

    }
}
