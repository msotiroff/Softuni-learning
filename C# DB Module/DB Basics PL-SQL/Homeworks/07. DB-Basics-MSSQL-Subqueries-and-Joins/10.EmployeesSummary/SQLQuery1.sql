SELECT TOP 50 
		e.EmployeeID,
		e.FirstName + ' ' + e.LastName AS EmployeeName,
		e1.FirstName + ' ' + e1.LastName AS ManagerName,
		d.Name AS DepartmentName
	FROM Employees AS e
	INNER JOIN Employees AS e1
	ON e1.EmployeeID = e.ManagerID
	INNER JOIN Departments AS d
	ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID