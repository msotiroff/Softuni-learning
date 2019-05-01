CREATE FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT)
RETURNS INT
AS
BEGIN

	DECLARE @ReportsCount INT
	SET @ReportsCount = (SELECT 
							COUNT(StatusId) 
						FROM Reports
						WHERE EmployeeId = @employeeId AND StatusId = @statusId)
	RETURN @ReportsCount
END

--SELECT Id, FirstName, Lastname, dbo.udf_GetReportsCount(Id, 2) AS ReportsCount
--FROM Employees
--ORDER BY Id
