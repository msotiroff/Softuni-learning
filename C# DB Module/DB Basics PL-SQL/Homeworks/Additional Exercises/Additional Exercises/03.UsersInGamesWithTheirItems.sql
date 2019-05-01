SELECT 
		u.Username,
		g.Name AS [Game],
		COUNT(ugi.ItemId) AS [Items Count],
		SUM(i.Price) AS [Items Price]
	FROM Users AS u
	INNER JOIN UsersGames AS ug
	ON ug.UserId = u.Id
	INNER JOIN Games AS g
	ON g.Id = ug.GameId
	INNER JOIN UserGameItems AS ugi
	ON ugi.UserGameId = ug.Id
	INNER JOIN Items AS i
	ON i.Id = ugi.ItemId
GROUP BY u.Username, g.Name
HAVING COUNT(ugi.ItemId) > = 10
ORDER BY [Items Count] DESC, [Items Price] DESC, u.Username ASC