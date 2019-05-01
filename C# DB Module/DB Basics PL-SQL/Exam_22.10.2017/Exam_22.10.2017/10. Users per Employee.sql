SELECT 
		CONCAT(e.FirstName, ' ', e.LastName) AS Name,
		ISNULL(COUNT(r.UserId), 0)AS [Users Number]
	FROM Employees AS e
	LEFT JOIN Reports AS r ON r.EmployeeId = e.Id
	GROUP BY CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY [Users Number] DESC, Name