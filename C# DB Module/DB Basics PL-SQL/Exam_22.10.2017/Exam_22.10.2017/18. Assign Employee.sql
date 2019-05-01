CREATE PROC usp_AssignEmployeeToReport(@employeeId INT, @reportId INT)
AS
BEGIN

	DECLARE @EmploeeDepartment INT = (SELECT DepartmentId FROM Employees WHERE Id = @employeeId)
	DECLARE @ReportCategoryOfDepartment INT = 
		(SELECT c.DepartmentId FROM Reports AS r
					JOIN Categories AS c ON c.Id = r.CategoryId
					WHERE r.Id = @reportId)

	IF (@EmploeeDepartment <> @ReportCategoryOfDepartment)
	BEGIN
		RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
		RETURN
	END

	UPDATE Reports
	SET EmployeeId = @employeeId WHERE Id = @reportId

END

--BEGIN TRAN
--	EXEC usp_AssignEmployeeToReport 17, 2;
--	SELECT EmployeeId FROM Reports WHERE id = 2
--ROLLBACK