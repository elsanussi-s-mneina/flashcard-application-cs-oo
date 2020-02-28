/* Script for creating table and inserting dummy data */
BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Flashcards" (
	"ID"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"FrontSide"	TEXT,
	"BackSide"	TEXT
);
INSERT INTO "Flashcards" ("ID","FrontSide","BackSide") VALUES (1,'we','nous');
INSERT INTO "Flashcards" ("ID","FrontSide","BackSide") VALUES (2,'under','sous');
COMMIT;

/*
This code was generated using Version 3.11.2 of DB Browser for SQLite.
*/