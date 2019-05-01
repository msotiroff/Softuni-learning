--USE SoftUni

--CREATE TABLE Deleted_Employees
--(
--	EmployeeId INT PRIMARY KEY IDENTITY,
--	FirstName VARCHAR(50) NOT NULL,
--	LastName VARCHAR(50) NOT NULL,
--	MiddleName VARCHAR(50),
--	JobTitle VARCHAR(50) NOT NULL,
--	DeparmentId INT NOT NULL, 
--	Salary MONEY NOT NULL
--)

--GO

CREATE TRIGGER tr_DeleteEmployee ON Employees FOR DELETE
AS
BEGIN
	INSERT INTO Deleted_Employees
		SELECT 
			FirstName,
			LastName,
			MiddleName,
			JobTitle,
			DepartmentID,
			Salary
		FROM deleted
END