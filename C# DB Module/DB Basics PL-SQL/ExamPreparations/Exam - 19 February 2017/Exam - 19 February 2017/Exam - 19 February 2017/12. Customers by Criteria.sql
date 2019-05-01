SELECT
		cust.FirstName,
		cust.Age,
		cust.PhoneNumber
	FROM Customers AS cust
	JOIN Countries AS c ON c.Id = cust.CountryId
	WHERE (cust.Age >= 21 AND cust.FirstName LIKE '%an%') 
	OR (RIGHT(cust.PhoneNumber, 2) = 38 AND cust.CountryId NOT IN (SELECT Id FROM Countries WHERE Name = 'Greece'))
ORDER BY cust.FirstName, cust.Age