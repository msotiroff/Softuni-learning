WITH CTE_RankingByCountry
AS
(SELECT 
			c.Name AS CountryName, 
			d.Name AS DistributorName,
			COUNT(i.Id) AS IngredientsCount,
			DENSE_RANK() OVER (PARTITION BY c.Name ORDER BY COUNT(i.Id) DESC) AS DistrRank
		FROM Countries AS c
	JOIN Distributors AS d ON d.CountryId = c.Id
	JOIN Ingredients AS i ON i.DistributorId = d.Id
	GROUP BY d.Name, c.Name)

SELECT
		CountryName,
		DistributorName
	FROM CTE_RankingByCountry
	WHERE DistrRank = 1
ORDER BY CountryName, DistributorName