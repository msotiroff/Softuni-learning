SELECT 
		c.Name
	FROM Categories AS c
	JOIN Reports AS r ON r.CategoryId = c.Id
	JOIN Users AS u ON u.Id = r.UserId
	WHERE DAY(u.BirthDate) = DAY(r.OpenDate) AND MONTH(u.BirthDate) = MONTH(r.OpenDate)
	GROUP BY c.Name
ORDER BY c.Name