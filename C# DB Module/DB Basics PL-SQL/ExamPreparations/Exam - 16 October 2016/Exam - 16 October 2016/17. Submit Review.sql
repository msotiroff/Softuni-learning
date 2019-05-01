CREATE PROC usp_SubmitReview 
(@CustomerID INT, @ReviewContent VARCHAR(255), @ReviewGrade INT, @AirlineName VARCHAR(30))
AS
BEGIN

	DECLARE @AirlineId INT = (SELECT AirlineID FROM Airlines WHERE AirlineName = @AirlineName);

	IF (@AirlineId IS NULL)
	BEGIN
		RAISERROR('Airline does not exist.', 16, 1)
		RETURN
	END
	
	DECLARE @LastPK INT = ISNULL((SELECT TOP 1 ReviewID FROM CustomerReviews ORDER BY ReviewID DESC), 0)

	INSERT INTO CustomerReviews (ReviewID, ReviewContent, ReviewGrade, AirlineID, CustomerID)
	VALUES (@LastPK + 1, @ReviewContent, @ReviewGrade, @AirlineId, @CustomerID)

END


--BEGIN TRAN
--EXEC dbo.usp_SubmitReview 1, 'Very well', 9, 'Russia Airlines'
--ROLLBACK