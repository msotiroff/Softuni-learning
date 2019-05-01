SELECT 
		r.OpenDate,
		r.Description,
		u.Email
	FROM Reports AS r
	JOIN Categories AS c ON c.Id = r.CategoryId
	JOIN Departments AS d ON d.Id = c.DepartmentId
	JOIN Users AS u ON u.Id = r.UserId
	WHERE d.Name IN ('Infrastructure', 'Emergency', 'Roads Maintenance')
			AND r.CloseDate IS NULL
			AND (LEN(r.Description) > 20)
			AND r.Description LIKE '%str%'
ORDER BY r.OpenDate, u.Email

	