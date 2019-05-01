--USE Diablo

SELECT 
		u.Username,
		g.Name AS [Game],
		MAX(ch.Name) AS Character,
		MAX(statch.Strength) + MAX(statgt.Strength) + SUM(stati.Strength) AS Strength, 
		MAX(statch.Defence) + MAX(statgt.Defence) + SUM(stati.Defence) AS Defence, 
		MAX(statch.Speed) + MAX(statgt.Speed) + SUM(stati.Speed) AS Speed, 
		MAX(statch.Mind) + MAX(statgt.Mind) + SUM(stati.Mind) AS Mind, 
		MAX(statch.Luck) + MAX(statgt.Luck) + SUM(stati.Luck) AS Luck
	FROM Users AS u
	INNER JOIN UsersGames AS ug
	ON ug.UserId = u.Id
	INNER JOIN Games AS g
	ON g.Id = ug.GameId
	INNER JOIN Characters AS ch
	ON ch.Id = ug.CharacterId
	INNER JOIN [Statistics] AS statch
	ON statch.Id = ch.StatisticId
	INNER JOIN GameTypes AS gt
	ON gt.Id = g.GameTypeId
	INNER JOIN [Statistics] AS statgt
	ON statgt.Id = gt.BonusStatsId
	INNER JOIN UserGameItems AS ugi
	ON ugi.UserGameId = ug.Id
	INNER JOIN Items AS i
	ON i.Id = ugi.ItemId
	INNER JOIN [Statistics] AS stati
	ON stati.Id = i.StatisticId
GROUP BY u.Username, g.Name
ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC