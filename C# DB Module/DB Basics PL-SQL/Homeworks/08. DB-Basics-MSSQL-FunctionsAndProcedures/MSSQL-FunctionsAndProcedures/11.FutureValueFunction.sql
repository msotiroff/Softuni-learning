CREATE FUNCTION dbo.ufn_CalculateFutureValue 
	(@sum MONEY, @YearlyInterestRate FLOAT, @NumberOfYears INT)
RETURNS MONEY
AS
BEGIN

	DECLARE @FutureValue MONEY

	SET @FutureValue = @sum * POWER((1 + @YearlyInterestRate), @NumberOfYears)

	RETURN @FutureValue  

END