SELECT m.Id, m.ChatId, m.UserId
	FROM Messages AS m
	WHERE ChatId = 17 AND UserId NOT IN (SELECT DISTINCT UserId
											FROM UsersChats
											WHERE ChatId = 17)
	OR m.UserId IS NULL
ORDER BY m.Id DESC