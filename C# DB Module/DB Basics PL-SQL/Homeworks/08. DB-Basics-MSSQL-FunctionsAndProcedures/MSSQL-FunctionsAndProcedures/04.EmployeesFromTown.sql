CREATE PROC dbo.usp_GetEmployeesFromTown @TownName VARCHAR(MAX)

AS

SELECT 
		e.FirstName,
		e.LastName
	FROM Employees AS e
		JOIN Addresses AS a
		ON a.AddressID = e.AddressID
		JOIN Towns AS t
		ON t.TownID = a.TownID
	WHERE	e.AddressID = a.AddressID 
			AND a.TownID = t.TownID 
			AND t.Name = @TownName