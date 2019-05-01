CREATE PROC dbo.usp_GetHoldersWithBalanceHigherThan (@MinBalance MONEY)

AS
	SELECT 
		ach.FirstName AS [First Name],
		ach.LastName AS [Last Name]
	FROM AccountHolders AS ach
	WHERE ach.Id IN (
				SELECT
						ah.Id
					FROM AccountHolders AS ah
					JOIN Accounts AS a
					ON ah.Id = a.AccountHolderId
					GROUP BY ah.Id
					HAVING SUM(Balance) > @MinBalance
			)
			ORDER BY ach.LastName, ach.FirstName