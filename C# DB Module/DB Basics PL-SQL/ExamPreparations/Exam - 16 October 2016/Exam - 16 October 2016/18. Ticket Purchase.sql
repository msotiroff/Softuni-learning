CREATE OR ALTER PROC usp_PurchaseTicket 
(@CustomerId INT, @FlightID INT, @TicketPrice DECIMAL(10, 2), @Class VARCHAR(6), @Seat VARCHAR(5))
AS
BEGIN

	DECLARE @LastTicketId INT = (SELECT TOP 1 TicketID FROM Tickets ORDER BY TicketID DESC)
													

	DECLARE @CustomerBalance DECIMAL(10, 2) = 
	ISNULL((SELECT Balance FROM CustomerBankAccounts WHERE CustomerID = @CustomerId), 0)

	IF (@CustomerBalance < @TicketPrice)
	BEGIN
		RAISERROR('Insufficient bank account balance for ticket purchase.', 16, 1)
		RETURN
	END
	
	INSERT INTO Tickets (TicketID, Price, Class, Seat, CustomerID, FlightID) 
	VALUES (@LastTicketId + 1, @TicketPrice, @Class, @Seat, @CustomerID, @FlightID)

	UPDATE CustomerBankAccounts
	SET Balance -= @TicketPrice WHERE CustomerID = @CustomerId

END

--BEGIN TRAN
--	EXEC dbo.usp_PurchaseTicket 1, 1, 2561.00, 'First', '15'
--ROLLBACK