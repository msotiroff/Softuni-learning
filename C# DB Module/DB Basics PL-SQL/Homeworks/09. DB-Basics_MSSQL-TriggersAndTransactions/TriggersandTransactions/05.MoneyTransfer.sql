CREATE PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount MONEY)
AS
BEGIN

	DECLARE @senderBalance MONEY = (SELECT Balance FROM Accounts WHERE Id = @senderId)
	
	IF(@amount < 0 OR @senderBalance < @amount OR @senderId = @receiverId)
	BEGIN
		RETURN
	END

	BEGIN TRANSACTION

		EXEC dbo.usp_WithdrawMoney @senderId, @amount
		EXEC dbo.usp_DepositMoney @receiverId, @amount

	COMMIT
END

--EXEC usp_TransferMoney 1, 2, 100
--EXEC usp_TransferMoney 2, 1, 100
--EXEC usp_TransferMoney 1, 2, 150