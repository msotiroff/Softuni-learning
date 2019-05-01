SELECT
		j.JobId,
		ISNULL(SUM(p.Price * op.Quantity), 0) AS [Total]
	FROM Orders AS o
	INNER JOIN OrderParts AS op
	ON op.OrderId = o.OrderId
	INNER JOIN Parts AS p
	ON p.PartId = op.PartId
	RIGHT JOIN Jobs AS j
	ON j.JobId = o.JobId
	GROUP BY j.JobId, j.FinishDate
	HAVING j.FinishDate IS NOT NULL
ORDER BY [Total] DESC, j.JobId ASC