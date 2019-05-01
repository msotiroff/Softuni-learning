SELECT
		Content,
		SentOn
	FROM Messages
	WHERE SentOn > '20140512' AND Content LIKE '%just%'
ORDER BY Id DESC