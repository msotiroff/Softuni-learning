--USE SoftUni

CREATE PROC usp_AssignProject (@employeeId INT, @projectId INT)
AS
BEGIN
	DECLARE @currentEmployeeProjectCounter INT = (SELECT COUNT(ProjectID) FROM EmployeesProjects
														WHERE EmployeeID = @employeeId
														GROUP BY EmployeeID
													)

	BEGIN TRANSACTION
		INSERT INTO EmployeesProjects
		VALUES (@employeeId, @projectId)
		
		IF(@currentEmployeeProjectCounter >= 3)
		BEGIN
			RAISERROR('The employee has too many projects!', 16, 1)
			ROLLBACK
			RETURN
		END

	COMMIT
END

--EXEC dbo.udp_AssignProject 1, 5
--EXEC dbo.udp_AssignProject 263, 5