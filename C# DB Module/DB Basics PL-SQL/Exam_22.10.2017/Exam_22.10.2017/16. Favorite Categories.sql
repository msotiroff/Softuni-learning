SELECT 
		d.Name,
		c.Name,
		CAST(ROUND(CAST(COUNT(c.Name) AS DECIMAL(10, 2))/ SUM(COUNT(d.Name)) OVER(PARTITION BY d.Name) * 100, 0) AS INT)
	FROM Departments AS d
	JOIN Categories AS c ON c.DepartmentId = d.Id
	JOIN Reports AS r ON r.CategoryId = c.Id
	GROUP BY d.Name, c.Name
ORDER BY d.Name, c.Name
