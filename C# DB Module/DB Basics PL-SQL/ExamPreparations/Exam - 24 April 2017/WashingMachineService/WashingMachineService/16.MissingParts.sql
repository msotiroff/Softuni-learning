SELECT 
		p.PartId,
		p.Description,
		SUM(pn.Quantity) AS [Required],
		SUM(p.StockQty) AS [In Stock],
		ISNULL(SUM(op.Quantity), 0)  AS [Ordered]
	FROM Parts AS p
	LEFT JOIN PartsNeeded AS pn
	ON pn.PartId = p.PartId
	LEFT JOIN Jobs AS j
	ON j.JobId = pn.JobId
	LEFT JOIN Orders AS o
	ON o.JobId = j.JobId
	LEFT JOIN OrderParts AS op
	ON op.OrderId = o.OrderId
WHERE j.Status <> 'Finished' OR ((p.StockQty - pn.Quantity) < 0 )
        AND Delivered = 0
GROUP BY p.PartId, p.Description, j.Status
HAVING SUM(p.StockQty) + ISNULL(SUM(op.Quantity), 0) < SUM(pn.Quantity)
ORDER BY p.PartId