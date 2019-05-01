CREATE PROCEDURE dbo.usp_GetEmployeesSalaryAbove35000
AS
	SELECT 
			e.FirstName,
			e.LastName
		FROM Employees AS e
		WHERE Salary > 35000