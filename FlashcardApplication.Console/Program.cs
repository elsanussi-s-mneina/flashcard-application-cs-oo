using System.IO;
using System.Collections.Generic;
using FlashcardApplication.Integration;
using static System.Console;

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
            WriteLine(greetings.WelcomeMessage); // Show a welcome message.
            WriteLine();  // blank line
            StartCommandLineLoop();
        }

        private static void StartCommandLineLoop()
        {
            while (true)
            {
                WriteLine("Enter 'a' to show both front and back of each card.");
                WriteLine("Enter 'f' to show the front of each card.");
                WriteLine("Enter 'b' to show the back of each card.");
                WriteLine("Enter 'save' to save all flashcards");
                WriteLine("Enter 'x' to exit the application.");
                Write("> "); // terminal prompt to show the user
                string userInput = ReadLine();
                Lesson lesson = new Lesson();

                switch (userInput)
                {
                    case "a":
                        WriteLine("Printing Lesson summary:");
                        WriteLine(lesson.LessonSummary(Flashcards));
                        break;
                    case "f":
                        WriteLine("Print only fronts of each card:");
                        WriteLine(lesson.FrontSummary(Flashcards));
                        break;
                    case "b":
                        WriteLine("Print only backs of each card:");
                        WriteLine(lesson.BackSummary(Flashcards));
                        break;
                    case "save":
                        // Let the user choose the file name.
                        WriteLine("Enter a name for a file to save to:");
                        Write("> ");
                        string fileName = ReadLine();

                        WriteLine("Saving flashcards to file called '" + fileName + "'");
                        File.WriteAllText(fileName, lesson.TabSeparatedValues(Flashcards));
                        WriteLine("Done writing to file named " + fileName);
                        break;
                    case "x":
                        WriteLine("Exiting...");
                        System.Environment.Exit(0);
                        break;
                    default:
                        WriteLine("Unrecognized input: (" + userInput + ")");
                        break;
                }
            }
        }
    }
}
