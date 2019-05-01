--USE Diablo

SELECT 
		SUBSTRING(u.Email, CHARINDEX('@', u.Email) + 1, LEN(u.Email)) AS [Email Provider],
		COUNT(SUBSTRING(u.Email, CHARINDEX('@', u.Email) + 1, LEN(u.Email))) AS [Number Of Users]
	FROM Users AS u
	GROUP BY SUBSTRING(u.Email, CHARINDEX('@', u.Email) + 1, LEN(u.Email))
	ORDER BY [Number Of Users] DESC, [Email Provider] ASC
