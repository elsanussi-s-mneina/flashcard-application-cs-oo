We have to have a Flashcard.db file here to provide dummy data for the website.

Even though, a similar file is copied to the bin directory, for an ASP.NET Core project, it
looks for files in this directory FlashcardApplication.Web.ASP.
By way of contrast, the Console application will look for the database file in the bin directory.

I could have avoided this inconsistency by using absolute paths, but that would require
anyone who copied this project to their machine to move files around.

The fact that we have two copies of Flashcards.db is unfortunate, but is necessary
for convenience in the short term.
