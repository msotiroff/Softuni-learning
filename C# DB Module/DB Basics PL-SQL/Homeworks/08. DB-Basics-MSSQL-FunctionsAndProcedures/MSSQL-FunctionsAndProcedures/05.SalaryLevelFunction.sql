CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN

	DECLARE @Result VARCHAR(10)
	
	 IF(@Salary < 30000)
	 SET @Result = 'Low'
	 ELSE IF(@Salary BETWEEN 30000 AND 50000)
	 SET @Result = 'Average'
	 ELSE IF(@Salary > 50000)
	 SET @Result = 'High'

	RETURN @Result

END