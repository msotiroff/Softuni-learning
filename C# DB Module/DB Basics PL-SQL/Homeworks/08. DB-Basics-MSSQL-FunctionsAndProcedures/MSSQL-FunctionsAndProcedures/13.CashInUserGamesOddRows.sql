CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE
AS
RETURN 
(	
	SELECT	
			SUM(SubQ.Cash) AS SumCash
		FROM	(
				SELECT	
					ug.Cash AS Cash,
					ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RowNum
				FROM UsersGames AS ug
				INNER JOIN Games AS g
				ON g.Id = ug.GameId
				WHERE g.Name = @gameName
				) AS SubQ
		WHERE SubQ.RowNum % 2 != 0
)