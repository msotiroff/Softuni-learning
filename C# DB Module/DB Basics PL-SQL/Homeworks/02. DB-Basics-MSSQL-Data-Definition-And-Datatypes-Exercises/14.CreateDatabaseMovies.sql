CREATE DATABASE Movies

GO

USE Movies

CREATE TABLE Directors
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	DirectorName VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Genres
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	GenreName VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Categories
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	CategoryName VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Movies
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Title VARCHAR(50) NOT NULL,
	DirectorId INT NOT NULL,
	FOREIGN KEY (DirectorId) REFERENCES Directors(Id),
	CopyrightYear INT NOT NULL,
	Length TIME,
	GenreId INT NOT NULL,
	FOREIGN KEY (GenreId) REFERENCES Genres(Id)
)

INSERT INTO Directors (DirectorName) 
VALUES 
('DIRECTOR_1'), 
('DIRECTOR_2'), 
('DIRECTOR_3'), 
('DIRECTOR_4'), 
('DIRECTOR_5') 

INSERT INTO Genres (GenreName)
VALUES
('Genre_1'),
('Genre_2'),
('Genre_3'),
('Genre_4'),
('Genre_5')

INSERT INTO Categories (CategoryName)
VALUES
('Categorie_1'),
('Categorie_2'),
('Categorie_3'),
('Categorie_4'),
('Categorie_5')

INSERT INTO Movies (Title, DirectorId, CopyrightYear, GenreId)
VALUES
('Silence of the lambs', 1, 1999, 1),
('Godfather', 2, 1996, 2),
('Red Dragon', 3, 2002, 1),
('Hannibal', 1, 2001, 1),
('The Proof', 4, 2010, 5)