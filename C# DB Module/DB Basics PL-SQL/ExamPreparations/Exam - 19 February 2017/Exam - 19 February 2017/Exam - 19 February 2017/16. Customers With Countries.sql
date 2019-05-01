CREATE VIEW v_UserWithCountries
AS
SELECT 
		CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
		c.Age,
		c.Gender,
		co.Name
	FROM Customers AS c
	JOIN Countries AS co ON co.Id = c.CountryId

--SELECT TOP 5 *
--  FROM v_UserWithCountries
-- ORDER BY Age
