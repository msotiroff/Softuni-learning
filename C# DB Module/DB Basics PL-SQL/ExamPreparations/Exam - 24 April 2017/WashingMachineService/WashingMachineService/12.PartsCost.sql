SELECT
		ISNULL(SUM(op.Quantity * p.Price), 0) AS [Parts Total]
	FROM Parts AS p
	LEFT JOIN OrderParts AS op
	ON op.PartId = p.PartId
	LEFT JOIN Orders AS o
	ON o.OrderId = op.OrderId
	WHERE DATEDIFF(DAY, o.IssueDate, '20170424') <= 21