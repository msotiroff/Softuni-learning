UPDATE Chats
SET StartDate = (SELECT MIN(m.SentOn)
					FROM Chats AS c
					JOIN Messages AS m ON m.ChatId = c.Id
					WHERE c.Id = Chats.Id)
	WHERE CHATS.Id IN (
					SELECT 
						c.Id
					FROM Chats AS c
					JOIN Messages AS m ON m.ChatId = c.Id
					GROUP BY c.Id, c.StartDate
					HAVING c.StartDate > MIN(m.SentOn)
					)