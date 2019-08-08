using System;

namespace FlashcardApplication.Integration
{
    public class Flashcard
    {
        private readonly string front;
        private readonly string back;

        public Flashcard(string front, string back)
        {
            this.front = front;
            this.back = back;
        }

        /// <summary>
        /// The front and back of a single flashcard.
        /// </summary>
        public override string ToString()
        {
            return front + " | " + back;
        }

        public string ShowFront()
        {
            return front;
        }

        public string ShowBack()
        {
            return back;
        }

        /// <summary>
        /// Convert a flashcard to tab separated values.
        /// </summary>
        public string TabSeparatedValues()
        {
            return front + "\t"  + back + "\n";
        }


        public static Flashcard FromTabSeparatedValues(string line)
        {
            return FromParts(line.TrimEnd()
                                 .Split('\t'));
        }

        private static Flashcard FromParts(string[] parts)
        {
            return new Flashcard(ElementOrEmptyString(parts, 0),
                                 ElementOrEmptyString(parts, 1));
        }

        private static String ElementOrEmptyString(string[] parts, int index)
        {
            if (parts.Length > index)
                return parts[index];
            else
                return string.Empty;
        }
    }
}
