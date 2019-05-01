SELECT 
		curr.CurrencyCode,
		curr.Description,
		COUNT(c.CountryCode) AS [NumberOfCountries]
	FROM Countries AS c
	RIGHT JOIN Currencies AS curr
	ON curr.CurrencyCode = c.CurrencyCode
GROUP BY curr.CurrencyCode, curr.Description
ORDER BY NumberOfCountries DESC, curr.Description ASC