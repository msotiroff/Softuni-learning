CREATE TRIGGER tr_ChangeStatus ON Reports
FOR UPDATE
AS
BEGIN
	
	DECLARE @CompletedID INT = (SELECT Id FROM Status WHERE Label = 'Completed')



	UPDATE Reports
	SET StatusId = @CompletedID WHERE Id IN (SELECT r.Id FROM Reports AS r
											JOIN deleted AS d ON d.Id = r.Id
											JOIN inserted AS i ON i.Id = r.Id
											WHERE d.CloseDate IS NULL AND i.CloseDate IS NOT NULL)

END

--BEGIN TRAN
--	UPDATE Reports
--	SET CloseDate = GETDATE()
--	WHERE EmployeeId = 5
--ROLLBACK