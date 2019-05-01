SELECT 
		CONCAT(e.FirstName, ' ', e.LastName) AS Name,

		CAST(COUNT(CASE
			WHEN YEAR(r.OpenDate) < 2016 AND YEAR(r.CloseDate) = 2016 THEN 1
			WHEN YEAR(r.OpenDate) = 2016 AND YEAR(r.CloseDate) = 2016 THEN 2
		END) AS VARCHAR(MAX))
		+ '/' +
		CAST(COUNT(CASE 
			WHEN YEAR(r.OpenDate) = 2016 AND r.CloseDate IS NULL THEN 1
			ELSE 0
		END) - 	COUNT(CASE
			WHEN YEAR(r.OpenDate) < 2016 AND YEAR(r.CloseDate) = 2016 THEN 1 END) AS VARCHAR(MAX))
	FROM Reports AS r
	JOIN Employees AS e ON e.Id = r.EmployeeId
	WHERE YEAR(r.OpenDate) = 2016 OR YEAR(r.CloseDate) = 2016
	GROUP BY CONCAT(e.FirstName, ' ', e.LastName), e.Id
	HAVING COUNT(CASE 
			WHEN YEAR(r.OpenDate) = 2016 AND r.CloseDate IS NULL THEN 1
			ELSE 0
		END) - 	COUNT(CASE
			WHEN YEAR(r.OpenDate) < 2016 AND YEAR(r.CloseDate) = 2016 THEN 1 END) > 0
ORDER BY Name, e.Id