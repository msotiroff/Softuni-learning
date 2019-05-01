SELECT 
		c.Name AS [CategoryName],
		COUNT(e.Id) AS [Employees Number]
	FROM Categories AS c
	JOIN Departments AS d ON d.Id = c.DepartmentId
	JOIN Employees AS e ON e.DepartmentId = d.Id
	GROUP BY c.Name
ORDER BY c.Name