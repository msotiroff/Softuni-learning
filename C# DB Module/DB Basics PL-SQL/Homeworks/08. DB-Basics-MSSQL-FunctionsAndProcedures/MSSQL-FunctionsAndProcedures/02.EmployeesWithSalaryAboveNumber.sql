CREATE PROCEDURE dbo.usp_GetEmployeesSalaryAboveNumber @NeededSalary DECIMAL(18, 4)
AS
SELECT 
		FirstName,
		LastName
	FROM Employees
	WHERE Salary >= @NeededSalary