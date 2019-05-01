SELECT 
		c.CustomerID,
		CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
		DATEDIFF(YEAR, c.DateOfBirth, '2016') AS Age
	FROM Customers AS c
	JOIN Tickets AS t ON t.CustomerID = c.CustomerID
	JOIN Flights AS f ON f.FlightID = t.FlightID
	WHERE f.Status = 'Departing'
	GROUP BY c.CustomerID, CONCAT(c.FirstName, ' ', c.LastName), c.DateOfBirth
ORDER BY Age, c.CustomerID