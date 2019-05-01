CREATE FUNCTION udf_GetCost(@JobID INT)
RETURNS DECIMAL(20, 2)
AS
BEGIN

DECLARE @RESULT DECIMAL(20, 2)
SET @RESULT = (
				SELECT ISNULL(SUM(op.Quantity * p.Price), 0)
					FROM Parts AS p
					INNER JOIN OrderParts AS op ON op.PartId = p.PartId
					INNER JOIN Orders AS o ON o.OrderId = op.OrderId
					INNER JOIN Jobs AS j ON j.JobId = o.JobId
					WHERE j.JobId = @JobID
				)
	RETURN @Result

END

--SELECT dbo.udf_GetCost(3)