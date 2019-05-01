SELECT TOP 10
	FirstName,
	LastName,
	DepartmentID
FROM Employees AS e1
WHERE Salary > (
					SELECT 
						AVG(Salary)
					FROM Employees AS e2
					WHERE e1.DepartmentID = e2.DepartmentID
				)
ORDER BY DepartmentID