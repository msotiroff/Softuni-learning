SELECT 
		u.Nickname,
		c.Title,
		l.Latitude,
		l.Longitude
	FROM Locations AS l
	JOIN Users AS u ON u.LocationId = l.Id
	JOIN UsersChats AS uc ON uc.UserId = u.Id
	RIGHT JOIN Chats AS c ON c.Id = uc.ChatId
	WHERE (CAST(l.Latitude AS NUMERIC(38, 18)) BETWEEN 41.14 AND 44.13) 
	AND (CAST(l.Longitude AS NUMERIC(38, 18)) BETWEEN 22.21 AND 28.36)
ORDER BY c.Title