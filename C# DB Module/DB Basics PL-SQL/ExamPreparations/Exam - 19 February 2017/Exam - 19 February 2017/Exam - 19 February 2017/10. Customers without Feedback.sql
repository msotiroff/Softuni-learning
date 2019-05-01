SELECT
		CONCAT(c.FirstName, ' ', c.LastName) AS [CustomerName],
		c.PhoneNumber,
		c.Gender
	FROM Feedbacks AS f
	RIGHT JOIN Customers AS c ON c.Id = f.CustomerId
	WHERE f.CustomerId IS NULL
ORDER BY c.Id ASC