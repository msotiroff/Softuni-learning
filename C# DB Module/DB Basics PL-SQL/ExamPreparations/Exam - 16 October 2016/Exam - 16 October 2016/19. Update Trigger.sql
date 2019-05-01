--CREATE TABLE ArrivedFlights
--(
--	FlightID INT PRIMARY KEY NOT NULL,
--	ArrivalTime DATETIME NOT NULL,
--	Origin VARCHAR(50) NOT NULL,
--	Destination VARCHAR(50) NOT NULL,
--	Passengers INT NOT NULL
--)

CREATE TRIGGER tr_ArrivedFlights ON Flights
FOR UPDATE
AS
BEGIN

	INSERT INTO ArrivedFlights (FlightID, ArrivalTime, Origin, Destination, Passengers)
	(
		SELECT	i.FlightID, 
				i.ArrivalTime, 
				a.AirportName, 
				aDest.AirportName,
				ISNULL(COUNT(t.CustomerID), 0)
			FROM Flights AS f
			JOIN deleted AS d ON d.FlightID = f.FlightID
			JOIN inserted AS i ON i.FlightID = f.FlightID
			JOIN Airports AS a ON a.AirportID = i.OriginAirportID
			JOIN Airports AS aDest ON aDest.AirportID = i.DestinationAirportID
			LEFT JOIN Tickets AS t ON t.FlightID = f.FlightID
			WHERE i.Status = 'Arrived'
			GROUP BY i.FlightID, i.ArrivalTime, a.AirportName, aDest.AirportName
		)
END

--BEGIN TRAN
--	UPDATE Flights
--	SET Status = 'Arrived' WHERE FlightID = 1 -- Flight with valid status
--ROLLBACK

--BEGIN TRAN
--	UPDATE Flights
--	SET Status = 'Arrived' WHERE FlightID = 6 -- Flight with invalid status
--ROLLBACK

--BEGIN TRAN
--	UPDATE Flights
--	SET Status = 'Arrived' WHERE FlightID IN (1, 2, 3, 4) -- Multiple update
--ROLLBACK