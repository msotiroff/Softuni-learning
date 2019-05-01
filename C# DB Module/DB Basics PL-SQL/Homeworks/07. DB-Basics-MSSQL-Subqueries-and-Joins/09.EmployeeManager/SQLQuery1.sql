SELECT 
		e.EmployeeID,
		e.FirstName,
		e.ManagerID,
		e1.FirstName
	FROM Employees AS e
	INNER JOIN Employees AS e1
	ON e1.EmployeeID = e.ManagerID
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID