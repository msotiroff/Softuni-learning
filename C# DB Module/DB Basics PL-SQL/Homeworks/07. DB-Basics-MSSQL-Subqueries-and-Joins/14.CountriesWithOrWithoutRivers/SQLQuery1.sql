SELECT TOP 5
	c.CountryName,
	r.RiverName
FROM Countries AS c
	INNER JOIN Continents AS cnt
	ON cnt.ContinentCode = c.ContinentCode
	LEFT OUTER JOIN CountriesRivers AS cr
	ON cr.CountryCode = c.CountryCode
	LEFT OUTER JOIN Rivers AS r
	ON r.Id = cr.RiverId
WHERE cnt.ContinentName = 'Africa'
ORDER BY c.CountryName
