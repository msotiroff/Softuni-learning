SELECT 
		c.Id, c.Title, m.Id
	FROM Chats AS c
	JOIN Messages AS m ON m.ChatId = c.Id
	WHERE m.SentOn < '20120326' AND RIGHT(c.Title, 1) = 'x'
ORDER BY c.Id, m.Id