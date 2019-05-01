SELECT 
		f.ProductId AS ProductId,
		f.Rate,
		f.Description,
		c.Id AS CustomerId,
		c.Age,
		c.Gender
	FROM Feedbacks AS f
	JOIN Customers AS c ON c.Id = f.CustomerId
	WHERE f.Rate < 5
ORDER BY f.ProductId DESC, f.Rate