SELECT DISTINCT
		u.Username
	FROM Users AS u
	JOIN Reports AS r ON r.UserId = u.Id
	JOIN Categories AS c ON c.Id = r.CategoryId
	WHERE (LEFT(u.Username, 1) IN ('1', '2', '3', '4', '5', '6', '7', '8', '9', '0')
			AND CAST(c.Id AS NVARCHAR(5)) = LEFT(u.Username, 1))
			OR
			(RIGHT(u.Username, 1) IN ('1', '2', '3', '4', '5', '6', '7', '8', '9', '0')
			AND CAST(c.Id AS NVARCHAR(5)) = RIGHT(u.Username, 1))
ORDER BY u.Username