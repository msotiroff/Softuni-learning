SELECT
		m.FirstName + ' ' + m.LastName AS [Mechanic],
		CAST(AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS INT)
	FROM Mechanics AS m
	INNER JOIN Jobs AS j
	ON j.MechanicId = m.MechanicId AND j.FinishDate IS NOT NULL
GROUP BY m.FirstName, m.LastName, m.MechanicId
ORDER BY m.MechanicId