SELECT 
		c.Name,
		(SELECT COUNT(Id)
		FROM Reports
		WHERE StatusId IN (1, 2) AND CategoryId = (SELECT Id FROM Categories WHERE Name = c.Name)),
		--(SELECT COUNT(Id)
		--FROM Reports
		--WHERE StatusId = 1 AND CategoryId = (SELECT Id FROM Categories WHERE Name = c.Name)) AS Waiting,
		--(SELECT COUNT(Id)
		--FROM Reports
		--WHERE StatusId = 2 AND CategoryId = (SELECT Id FROM Categories WHERE Name = c.Name)) AS InProgress,
		CASE
			WHEN (SELECT COUNT(Id)
			FROM Reports
			WHERE StatusId = 1 AND CategoryId = (SELECT Id FROM Categories WHERE Name = c.Name))
			> 
			(SELECT COUNT(Id)
			FROM Reports
			WHERE StatusId = 2 AND CategoryId = (SELECT Id FROM Categories WHERE Name = c.Name))
			THEN 'waiting'
			WHEN (SELECT COUNT(Id)
			FROM Reports
			WHERE StatusId = 1 AND CategoryId = (SELECT Id FROM Categories WHERE Name = c.Name))
			< 
			(SELECT COUNT(Id)
			FROM Reports
			WHERE StatusId = 2 AND CategoryId = (SELECT Id FROM Categories WHERE Name = c.Name))
			THEN 'in progress'
			ELSE 'equal'

		END
	FROM Categories AS c
	JOIN Reports AS r ON r.CategoryId = c.Id
	JOIN Status AS s ON s.Id = r.StatusId
	WHERE s.Label IN ('waiting', 'in progress')
	GROUP BY c.Name
ORDER BY c.Name
