using System;
using System.Collections.Generic;
using FlashcardApplication.Integration;

namespace flashcard_application_cs_oo
{
    class Program
    {
        private static IList<Flashcard> Flashcards =
            new List<Flashcard>
            {
                new Flashcard("the", "le/la"),
                new Flashcard("a", "un/une")
            };

        static void Main(string[] args)
        {
            Greetings greetings = new Greetings();
            Console.WriteLine(greetings.WelcomeMessage);
            Console.WriteLine();
            Console.WriteLine("Printing Lesson summary:");
            Lesson lesson = new Lesson();
            Console.WriteLine(lesson.LessonSummary(Flashcards));
        }
    }
}
