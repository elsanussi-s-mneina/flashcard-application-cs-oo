using System;
using FlashcardApplication.Integration;

namespace flashcard_application_cs_oo
{
    class Program
    {
        static void Main(string[] args)
        {
            Greetings greetings = new Greetings();
            Console.WriteLine(greetings.WelcomeMessage);
            Console.WriteLine();
            Console.WriteLine("Printing Lesson summary:");
            Lesson lesson = new Lesson();
            Console.WriteLine(lesson.LessonSummary());
        }
    }
}
