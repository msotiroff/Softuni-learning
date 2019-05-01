SELECT 
		p.PeakName,
		m.MountainRange AS [Mountain],
		c.CountryName,
		cont.ContinentName
	FROM Countries AS c
	INNER JOIN Continents AS cont
	ON cont.ContinentCode = c.ContinentCode
	RIGHT JOIN MountainsCountries AS mc
	ON mc.CountryCode = c.CountryCode
	INNER JOIN Mountains AS m
	ON m.Id = mc.MountainId
	INNER JOIN Peaks AS p
	ON p.MountainId = m.Id
ORDER BY p.PeakName ASC, c.CountryName ASC