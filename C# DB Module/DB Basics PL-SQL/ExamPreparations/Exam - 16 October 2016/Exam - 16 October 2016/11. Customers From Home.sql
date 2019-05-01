SELECT 
		c.CustomerID,
		CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
		tow.TownName AS [Home Town]
	FROM Customers AS c
	JOIN Tickets AS t ON t.CustomerID = c.CustomerID
	JOIN Flights AS f ON f.FlightID = t.FlightID
	JOIN Airports AS a ON a.AirportID = f.OriginAirportID
	JOIN Towns AS tow ON tow.TownID = a.TownID
	WHERE tow.TownID = c.HomeTownID
	GROUP BY c.CustomerID, CONCAT(c.FirstName, ' ', c.LastName), tow.TownName
	ORDER BY c.CustomerID