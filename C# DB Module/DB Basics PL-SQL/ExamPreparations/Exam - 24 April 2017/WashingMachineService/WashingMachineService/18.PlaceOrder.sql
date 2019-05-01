-- Judge result: 4/6

CREATE PROC usp_PlaceOrder 
	@JobID INT, @SN VARCHAR(50), @Quantity INT
AS
BEGIN
	-- The quantity cannot be zero or negative:
	IF (@Quantity <= 0)
	BEGIN
		RAISERROR('Part quantity must be more than zero!', 16, 1)
		RETURN
	END
	-- The job with given ID must exist in the database:
	IF (@JobID NOT IN (SELECT JobId FROM Jobs))
	BEGIN
		RAISERROR('Job not found!', 16, 1)
		RETURN
	END
	-- An order cannot be placed for a job that is Finished:
	IF (@JobID IN (SELECT JobId FROM Jobs WHERE [Status] = 'Finished'))
	BEGIN
		RAISERROR('This job is not active!', 16, 1)
		RETURN
	END
	-- The part with given serial number must exist in the database:
	IF(@SN NOT IN (SELECT SerialNumber FROM Parts))
	BEGIN
		RAISERROR('Part not found!', 16, 1)
		RETURN
	END

	DECLARE @PartID INT
	DECLARE @OrderID INT

	SET @PartID = (SELECT PartId FROM Parts WHERE SerialNumber = @SN)
	SET @OrderID = (SELECT o.OrderId FROM Orders AS o
						INNER JOIN OrderParts AS op ON op.OrderId = o.OrderId
						INNER JOIN Parts AS p ON p.PartId = op.PartId
						WHERE JobId = @JobId AND p.PartId = @PartId AND IssueDate IS NULL)

	IF(@OrderID IS NULL)
	BEGIN
		-- Create new order
		INSERT INTO Orders VALUES (@JobID, NULL, DEFAULT)
		INSERT INTO OrderParts VALUES (IDENT_CURRENT('Orders'), @PartID, @Quantity)
	END
	
	ELSE
	BEGIN
		IF((SELECT COUNT(*) FROM OrderParts
			WHERE OrderId = @OrderId AND PartId = @PartId) IS NULL)
		BEGIN
			-- add the new product to it
			INSERT INTO OrderParts VALUES (@OrderID, @PartID, @Quantity)
			
		END
		ELSE
		BEGIN 
			-- add the quantity to the existing one
			UPDATE OrderParts
			SET Quantity += @Quantity WHERE OrderId = @OrderID AND PartId = @PartID
		END
	END
END

--DECLARE @err_msg AS NVARCHAR(MAX);
--BEGIN TRY
--  EXEC dbo.usp_PlaceOrder 49, 'ZeroQuantity', 2
--END TRY

--BEGIN CATCH
--  SET @err_msg = ERROR_MESSAGE();
--  SELECT @err_msg
--END CATCH



