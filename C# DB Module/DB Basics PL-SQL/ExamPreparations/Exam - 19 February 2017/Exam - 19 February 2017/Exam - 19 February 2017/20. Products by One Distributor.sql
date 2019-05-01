SELECT 
  OuterTable.ProductName, 
  OuterTable.ProductAvgRate AS ProductAverageRate, 
  OuterTable.DistributorName, 
  OuterTable.DistributorCountry
FROM (
  SELECT 
    p.Name AS ProductName, AVG(f.Rate) AS ProductAvgRate,
    d.Name AS DistributorName, c.Name AS DistributorCountry
  FROM (
		SELECT p.Id
		  FROM Products p
		  JOIN ProductsIngredients prodingr ON prodingr.ProductId = p.Id
		  JOIN Ingredients i ON i.Id = prodingr.IngredientId
		  JOIN Distributors d ON d.Id = i.DistributorId
	 GROUP BY p.Id
	HAVING COUNT(DISTINCT(i.DistributorId)) = 1
  ) AS InnerTable
  JOIN Products AS p ON p.Id = InnerTable.Id
  JOIN ProductsIngredients AS pi ON pi.ProductId = p.Id
  JOIN Ingredients AS i ON pi.IngredientId = i.Id
  JOIN Distributors AS d ON d.Id = i.DistributorId
  JOIN Countries AS c ON d.CountryId = c.Id
  JOIN Feedbacks AS f ON p.Id = f.ProductId
  GROUP BY p.Name, d.Name, c.Name
) AS OuterTable
JOIN Products ON Products.Name = OuterTable.ProductName
ORDER BY Products.Id