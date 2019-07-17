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
            WriteLine("Enter 'n' if you want to create a new lesson.");
            WriteLine();
            Write("> ");

            string userInput = ReadLine();
            if (userInput == "open")
            {
                WriteLine("Enter a name for a file to open:");
                Write("> ");
                string fileName = ReadLine();
                string fileContents = File.ReadAllText(fileName);
                IList<Flashcard> flashcards = Lesson.FromTabSeparatedValues(fileContents);
                StartCommandLineLoop(flashcards);
            }
            else
            {
                StartCommandLineLoop(new List<Flashcard>());
            }
        }

        private static void StartCommandLineLoop(IList<Flashcard> flashcards)
        {
            while (true)
            {
                WriteLine("Enter 'a' to show both front and back of each card.");
                WriteLine("Enter 'f' to show the front of each card.");
                WriteLine("Enter 'b' to show the back of each card.");
                WriteLine("Enter 'add' to add a flashcard.");
                WriteLine("Enter 'save' to save all flashcards");
                WriteLine("Enter 'x' to exit the application.");
                Write("> "); // terminal prompt to show the user
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
                        Write("Enter the front side >");
                        string fSide = ReadLine();
                        WriteLine("You entered the following for the front side: (" +
                                  fSide + ")");
                        Write("Enter the back side >");
                        string bSide = ReadLine();
                        WriteLine("You entered the following for the back side: (" +
                                  bSide + ")");
                        flashcards.Add(new Flashcard(fSide, bSide));
                        WriteLine("Done adding flashcard.");
                        break;
                    case "save":
                        // Let the user choose the file name.
                        WriteLine("Enter a name for a file to save to:");
                        Write("> ");
                        string fileName = ReadLine();

                        WriteLine("Saving flashcards to file called '" + fileName + "'");
                        File.WriteAllText(fileName, lesson.TabSeparatedValues(flashcards));
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
