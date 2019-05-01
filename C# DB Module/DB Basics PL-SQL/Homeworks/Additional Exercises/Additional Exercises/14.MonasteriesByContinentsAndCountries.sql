UPDATE Countries
SET CountryName = 'Burma' WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries VALUES 
('Hanga Abbey', (SELECT CountryCode FROM Countries WHERE CountryName = 'Tanzania')),
('Myin-Tin-Daik', (SELECT CountryCode FROM Countries WHERE CountryName = 'Myanmar'))

SELECT 
		cont.ContinentName,
		c.CountryName,
		COUNT(m.Id) AS [MonasteriesCount]
	FROM Continents AS cont
	LEFT JOIN Countries AS c
	ON c.ContinentCode = cont.ContinentCode AND c.IsDeleted = 0
	LEFT JOIN Monasteries AS m
	ON m.CountryCode = c.CountryCode
GROUP BY cont.ContinentName, c.CountryName
ORDER BY MonasteriesCount DESC, c.CountryName ASC