WITH CTE (ProductID, AverageRate)
AS
(SELECT 
		f.ProductId,
		AVG(ISNULL(f.Rate, 0)) AS [Average Rate]
	FROM Feedbacks AS f
	GROUP BY f.ProductId
	HAVING AVG(ISNULL(f.Rate, 0)) BETWEEN 5 AND 8)


SELECT
		d.Name AS [DistributorName],
		i.Name AS [IngredientName],
		p.Name AS [ProductName],
		CTE.AverageRate AS [AverageRate]
	FROM ProductsIngredients AS pi
	JOIN Ingredients AS i ON i.Id = pi.IngredientId
	JOIN Distributors AS d ON d.Id = i.DistributorId
	JOIN Products AS p ON p.Id = pi.ProductId
	JOIN CTE ON CTE.ProductID = pi.ProductId
WHERE p.Id IN (CTE.ProductID)
ORDER BY DistributorName, IngredientName, ProductName