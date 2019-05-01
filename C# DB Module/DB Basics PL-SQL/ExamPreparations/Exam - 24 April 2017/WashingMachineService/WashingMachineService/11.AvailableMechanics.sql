-- NOT COMPLETED!!!

SELECT
		CONCAT(m.FirstName, ' ', m.LastName) AS [Available]
	FROM Mechanics AS m
	LEFT JOIN Jobs AS j
	ON j.MechanicId = m.MechanicId
	WHERE m.MechanicId NOT IN (SELECT DISTINCT mech.MechanicId
			FROM Mechanics AS mech
			LEFT JOIN Jobs AS job ON job.MechanicId = mech.MechanicId
			WHERE job.Status <> 'Finished'
			GROUP BY mech.MechanicId)
	GROUP BY CONCAT(m.FirstName, ' ', m.LastName), j.MechanicId, m.MechanicId
ORDER BY m.MechanicId