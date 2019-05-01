-- 01. Buy the items

DECLARE @AlexCash MONEY;
DECLARE @AlexEdinburghID INT;
DECLARE @ItemsTotalPrice MONEY;

SET @AlexEdinburghID = (SELECT Id 
						FROM UsersGames 
						WHERE UserId = (SELECT Id FROM Users WHERE Username = 'Alex')
							AND GameId = (SELECT Id FROM Games WHERE Name = 'Edinburgh'));

SET @ItemsTotalPrice = (SELECT SUM(Price) FROM Items 
							WHERE Name IN 
							('Blackguard',
							'Bottomless Potion of Amplification',
							'Eye of Etlich (Diablo III)',
							'Gem of Efficacious Toxin',
							'Golden Gorget of Leoric',
							'Hellfire Amulet'))

UPDATE UsersGames
SET Cash -= @ItemsTotalPrice WHERE Id = @AlexEdinburghID

INSERT INTO UserGameItems VALUES
	((SELECT Id FROM Items WHERE Name = 'Blackguard'), @AlexEdinburghID),
	((SELECT Id FROM Items WHERE Name = 'Bottomless Potion of Amplification'), @AlexEdinburghID),
	((SELECT Id FROM Items WHERE Name = 'Eye of Etlich (Diablo III)'), @AlexEdinburghID),
	((SELECT Id FROM Items WHERE Name = 'Gem of Efficacious Toxin'), @AlexEdinburghID),
	((SELECT Id FROM Items WHERE Name = 'Golden Gorget of Leoric'), @AlexEdinburghID),
	((SELECT Id FROM Items WHERE Name = 'Hellfire Amulet'), @AlexEdinburghID)

-- 2.Select all users in the current game with their items

SELECT 
		u.Username,
		g.Name,
		ug.Cash,
		i.Name AS [Item Name]
	FROM Users AS u
	INNER JOIN UsersGames AS ug
	ON ug.UserId = u.Id
	INNER JOIN Games AS g
	ON g.Id = ug.GameId
	INNER JOIN UserGameItems AS ugi
	ON ugi.UserGameId = ug.Id
	INNER JOIN Items AS i
	ON i.Id = ugi.ItemId
WHERE g.Name = 'Edinburgh'
ORDER BY [Item Name]