using System;
using System.Collections.Generic;
using FlashcardApplication.Integration;

namespace flashcard_application_cs_oo
{
    class Program
    {
        /// <summary>
        /// List of flashcards for running the program.
        /// </summary>
        private static IList<Flashcard> Flashcards =
            new List<Flashcard>
            {
                new Flashcard("the", "le/la"),
                new Flashcard("a", "un/une")
            };


        /// <summary>
        /// This program runs in the terminal. It outputs text to the student.
        /// </summary>
        static void Main(string[] args)
        {
            Greetings greetings = new Greetings();
            Console.WriteLine(greetings.WelcomeMessage); // Show a welcome message.
            Console.WriteLine();  // blank line
            Console.WriteLine("Printing Lesson summary:");
            Lesson lesson = new Lesson();
            Console.WriteLine(lesson.LessonSummary(Flashcards));
        }
    }
}
