using System;
using System.Collections.Generic;
using System.Linq;

namespace FlashcardApplication.Integration
{
    /// <summary>
    /// A lesson consists of flashcard data, and related functions.
    /// </summary>
    public static class Lesson
    {

        /// <summary>
        /// The front and backs of every flashcard in a given list.
        /// </summary>
        /// <param name="flashcards"></param>
        /// <returns></returns>
        //public string LessonSummary(IList<Flashcard> flashcards)
        //{
        //    return ApplyToAndSeparate(flashcards, f => f.ToString());
        //}

        public static Func<IList<Flashcard>, string> LessonSummary =
        (flashcards) =>
        {
            return ApplyToAndSeparate(flashcards, Flashcard.ShowBothSides);
        };



        /// <summary>
        /// Apply a function to each flashcard, and put a
        /// line separator after the result of the function.
        /// </summary>
        /// <param name="flashcards">a list of flashcards</param>
        /// <param name="flashcardToString">a function that takes
        /// a flashcard and returns a string</param>
        /// <returns>something about each flashcard</returns>
        private static Func<IList<Flashcard>, Func<Flashcard, String>, string>
        ApplyToAndSeparate =
        (flashcards, flashcardToString) =>
        {
            return flashcards.Select((f1) => flashcardToString(f1) + "\n")
                    .DefaultIfEmpty(string.Empty)
                    .Aggregate((x, y) => x + y);
        };


        /// <summary>
        /// The front of every flashcard in a given list.
        /// </summary>
        /// <param name="flashcards">list of flashcards</param>
        /// <returns>front of a card then a new line then the front of the next card, and so on</returns>
        public static Func<IList<Flashcard>, string> FrontSummary =
        (flashcards) =>
        {
            return ApplyToAndSeparate(flashcards, Flashcard.ShowFront);
        };

        /// <summary>
        /// The back of every flashcard in a given list.
        /// </summary>
        /// <param name="flashcards">list of flashcards</param>
        /// <returns>back of a card then a new line then the back of the next card, and so on</returns>
        public static Func<IList<Flashcard>, string> BackSummary =
        (flashcards) =>
        {
            return ApplyToAndSeparate(flashcards, Flashcard.ShowBack);
        };

        /// <summary>
        /// Convert the flashcards to a tab separated values format.
        /// </summary>
        public static Func<IList<Flashcard>, string> TabSeparatedValues =
        (flashcards) =>
        {
            return flashcards.Select((f1) => Flashcard.TabSeparatedValues(f1))
                             .DefaultIfEmpty(string.Empty)
                             .Aggregate((x, y) => x + y);
        };

        /// <summary>
        /// Convert tab separated values to a list of flashcards.
        /// </summary>
        /// <param name="contents">text with as many lines as there are flashcards.</param>
        /// <returns>a list of flashcards</returns>
        public static Func<string, IList<Flashcard>> FromTabSeparatedValues =
        (contents) =>
        {
            return contents
                   .Split(new char[] { '\n' })
                   .Where((line) => !string.IsNullOrEmpty(line))
                   .Select((line) => Flashcard.FromTabSeparatedValues(line))
                   .ToList();
        };
    }
}
