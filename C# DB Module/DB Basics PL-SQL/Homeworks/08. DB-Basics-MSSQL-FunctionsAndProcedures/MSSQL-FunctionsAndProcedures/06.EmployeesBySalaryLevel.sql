CREATE PROC dbo.usp_EmployeesBySalaryLevel (@SalaryLevel VARCHAR(10))

AS

SELECT 
	FirstName,
	LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) LIKE @SalaryLevel