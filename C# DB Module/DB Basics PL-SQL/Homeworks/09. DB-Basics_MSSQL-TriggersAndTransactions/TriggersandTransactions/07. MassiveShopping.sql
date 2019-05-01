--USE Diablo

DECLARE @userGameId INT = (SELECT Id FROM UsersGames 
							WHERE GameId = (SELECT Id FROM Games WHERE Name = 'Safflower')
								AND UserId = (SELECT Id FROM Users WHERE Username = 'Stamat')
							)
DECLARE @downLevel INT, @upLevel INT, @allItemsPrice MONEY

DECLARE @currentCash MONEY = (SELECT Cash FROM UsersGames WHERE Id = @userGameId)
DECLARE @userLevel INT = (SELECT Level FROM UsersGames WHERE Id = @userGameId)

-- BYIING ITEMS FROM 11th AND 12th LEVEL

SET @downLevel = 11
SET @upLevel = 12
SET @allItemsPrice = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN @downLevel AND @upLevel)

IF (@allItemsPrice <= @currentCash AND @userLevel >= @upLevel)
BEGIN
	BEGIN TRANSACTION
	UPDATE UsersGames
	SET Cash -= @allItemsPrice
	WHERE Id = @userGameId

	IF (@@ROWCOUNT <> 1)
		ROLLBACK
	ELSE
	BEGIN
		INSERT INTO UserGameItems (ItemId, UserGameId) 
		(SELECT Id, @userGameId FROM Items WHERE MinLevel BETWEEN @downLevel AND @upLevel)
		COMMIT
	END
END

-- BYIING ITEMS FROM 19th AND 21th LEVEL

SET @downLevel = 19
SET @upLevel = 21
SET @allItemsPrice = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN @downLevel AND @upLevel)
SET @currentCash = (SELECT Cash FROM UsersGames WHERE Id = @userGameId)

IF (@allItemsPrice <= @currentCash AND @userLevel >= @upLevel)
BEGIN
	BEGIN TRANSACTION
	UPDATE UsersGames
	SET Cash -= @allItemsPrice
	WHERE Id = @userGameId

	IF (@@ROWCOUNT <> 1)
		ROLLBACK
	ELSE
	BEGIN
		INSERT INTO UserGameItems (ItemId, UserGameId) 
    (SELECT Id, @userGameId FROM Items WHERE MinLevel BETWEEN @downLevel AND @upLevel)
		COMMIT
	END
END

-- SELECT THE PURCHASED ITEMS

SELECT 
	i.Name
FROM Items AS i
JOIN UserGameItems AS ugi
ON ugi.ItemId = i.Id
JOIN UsersGames AS ug
ON ug.Id = ugi.UserGameId AND ug.Id = @userGameId
ORDER BY i.Name ASC