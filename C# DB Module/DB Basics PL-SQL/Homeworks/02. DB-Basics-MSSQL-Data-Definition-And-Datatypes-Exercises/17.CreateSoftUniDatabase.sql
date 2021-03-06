CREATE DATABASE SoftUni

GO

USE SoftUni

CREATE TABLE Towns
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Name VARCHAR(30) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	AddressText VARCHAR(100) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Name VARCHAR(50) NOT NULL	
)

CREATE TABLE Employees
(
	Id INT IDENTITY PRIMARY KEY NOT NULL, 
	FirstName VARCHAR(50) NOT NULL, 
	MiddleName VARCHAR(50) NOT NULL, 
	LastName VARCHAR(50) NOT NULL, 
	JobTitle VARCHAR(50) NOT NULL, 
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id), 
	HireDate DATE NOT NULL, 
	Salary DECIMAL(10,2), 
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)