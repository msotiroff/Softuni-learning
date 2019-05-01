SELECT 
			COUNT(*) AS CountyCode
	FROM
	(SELECT 
			c.CountryCode,
			mc.MountainId
		FROM Countries AS c
			LEFT JOIN MountainsCountries AS mc
			ON mc.CountryCode = c.CountryCode
		WHERE mc.MountainId IS NULL) AS NoMountainCountryCount

-- One more solution --

SELECT
		COUNT(c.CountryCode) AS CountryCode
	FROM Countries AS c
		LEFT JOIN MountainsCountries AS m 
		ON c.CountryCode = m.CountryCode
WHERE m.MountainId IS NULL