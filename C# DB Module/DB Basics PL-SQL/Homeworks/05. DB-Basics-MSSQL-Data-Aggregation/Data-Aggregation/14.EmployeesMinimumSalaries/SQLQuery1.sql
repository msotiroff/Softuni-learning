SELECT
	DepartmentID,
	MIN(Salary) AS [MinimumSalary]
FROM Employees
WHERE (DepartmentID = 2 OR DepartmentID = 5 OR DepartmentID = 7) AND (HireDate > '20000101')
GROUP BY DepartmentID