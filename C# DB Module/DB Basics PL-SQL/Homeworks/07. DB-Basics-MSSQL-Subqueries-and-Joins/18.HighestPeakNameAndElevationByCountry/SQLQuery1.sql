WITH PeaksAndMountains_CTE (CountryName, PeakName, Elevation, MountainRange) AS
(SELECT 
		c.CountryName AS Country,
		p.PeakName AS [Highest Peak Name],
		p.Elevation AS [Highest Peak Elevation],
		m.MountainRange AS Mountain
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
	ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains AS m
	ON m.Id = mc.MountainId
	LEFT JOIN Peaks AS p
	ON p.MountainId = mc.MountainId)

SELECT TOP 5
		TopElevations.CountryName,
		ISNULL(PAM.PeakName, '(no highest peak)') AS [Highest Peak Name],
		ISNULL(TopElevations.MaxElevation, '0') AS [Highest Peak Elevation],
		ISNULL(PAM.MountainRange, '(no mountain)') AS Mountain
	FROM
		(
			SELECT 
					CountryName,
					MAX(Elevation) AS MaxElevation
				FROM PeaksAndMountains_CTE
				GROUP BY CountryName
		) AS TopElevations
	LEFT OUTER JOIN PeaksAndMountains_CTE AS PAM
	ON	PAM.CountryName = TopElevations.CountryName
		AND PAM.Elevation = TopElevations.MaxElevation
ORDER BY CountryName, MaxElevation