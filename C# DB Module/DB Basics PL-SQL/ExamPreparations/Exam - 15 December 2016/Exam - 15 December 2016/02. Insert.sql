INSERT INTO Messages
SELECT 
		CONCAT(u.Age, '-', u.Gender, '-', l.Latitude, '-',  l.Longitude),
		GETDATE(),
		CASE
			WHEN u.Gender = 'F' THEN CEILING(SQRT(2 * u.Age))
			WHEN u.Gender = 'M' THEN CEILING(POWER(u.Age / 18, 3))
		END,
		u.Id
	FROM Users AS u
	JOIN Locations AS l ON l.Id = u.LocationId
	WHERE u.Id BETWEEN 10 AND 20


SELECT 
		*
	FROM Users AS u
	JOIN Locations AS l ON l.Id = u.LocationId