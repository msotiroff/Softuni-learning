CREATE DATABASE Hotel

GO

CREATE TABLE Employees
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Title VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY NOT NULL,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	PhoneNumber VARCHAR(50) NOT NULL,
	EmergencyName VARCHAR(50),
	EmergencyNumber VARCHAR(50),
	Notes VARCHAR(MAX)
)

CREATE TABLE RoomStatus
(
	RoomStatus VARCHAR(30) PRIMARY KEY NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE RoomTypes 
(
	RoomType VARCHAR(30) PRIMARY KEY NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE BedTypes
(
	BedType VARCHAR(30) PRIMARY KEY NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY,
	RoomType VARCHAR(30) NOT NULL,
	BedType VARCHAR(30) NOT NULL,
	Rate INT,
	RoomStatus VARCHAR(30) NOT NULL,
	Notes NTEXT
)

CREATE TABLE Payments
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	PaymentDate DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	FirstDateOccupied DATE,
	LastDateOccupied DATE,
	TotalDays INT,
	AmountCharged DECIMAL(20, 2) NOT NULL,
	TaxRate DECIMAL,
	TaxAmount DECIMAL NOT NULL,
	PaymentTotal DECIMAL NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Occupancies
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	DateOccupied DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
	RateApplied DECIMAL,
	PhoneCharge DECIMAL,
	Notes VARCHAR(MAX)
)

INSERT INTO Employees VALUES('Gosho', 'Goshev', 'Receptionist', '.')
INSERT INTO Employees VALUES('Tosho', 'Toshev', 'Receptionist', '.')
INSERT INTO Employees VALUES('Pesho', 'Peshev', 'Receptionist', '.')
 
INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber) VALUES('123', 'Customer-2', 'tam', 'tam')
INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber) VALUES('125', 'Customer-3', 'tam', 'tam')
INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber) VALUES('122', 'Customer-1', 'tam', 'tam')
 
INSERT INTO RoomStatus VALUES('0', 'zaeta')
INSERT INTO RoomStatus VALUES('1', 'svobodna')
INSERT INTO RoomStatus VALUES('2', 'ss')
 
INSERT INTO RoomTypes VALUES('A', 'A')
INSERT INTO RoomTypes VALUES('B', 'B')
INSERT INTO RoomTypes VALUES('C', 'C')
 
INSERT INTO BedTypes VALUES('A', 'A')
INSERT INTO BedTypes VALUES('B', 'B')
INSERT INTO BedTypes VALUES('C', 'C')
 
INSERT INTO Rooms VALUES(1, 'B', '00', 1, 'xx', null)
INSERT INTO Rooms VALUES(2, 'A', '00', 1, 'xx', null)
INSERT INTO Rooms VALUES(3, 'C', '00', 1, 'xx', null)
 
INSERT INTO Payments (EmployeeID, PaymentDate, AccountNumber, AmountCharged, TaxAmount, PaymentTotal) VALUES(1, GETDATE(), 123, 1, 1, 1)
INSERT INTO Payments (EmployeeID, PaymentDate, AccountNumber, AmountCharged, TaxAmount, PaymentTotal) VALUES(2, GETDATE(), 122, 1, 1, 1)
INSERT INTO Payments (EmployeeID, PaymentDate, AccountNumber, AmountCharged, TaxAmount, PaymentTotal) VALUES(3, GETDATE(), 125, 1, 1, 1)

INSERT INTO Occupancies VALUES (1, GETDATE(), 123, 1, 1, NULL, NULL)
INSERT INTO Occupancies VALUES (2, GETDATE(), 122, 1, 1, NULL, NULL)
INSERT INTO Occupancies VALUES (3, GETDATE(), 125, 1, 1, NULL, NULL)