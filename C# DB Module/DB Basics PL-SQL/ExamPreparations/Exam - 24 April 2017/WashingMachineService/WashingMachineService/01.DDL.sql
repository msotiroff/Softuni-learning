--CREATE DATABASE WMS

--USE WMS

CREATE TABLE Clients 
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL
)

CREATE TABLE Mechanics
(
	MechanicId INT IDENTITY PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Address VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
	ModelId INT IDENTITY PRIMARY KEY,
	Name VARCHAR(50) UNIQUE  NOT NULL
)

CREATE TABLE Jobs
(
	JobId INT IDENTITY PRIMARY KEY,
	ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
	Status VARCHAR(11) CHECK(Status = 'Pending' OR Status = 'In Progress' OR Status = 'Finished') DEFAULT 'Pending' NOT NULL,
	ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 0 NOT NULL
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	Description VARCHAR(255),
	Price MONEY CHECK(Price > 0 AND Price <= 9999.99) NOT NULL,
	VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId),
	StockQty INT NOT NULL CHECK(StockQty >= 0) DEFAULT 0
)

CREATE TABLE OrderParts
(
	OrderId INT FOREIGN KEY REFERENCES Orders(OrderId),
	PartId INT FOREIGN KEY REFERENCES Parts(PartId),
	Quantity INT CHECK(Quantity > 0) DEFAULT 1,
	CONSTRAINT PK_OrdersParts PRIMARY KEY (OrderId, PartId)
)

CREATE TABLE PartsNeeded
(
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId),
	PartId INT FOREIGN KEY REFERENCES Parts(PartId),
	Quantity INT CHECK(Quantity > 0) DEFAULT 1,
	CONSTRAINT PK_JobsParts PRIMARY KEY (JobId, PartId)
)