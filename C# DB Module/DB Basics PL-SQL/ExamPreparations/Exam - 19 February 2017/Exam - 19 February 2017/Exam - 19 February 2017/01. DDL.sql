--CREATE DATABASE Bakery

--GO

--USE Bakery

CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(25) UNIQUE,
	Description NVARCHAR(250),
	Recipe NVARCHAR(MAX),
	Price MONEY CHECK(Price > 0)
)

CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) UNIQUE
)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Gender CHAR(1) CHECK(Gender IN('M', 'F')),
	Age	INT,
	PhoneNumber CHAR(10),
	CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Feedbacks
(
	Id INT PRIMARY KEY IDENTITY,
	Description NVARCHAR(255),
	Rate DECIMAL(4, 2) CHECK(Rate >= 0 AND Rate <= 10),
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id)
)

CREATE TABLE Distributors
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(25) UNIQUE,
	AddressText NVARCHAR(30),
	Summary NVARCHAR(200),
	CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Ingredients
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(30),
	Description NVARCHAR(200),
	OriginCountryId INT FOREIGN KEY REFERENCES Countries(Id),
	DistributorId INT FOREIGN KEY REFERENCES Distributors(Id),
)

CREATE TABLE ProductsIngredients
(
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	IngredientId INT FOREIGN KEY REFERENCES Ingredients(Id),
	CONSTRAINT PK_ProductsIngredients PRIMARY KEY(ProductId, IngredientId)
)
