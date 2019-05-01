CREATE FUNCTION udf_GetRating (@ProductName NVARCHAR(25))
RETURNS VARCHAR(10)
AS
BEGIN

	DECLARE @Result VARCHAR(10)

	DECLARE @ProductId INT = (SELECT Id FROM Products WHERE Name = @ProductName)
	DECLARE @ProductAvgRating DECIMAL(4, 2)
	SET @ProductAvgRating = (SELECT TOP 1 
										AVG(f.Rate) 
									FROM Products AS p
									JOIN Feedbacks AS f
									ON f.ProductId = p.Id AND p.Id = @ProductId
									GROUP BY p.Name, p.Description
								ORDER BY AVG(f.Rate))

	IF @ProductAvgRating IS NULL
	SET @Result = 'No rating'

	ELSE IF @ProductAvgRating < 5 AND @ProductAvgRating >= 0
	SET @Result = 'Bad'

	ELSE IF @ProductAvgRating <= 8
	SET @Result = 'Average'

	ELSE IF @ProductAvgRating <= 10
	SET @Result =  'Good'
		
	RETURN @Result
END

--SELECT TOP 5 Id, Name, dbo.udf_GetRating(Name)
--  FROM Products
-- ORDER BY Id
