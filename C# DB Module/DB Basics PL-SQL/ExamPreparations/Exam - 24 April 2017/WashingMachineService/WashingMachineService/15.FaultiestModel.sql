WITH CTE_FaultsByModel (ModelID, Faults)  
AS  
(  
    SELECT Models.ModelId,
			COUNT(JobId)
			FROM Models
			JOIN Jobs ON Models.ModelId = Jobs.ModelId
			GROUP BY Models.ModelId 
)

SELECT
		m.Name,
		(SELECT MAX(Faults) FROM CTE_FaultsByModel) AS [Times Serviced],
		ISNULL(SUM(p.Price * op.Quantity), 0) AS [Parts Total]
	FROM Orders AS o
	INNER JOIN OrderParts AS op
	ON op.OrderId = o.OrderId
	INNER JOIN Parts AS p
	ON p.PartId = op.PartId
	RIGHT JOIN Jobs AS j
	ON j.JobId = o.JobId
	INNER JOIN Models AS m
	ON m.ModelId = j.ModelId
WHERE m.ModelId IN (
						SELECT 
								Models.ModelId FROM Models
							JOIN Jobs ON Models.ModelId=Jobs.ModelId
							GROUP BY Models.ModelId
							HAVING COUNT(JobId)=(SELECT max(Faults) FROM CTE_FaultsByModel 
					))
				GROUP BY m.ModelId, m.Name