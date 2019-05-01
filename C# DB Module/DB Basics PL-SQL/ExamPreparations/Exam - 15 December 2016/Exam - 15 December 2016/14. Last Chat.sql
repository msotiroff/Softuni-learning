SELECT 
		c.Title,
		m.Content
	FROM Messages AS m
	RIGHT JOIN Chats AS c ON c.Id = m.ChatId
	WHERE c.Id = (SELECT TOP 1 Id FROM Chats ORDER BY StartDate DESC)