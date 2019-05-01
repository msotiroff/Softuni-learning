SELECT
		m.FirstName + ' ' + m.LastName AS [Mechanic],
		COUNT(j.JobId) AS [Jobs]
	FROM Mechanics AS m
	INNER JOIN Jobs AS j
	ON j.MechanicId = m.MechanicId
GROUP BY m.FirstName, m.LastName, m.MechanicId, j.Status
HAVING j.Status <> 'Finished' AND COUNT(j.JobId) > 1
ORDER BY Jobs DESC