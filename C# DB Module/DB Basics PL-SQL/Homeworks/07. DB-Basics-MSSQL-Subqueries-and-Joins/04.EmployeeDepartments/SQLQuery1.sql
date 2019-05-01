SELECT TOP 5
	e.EmployeeID,
	e.FirstName,
	e.Salary,
	d.Name
FROM Employees AS e
INNER JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID