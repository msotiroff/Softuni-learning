WITH CTE_PartsByOrders (MechanicID, AllPartsOrdered, VendorName)
AS
(SELECT m.MechanicId, SUM(op.Quantity), v.Name
 FROM OrderParts AS op
	JOIN Parts AS p ON p.PartId = op.PartId
	JOIN Vendors AS v ON v.VendorId = p.VendorId
	JOIN Orders AS o ON o.OrderId = op.OrderId
	JOIN Jobs AS j ON j.JobId = o.JobId
	JOIN Mechanics AS m ON m.MechanicId = j.MechanicId
	GROUP BY m.MechanicId, v.Name)





SELECT 
		CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
		CTE.VendorName AS Vendor,
		CTE.AllPartsOrdered AS Parts,
		CAST(CAST(CAST(CTE.AllPartsOrdered AS DECIMAL(4, 2)) / SUM(op.Quantity) * 100 AS INT) AS VARCHAR(10)) + '%' AS Preference
	FROM Mechanics AS m
	JOIN Jobs AS j ON j.MechanicId = m.MechanicId
	JOIN Orders AS o ON o.JobId = j.JobId
	JOIN OrderParts AS op ON op.OrderId = o.OrderId
	JOIN CTE_PartsByOrders AS CTE ON CTE.MechanicID = m.MechanicId
	GROUP BY CONCAT(m.FirstName, ' ', m.LastName), CTE.VendorName, CTE.AllPartsOrdered
ORDER BY [Mechanic], Parts DESC, Vendor


