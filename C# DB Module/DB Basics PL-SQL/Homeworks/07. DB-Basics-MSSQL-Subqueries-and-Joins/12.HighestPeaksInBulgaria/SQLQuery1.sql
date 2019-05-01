SELECT 
		c.CountryCode,
		m.MountainRange,
		p.PeakName,
		p.Elevation
FROM Countries AS c
	INNER JOIN MountainsCountries AS mc
	ON mc.CountryCode = c.CountryCode
	INNER JOIN Peaks AS p
	ON p.MountainId = mc.MountainId
	AND p.Elevation > 2835
	INNER JOIN Mountains AS m
	ON m.Id = mc.MountainId
WHERE c.CountryName = 'Bulgaria'
ORDER BY p.Elevation DESC