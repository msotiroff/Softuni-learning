CREATE DATABASE CarRental

GO

USE CarRental

CREATE TABLE Categories 
(
	Id INT IDENTITY PRIMARY KEY,
	CategoryName VARCHAR(50) NOT NULL,
	DailyRate DECIMAL NOT NULL,
	WeeklyRate DECIMAL NOT NULL,
	MonthlyRate DECIMAL NOT NULL,
	WeekendRate DECIMAL NOT NULL
)

CREATE TABLE Cars
(
	Id INT IDENTITY PRIMARY KEY,
	PlateNumber VARCHAR(20) NOT NULL,
	Manufacturer VARCHAR(50) NOT NULL,
	Model VARCHAR(50) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT NOT NULL
	FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
	Doors INT NOT NULL,
	Picture VARBINARY(MAX),
	Condition VARCHAR(MAX),
	Available BIT
)

CREATE TABLE Employees
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Title VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Customers
(
	Id INT IDENTITY PRIMARY KEY,
	DriverLicenceNumber VARCHAR(50) NOT NULL,
	FullName VARCHAR(100) NOT NULL,
	Address VARCHAR(MAX) NOT NULL,
	City VARCHAR(50) NOT NULL,
	ZIPCode VARCHAR(20),
	Notes VARCHAR(MAX)
)

CREATE TABLE RentalOrders
(
	Id INT IDENTITY PRIMARY KEY,
	EmployeeId INT NOT NULL,
	FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
	CustomerId INT NOT NULL,
	FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
	CarId INT NOT NULL,
	FOREIGN KEY (CarId) REFERENCES Cars(Id),
	TankLevel FLOAT(2) NOT NULL,
	KilometrageStart FLOAT(2) NOT NULL,
	KilometrageEnd FLOAT(2) NOT NULL,
	TotalKilometrage FLOAT(2) NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied DECIMAL NOT NULL,
	TaxRate DECIMAL NOT NULL,
	OrderStatus VARCHAR NOT NULL,
	Notes VARCHAR(MAX)
)

GO

INSERT INTO Categories
VALUES
('Compact', 50.20, 300, 980.60, 120.30),
('Middle', 60.5, 330.5, 1005.35, 150),
('Limosine', 80, 520.99, 1999.99, 199.99)

GO

INSERT INTO Cars
VALUES
('PA6900BP', 'Mercedes-Benz', 'E-Class', 1999, 2, 5, NULL, NULL, NULL),
('PA6900BP', 'Mercedes-Benz', 'E220', 1994, 2, 4, NULL, NULL, NULL),
('PA4089BP', 'Mercedes-Benz', '200D', 1989, 2, 4, NULL, NULL, NULL)

INSERT INTO Employees (FirstName, LastName, Title)
VALUES
('Mihail', 'Sotirov', 'Owner'),
('Ivan', 'Ivanov', 'Sales Rep'),
('VEntzislav', 'Tzoklinov', 'Team Leader')

INSERT INTO Customers (DriverLicenceNumber, FullName, Address, City)
VALUES
(123456789, 'Iordan Dimov', 'Angel Kanchev 22', 'Pazardjik'),
(123456789, 'Dimitar Ribarov', 'Angel Kanchev 22', 'Pazardjik'),
(123456789, 'Stefan Stoychev', 'Parva 22', 'Unacite')

GO

INSERT INTO RentalOrders
VALUES
(1, 1, 1, 35, 196500, 196900, 400, '2017-05-05', '2017-05-10', 5, 500.96, 100.19, 1, NULL),
(1, 1, 1, 35, 197000, 198500, 1500, '2017-05-12', '2017-05-18', 6, 500.96, 100.19, 1, NULL),
(2, 2, 2, 50, 318000, 320000, 2000, '2017-05-05', '2017-05-10', 5, 500.96, 100.19, 1, NULL)