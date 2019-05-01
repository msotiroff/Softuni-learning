SELECT TOP 1 WITH TIES
		c.Name AS [CountryName],
		AVG(f.Rate) AS [FeedbackRate]
	FROM Countries AS c
	JOIN Customers AS cust ON cust.CountryId = c.Id
	JOIN Feedbacks AS f ON f.CustomerId = cust.Id
	GROUP BY c.Name
ORDER BY FeedbackRate DESC