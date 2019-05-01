SELECT TOP 5
		f.FlightID,
		f.DepartureTime,
		f.ArrivalTime,
		(SELECT AirportName FROM Airports WHERE AirportID = f.OriginAirportID) AS Origin,
		(SELECT AirportName FROM Airports WHERE AirportID = f.DestinationAirportID) AS Destination
	FROM Flights AS f
	JOIN Airports AS a ON a.AirportID = f.DestinationAirportID
	JOIN (SELECT TOP 5 FlightID FROM Flights 
			WHERE Status = 'Departing' 
			ORDER BY DepartureTime DESC) AS LastFive ON LastFive.FlightID = f.FlightID
	WHERE f.Status = 'Departing'
ORDER BY f.DepartureTime, f.FlightID