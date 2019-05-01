CREATE PROC usp_SendFeedback (@CustomerID INT, @ProductID INT, @Rate DECIMAL(4, 2), @Description NVARCHAR(255))
AS
BEGIN

	DECLARE @CountOfFeedBacksPerCurrentCustomerAndProduct INT
	SET @CountOfFeedBacksPerCurrentCustomerAndProduct = (SELECT
																COUNT(Id)
															FROM Feedbacks AS f
															WHERE f.ProductId = @ProductID AND f.CustomerId = @CustomerID
															)
															

	IF @CountOfFeedBacksPerCurrentCustomerAndProduct >= 3 
	BEGIN
		RAISERROR('You are limited to only 3 feedbacks per product!', 16, 1)
		RETURN
	END
	ELSE
	BEGIN
		INSERT INTO Feedbacks (CustomerId, ProductId, Rate, Description)
		VALUES (@CustomerID, @ProductID, @Rate, @Description)
	END

END

--BEGIN TRANSACTION

--EXEC usp_SendFeedback 1, 5, 7.50, 'Average experience';
--SELECT COUNT(*) FROM Feedbacks WHERE CustomerId = 1 AND ProductId = 5;

--ROLLBACK