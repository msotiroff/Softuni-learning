SELECT
		a.AirportID,
		a.AirportName,
		COUNT(c.CustomerID) AS Passengers
	FROM Airports AS a
	JOIN Flights AS f ON f.OriginAirportID = a.AirportID
	JOIN Tickets AS t ON f.FlightID = t.FlightID
	JOIN Customers AS c ON t.CustomerID = c.CustomerID
	WHERE f.Status = 'Departing'
	GROUP BY a.AirportID, a.AirportName
	HAVING COUNT(c.CustomerID) > 0
ORDER BY a.AirportID