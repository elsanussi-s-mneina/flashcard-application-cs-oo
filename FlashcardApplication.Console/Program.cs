using System;
using System.IO;
using System.Collections.Generic;

using static System.Console;

namespace FlashcardApplication.Console
{
    public struct Flashcard
    {
        public string front;
        public string back;
    }

    public class Program
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
                IList<Flashcard> flashcards = LessonFromTabSeparatedValues(fileContents);
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
                WriteLine("Enter 'save' to save all flashcards");
                WriteLine("Enter 'x' to exit the application.");
                Write("> "); // terminal prompt to show the user
                string userInput = ReadLine();

                switch (userInput)
                {
                    case "a":
                        WriteLine("Printing Lesson summary:");
                        WriteLine(LessonSummary(flashcards));
                        break;
                    case "f":
                        WriteLine("Print only fronts of each card:");
                        WriteLine(FrontSummary(flashcards));
                        break;
                    case "b":
                        WriteLine("Print only backs of each card:");
                        WriteLine(BackSummary(flashcards));
                        break;
                    case "save":
                        // Let the user choose the file name.
                        WriteLine("Enter a name for a file to save to:");
                        Write("> ");
                        string fileName = ReadLine();

                        WriteLine("Saving flashcards to file called '" + fileName + "'");
                        File.WriteAllText(fileName, LessonTabSeparatedValues(flashcards));
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





        /// <summary>
        /// The front and back of a single flashcard.
        /// </summary>
        public static string Show(Flashcard flashcard)
        {
            return flashcard.front + " | " + flashcard.back;
        }

        public static string ShowFront(Flashcard flashcard)
        {
            return flashcard.front;
        }

        public static string ShowBack(Flashcard flashcard)
        {
            return flashcard.back;
        }

        /// <summary>
        /// Convert a flashcard to tab separated values.
        /// </summary>
        public static string FlashcardTabSeparatedValues(Flashcard flashcard)
        {
            return flashcard.front + "\t" + flashcard.back + "\n";
        }

        public static Flashcard FlashcardFromTabSeparatedValues(string line)
        {
            string lineTrimmed = line.TrimEnd();
            string[] parts = lineTrimmed.Split('\t');
            string front = string.Empty;
            string back = string.Empty;

            if (parts.Length > 0)
            {
                front = parts[0];
            }

            if (parts.Length > 1)
            {
                back = parts[1];
            }

            Flashcard flashcard = new Flashcard
            {
                front = front,
                back = back
            };

            return flashcard;
        }


        /// <summary>
        /// A lesson consists of flashcard data, and related functions.
        /// </summary>



        /// <summary>
        /// The front and backs of every flashcard in a given list.
        /// </summary>
        /// <param name="flashcards"></param>
        /// <returns></returns>
        public static string LessonSummary(IList<Flashcard> flashcards)
        {
            string result = string.Empty;
            foreach (Flashcard flashcard in flashcards)
            {
                result += Show(flashcard) + "\n";
            }

            return result;
        }

        /// <summary>
        /// The front of every flashcard in a given list.
        /// </summary>
        /// <param name="flashcards">list of flashcards</param>
        /// <returns>front of a card then a new line then the front of the next card, and so on</returns>
        public static string FrontSummary(IList<Flashcard> flashcards)
        {
            string result = string.Empty;
            foreach (Flashcard flashcard in flashcards)
            {
                result += ShowFront(flashcard) + "\n";
            }

            return result;
        }

        /// <summary>
        /// The back of every flashcard in a given list.
        /// </summary>
        /// <param name="flashcards">list of flashcards</param>
        /// <returns>back of a card then a new line then the back of the next card, and so on</returns>
        public static string BackSummary(IList<Flashcard> flashcards)
        {
            string result = string.Empty;
            foreach (Flashcard flashcard in flashcards)
            {
                result += ShowBack(flashcard) + "\n";
            }

            return result;
        }

        /// <summary>
        /// Convert the flashcards to a tab separated values format.
        /// </summary>
        public static string LessonTabSeparatedValues(IList<Flashcard> flashcards)
        {
            string result = string.Empty;
            foreach (Flashcard flashcard in flashcards)
            {
                result += FlashcardTabSeparatedValues(flashcard);
            }
            return result;
        }

        /// <summary>
        /// Convert tab separated values to a list of flashcards.
        /// </summary>
        /// <param name="contents">text with as many lines as there are flashcards.</param>
        /// <returns>a list of flashcards</returns>
        public static IList<Flashcard> LessonFromTabSeparatedValues(string contents)
        {
            var flashcards = new List<Flashcard>();
            if (string.IsNullOrEmpty(contents))
            {
                return flashcards;
            }
            string[] lines = contents.Split(new char[] { '\n' });

            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    flashcards.Add(FlashcardFromTabSeparatedValues(line));
                }
            }
            return flashcards;
        }
    }
}
