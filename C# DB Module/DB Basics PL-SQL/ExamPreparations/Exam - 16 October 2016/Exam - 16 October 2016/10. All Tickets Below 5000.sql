SELECT	t.TicketID,
		a.AirportName AS Destination,
		CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName
			FROM Customers AS c
	JOIN Tickets AS t ON t.CustomerID = c.CustomerID
	JOIN Flights AS f ON f.FlightID = t.FlightID
	JOIN Airports AS a ON a.AirportID = f.DestinationAirportID
	GROUP BY t.TicketID, a.AirportName, CONCAT(c.FirstName, ' ', c.LastName), t.Price, t.Class
	HAVING t.Price < 5000 AND t.Class = 'First'