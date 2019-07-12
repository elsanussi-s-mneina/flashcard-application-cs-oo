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
            Console.WriteLine("Enter 'a' to show both front and back of each card.");
            Console.WriteLine("Enter 'f' to show the front of each card.");
            Console.WriteLine("Enter 'b' to show the back of each card.");
            Console.Write("> "); // terminal prompt to show the user
            string userInput = Console.ReadLine();
            Lesson lesson = new Lesson();
            if (userInput == "a")
            {
                Console.WriteLine("Printing Lesson summary:");
                Console.WriteLine(lesson.LessonSummary(Flashcards));
            }
            else if (userInput == "f")
            {
                Console.WriteLine("Print only fronts of each card:");
                Console.WriteLine(lesson.FrontSummary(Flashcards));
            }
            else if (userInput == "b")
            {
                Console.WriteLine("Print only backs of each card:");
                Console.WriteLine(lesson.BackSummary(Flashcards));
            }
            else
            {
                Console.WriteLine("Unrecognized input: (" + userInput + ")");
            }
        }
    }
}
