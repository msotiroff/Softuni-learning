SELECT TOP 3
		c.CustomerID,
		CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
		t.Price AS TicketPrice,
		a.AirportName AS Destination
	FROM Customers AS c
	JOIN Tickets AS t ON t.CustomerID = c.CustomerID
	JOIN Flights AS f ON f.FlightID = t.FlightID
	JOIN Airports AS a ON a.AirportID = f.DestinationAirportID
	WHERE f.Status = 'Delayed'
	GROUP BY c.CustomerID, CONCAT(c.FirstName, ' ', c.LastName), t.Price, a.AirportName
ORDER BY t.Price DESC, c.CustomerID