SELECT
		f.ProductId,
		CONCAT(c.FirstName, ' ', c.LastName) AS [CustomerName],
		f.Description AS [FeedbackDescription]
	FROM Feedbacks AS f
	JOIN Customers AS c ON c.Id = f.CustomerId
	WHERE f.CustomerId IN (SELECT TOP 100 PERCENT CustomerId FROM Feedbacks GROUP BY CustomerId HAVING COUNT(*) > 2 ORDER BY CustomerId )
	GROUP BY f.ProductId, CONCAT(c.FirstName, ' ', c.LastName), f.Description, f.Id
ORDER BY f.ProductId, [CustomerName], f.Id

	