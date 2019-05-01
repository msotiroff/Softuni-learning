UPDATE Ingredients
SET OriginCountryId = 14 WHERE OriginCountryId = 8

UPDATE Ingredients
SET DistributorId = 35 WHERE Name IN (SELECT Name FROM Ingredients
		WHERE Name IN ('Bay Leaf', 'Paprika', 'Poppy'))