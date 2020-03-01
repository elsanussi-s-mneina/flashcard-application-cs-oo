using System.IO;
using System.Collections.Generic;
using FlashcardApplication.Integration;
using static System.Console;

namespace flashcard_application_cs_oo
{
    class Program
    {
        /// <summary>
        /// This program runs in the terminal. It outputs text to the student.
        /// </summary>
        static void Main(string[] args)
        {
            WriteLine("Welcome to Remember the Letter (C# object-oriented)");
            WriteLine();  // blank line


            WriteLine("Enter 'open' if you want to open a lesson file");
            WriteLine("Enter 'opendb' if you want to open a lesson from a database.");
            WriteLine("Enter 'n' if you want to create a new lesson.");
            WriteLine();
            PrintPrompt();

            string userInput = ReadLine();
            if (userInput == "open")
            {
                WriteLine("Enter a name for a file to open:");
                PrintPrompt();
                string fileName = ReadLine();
                string fileContents = File.ReadAllText(fileName);
                IList<Flashcard> flashcards = Lesson.FromTabSeparatedValues(fileContents);
                StartCommandLineLoop(flashcards, false);
            }
            else if (userInput == "opendb")
            {
                WriteLine("Loading flashcards from the database");
                IList<Flashcard> flashcards = new DatabaseBridge().GetFlashcards();
                StartCommandLineLoop(flashcards, true);
            }
            else
            {
                StartCommandLineLoop(new List<Flashcard>(), false);
            }
        }

        private static void PrintPrompt()
        {
            Write("> "); // terminal prompt to show the user
        }

        private static void StartCommandLineLoop(IList<Flashcard> flashcards,
            bool fromDatabase)
        {
            while (true)
            {
                WriteLine("Enter 'a' to show both front and back of each card.");
                WriteLine("Enter 'f' to show the front of each card.");
                WriteLine("Enter 'b' to show the back of each card.");
                WriteLine("Enter 'add' to add a flashcard.");
                WriteLine("Enter 'save' to save all flashcards");
                WriteLine("Enter 'x' to exit the application.");
                PrintPrompt();
                string userInput = ReadLine();
                Lesson lesson = new Lesson();

                switch (userInput)
                {
                    case "a":
                        WriteLine("Printing Lesson summary:");
                        WriteLine(lesson.LessonSummary(flashcards));
                        break;
                    case "f":
                        WriteLine("Print only fronts of each card:");
                        WriteLine(lesson.FrontSummary(flashcards));
                        break;
                    case "b":
                        WriteLine("Print only backs of each card:");
                        WriteLine(lesson.BackSummary(flashcards));
                        break;
                    case "add":
                        WriteLine("Adding a flashcard...");
                        WriteLine("Enter the front side:");
                        PrintPrompt();
                        string fSide = ReadLine();
                        WriteLine("You entered the following for the front side: (" +
                                  fSide + ")");
                        WriteLine("Enter the back side:");
                        PrintPrompt();
                        string bSide = ReadLine();
                        WriteLine("You entered the following for the back side: (" +
                                  bSide + ")");
                        var addition = new Flashcard(fSide, bSide);
                        flashcards.Add(addition);
                        if (fromDatabase)
                        {
                            new DatabaseBridge().AddFlashcard(addition);
                        }

                        WriteLine("Done adding flashcard.");
                        break;
                    case "save":
                        if (fromDatabase)
                        {
                            WriteLine("Already saved.");
                        }
                        else
                        {
                            // Let the user choose the file name.
                            WriteLine("Enter a name for a file to save to:");
                            PrintPrompt();
                            string fileName = ReadLine();

                            WriteLine("Saving flashcards to file called '" + fileName + "'");
                            File.WriteAllText(fileName, lesson.TabSeparatedValues(flashcards));
                            WriteLine("Done writing to file named " + fileName);
                        }
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
