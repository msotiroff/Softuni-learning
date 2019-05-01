SELECT 
	e.FirstName,
	e.LastName,
	e.HireDate,
	d.Name AS DeptName
FROM Employees AS e
	INNER JOIN Departments AS d
	ON d.DepartmentID = e.DepartmentID
	AND d.Name IN ('Sales', 'Finance')
	AND e.HireDate > '19990101'
ORDER BY e.HireDate