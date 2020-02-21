using System;

namespace FlashcardApplication.Integration
{
    public class Flashcard
    {
        public readonly string front;
        public readonly string back;

        public Flashcard(string front, string back)
        {
            this.front = front;
            this.back = back;
        }

        /// <summary>
        /// The front and back of a single flashcard.
        /// </summary>
        public static Func<Flashcard, string> ShowBothSides =
        (flashcard) =>
        {
            return flashcard.front + " | " + flashcard.back;
        };


        public static Func<Flashcard, string> ShowFront =
        (flashcard) =>
        {
            return flashcard.front;
        };

        public static Func<Flashcard, string> ShowBack =
        (flashcard) =>
        {
            return flashcard.back;
        };

        /// <summary>
        /// Convert a flashcard to tab separated values.
        /// </summary>
        public static Func<Flashcard, string> TabSeparatedValues =
        (flashcard) =>
        {
            return flashcard.front + "\t" + flashcard.back + "\n";
        };


        public static Func<string, Flashcard> FromTabSeparatedValues =
        (line) =>
        {
            return FromParts(line.TrimEnd()
                                 .Split('\t'));
        };

        private static Func<string[], Flashcard> FromParts =
        (parts) =>
        {
            return new Flashcard(ElementOrEmptyString(parts, 0),
                                 ElementOrEmptyString(parts, 1));
        };

        private static Func<string[], int, String> ElementOrEmptyString =
        (parts, index) =>
        {
            if (parts.Length > index)
                return parts[index];
            else
                return string.Empty;
        };
    }
}
