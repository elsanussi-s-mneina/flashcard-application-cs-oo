using System;
using System.IO;
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
            StartCommandLineLoop();
        }

        private static void StartCommandLineLoop()
        {
            while (true)
            {
                Console.WriteLine("Enter 'a' to show both front and back of each card.");
                Console.WriteLine("Enter 'f' to show the front of each card.");
                Console.WriteLine("Enter 'b' to show the back of each card.");
                Console.WriteLine("Enter 'save' to save all flashcards");
                Console.WriteLine("Enter 'x' to exit the application.");
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
                else if (userInput == "save")
                {
                    // Let the user choose the file name.
                    Console.WriteLine("Enter a name for a file to save to:");
                    Console.Write("> ");
                    string fileName = Console.ReadLine();

                    Console.WriteLine("Saving flashcards to file called '" + fileName + "'");
                    File.WriteAllText(fileName, lesson.TabSeparatedValues(Flashcards));
                    Console.WriteLine("Done writing to file named " + fileName);
                }
                else if (userInput == "x")
                {
                    Console.WriteLine("Exiting...");
                    System.Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Unrecognized input: (" + userInput + ")");
                }
            }
        }
    }
}
