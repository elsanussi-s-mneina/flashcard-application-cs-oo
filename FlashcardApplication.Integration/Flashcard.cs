using System;

namespace FlashcardApplication.Integration
{
    public class Flashcard
    {
        private string front;
        private string back;

        public Flashcard(string front, string back)
        {
            this.front = front;
            this.back = back;
        }

        public int ID { get; set; }

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

            return new Flashcard(front, back);
        }
    }
}
