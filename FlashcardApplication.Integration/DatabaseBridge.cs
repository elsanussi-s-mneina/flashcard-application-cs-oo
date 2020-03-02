using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace FlashcardApplication.Integration
{
    public class DatabaseBridge : IDatabaseBridge
    {
        private string connectionString = "data source=Flashcards.db";
        // To do: move connectionString into a configuration file.

        public DatabaseBridge()
        {
        }

        public IList<Flashcard> GetFlashcards()
        {
            SQLiteConnection connection = new SQLiteConnection
            {
                ConnectionString = connectionString
            };
            connection.Open();

            // Create an SQL Command.
            SQLiteCommand command = new SQLiteCommand();


            // Fill SQL command parameters.
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT ID, FrontSide, BackSide FROM Flashcards;";


            // Execute the command.
            SQLiteDataReader dataReader = command.ExecuteReader();
            // Read data and show to the console.

            // Read data and show to the console

            IList<Flashcard> flashcards = new List<Flashcard>();
            while (dataReader.Read())
            {
                var flashcard = new Flashcard(dataReader.GetString(1), dataReader.GetString(2));
                flashcard.ID = dataReader.GetInt32(0);
                flashcards.Add(flashcard);
            }

            connection.Close();

            return flashcards;
        }

        public void AddFlashcard(Flashcard addition)
        {
            SQLiteConnection connection = new SQLiteConnection
            {
                ConnectionString = connectionString
            };
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
        }

        public void DeleteFlashcard(Flashcard target)
        {
            SQLiteConnection connection = new SQLiteConnection
            {
                ConnectionString = connectionString
            };
            connection.Open();

            // Create an SQL Command
            SQLiteCommand deleteCommand = new SQLiteCommand();

            // Fill SQL command parameters.
            deleteCommand.Connection = connection;
            deleteCommand.CommandType = System.Data.CommandType.Text;
            deleteCommand.CommandText = "DELETE FROM Flashcards WHERE ID ='"
                + target.ID
                + "';";
            // Execute the command.
            deleteCommand.ExecuteNonQuery();


            connection.Close();

        }
    }
}
