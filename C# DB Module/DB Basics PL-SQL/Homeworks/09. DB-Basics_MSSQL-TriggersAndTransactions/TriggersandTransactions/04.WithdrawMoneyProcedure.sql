CREATE PROC usp_WithdrawMoney (@AccountId INT, @moneyAmount MONEY)
AS
BEGIN

	BEGIN TRANSACTION
	UPDATE Accounts
	SET Balance -= @moneyAmount
	WHERE Id = @AccountId

	IF(@@ROWCOUNT <> 1)
	BEGIN
		ROLLBACK
		RETURN
	END

	COMMIT
END

--EXEC dbo.usp_WithdrawMoney 1, 1000
--EXEC dbo.usp_WithdrawMoney 1, -1000