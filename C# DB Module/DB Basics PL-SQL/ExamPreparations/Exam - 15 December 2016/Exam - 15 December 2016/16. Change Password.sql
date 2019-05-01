CREATE PROC udp_ChangePassword @Email VARCHAR(30), @NewPassWord VARCHAR(20)
AS
BEGIN

	IF (@Email NOT IN (SELECT Email FROM Credentials))
	BEGIN
		RAISERROR('The email does''t exist!', 16, 1)
		RETURN
	END

	UPDATE Credentials
	SET Password = @NewPassWord WHERE Email = @Email

END

--BEGIN TRAN
--exec udp_ChangePassword 'abarnes0@sogou.com','new_pass'
--ROLLBACK

--BEGIN TRAN
--exec udp_ChangePassword 'invalid_username@invaliddomain.com','new_pass'
--ROLLBACK