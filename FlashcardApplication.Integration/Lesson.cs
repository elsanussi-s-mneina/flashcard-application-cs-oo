using System;
using System.Collections.Generic;

namespace FlashcardApplication.Integration
{
    /// <summary>
    /// A lesson consists of flashcard data, and related functions.
    /// </summary>
    public class Lesson
    {

        /// <summary>
        /// The front and backs of every flashcard in a given list.
        /// </summary>
        /// <param name="flashcards"></param>
        /// <returns></returns>
        public string LessonSummary(IList<Flashcard> flashcards)
        {
            string result = string.Empty;
            foreach (Flashcard flashcard in flashcards)
            {
                result += flashcard + "\n";
            }

            return result;
        }

        /// <summary>
        /// The front of every flashcard in a given list.
        /// </summary>
        /// <param name="flashcards">list of flashcards</param>
        /// <returns>front of a card then a new line then the front of the next card, and so on</returns>
        public string FrontSummary(IList<Flashcard> flashcards)
        {
            string result = string.Empty;
            foreach (Flashcard flashcard in flashcards)
            {
                result += flashcard.ShowFront() + "\n";
            }

            return result;
        }

        /// <summary>
        /// The back of every flashcard in a given list.
        /// </summary>
        /// <param name="flashcards">list of flashcards</param>
        /// <returns>back of a card then a new line then the back of the next card, and so on</returns>
        public string BackSummary(IList<Flashcard> flashcards)
        {
            string result = string.Empty;
            foreach (Flashcard flashcard in flashcards)
            {
                result += flashcard.ShowBack() + "\n";
            }

            return result;
        }

        /// <summary>
        /// Convert the flashcards to a tab separated values format.
        /// </summary>
        public string TabSeparatedValues(IList<Flashcard> flashcards)
        {
            string result = string.Empty;
            foreach (Flashcard flashcard in flashcards)
            {
                result += flashcard.TabSeparatedValues();
            }
            return result;
        }

        /// <summary>
        /// Convert tab separated values to a list of flashcards.
        /// </summary>
        /// <param name="contents">text with as many lines as there are flashcards.</param>
        /// <returns>a list of flashcards</returns>
        public static IList<Flashcard> FromTabSeparatedValues(string contents)
        {
            var flashcards = new List<Flashcard>();
            if (string.IsNullOrEmpty(contents))
            {
                return flashcards;
            }
            string[] lines = contents.Split(new char[] {'\n'});

            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    flashcards.Add(Flashcard.FromTabSeparatedValues(line));
                }
            }
            return flashcards;
        }
    }
}
