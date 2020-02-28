using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace FlashcardApplication.Integration
{
    public class DatabaseBridge
    {
        private string connectionString = "data source=Flashcards.db";
        // To do: move connectionString into a configuration file.

        public DatabaseBridge()
        {
        }

        public IList<Flashcard> GetFlashcards()
        {
            SQLiteConnection connection = new SQLiteConnection();
            // Create an SQL connection

            // Set the connection string to 
            connection.ConnectionString = connectionString;
            connection.Open();
            Console.WriteLine("Connection file name: " + connection.FileName);
            // Create an SQL Command.
            SQLiteCommand command = new SQLiteCommand();


            // Fill SQL command parameters.
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT FrontSide, BackSide FROM Flashcards;";


            // Execute the command.
            SQLiteDataReader dataReader = command.ExecuteReader();
            // Read data and show to the console.

            // Read data and show to the console

            IList<Flashcard> flashcards = new List<Flashcard>();
            while (dataReader.Read())
            {
                Console.WriteLine("FrontSide: " +
                    dataReader.GetString(0) + ", BackSide: " +
                    dataReader.GetString(1));
                flashcards.Add(new Flashcard(dataReader.GetString(0), dataReader.GetString(1)));
            }

            connection.Close();
            Console.Write(connection.State);

            return flashcards;
        }

        public void AddFlashcard(Flashcard addition)
        {
            SQLiteConnection connection = new SQLiteConnection();
            // Create an SQL connection

            // Set the connection string to 
            connection.ConnectionString = connectionString;
            connection.Open();

            // Create an SQL Command
            SQLiteCommand insertCommand = new SQLiteCommand();

            // Fill SQL command parameters.
            insertCommand.Connection = connection;
            insertCommand.CommandType = System.Data.CommandType.Text;
            insertCommand.CommandText = "INSERT INTO Flashcards (FrontSide, BackSide) VALUES('"
                + addition.ShowFront()
                + "', '"
                + addition.ShowBack()
                + "');";
            addition.ShowBack();
            addition.ShowFront();
            // Execute the command.
            insertCommand.ExecuteNonQuery();


            connection.Close();
            Console.Write(connection.State);
        }
    }
}
