SELECT
		c.CountryName,
		cont.ContinentName,
		COUNT(r.Id) AS [RiversCount],
		ISNULL(SUM(r.Length), 0) AS [TotalLenght]
	FROM Continents AS cont
	LEFT JOIN Countries AS c
	ON c.ContinentCode = cont.ContinentCode
	LEFT JOIN CountriesRivers AS cr
	ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers AS r
	ON r.Id = cr.RiverId
GROUP BY c.CountryName, cont.ContinentName
ORDER BY RiversCount DESC, TotalLenght DESC, c.CountryName ASC