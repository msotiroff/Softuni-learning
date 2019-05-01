SELECT TOP 5 
		c.Id,
		COUNT(m.Id) AS TotalMessages
	FROM Messages AS m
	LEFT JOIN Chats AS c ON c.Id = m.ChatId
	WHERE m.Id <= 90
	GROUP BY c.Id
ORDER BY TotalMessages DESC, c.Id ASC