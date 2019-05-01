CREATE PROC udp_SendMessage @UresID INT, @ChatID INT, @Content VARCHAR(MAX)
AS
BEGIN

	DECLARE @IsUserInChat INT = (SELECT COUNT(*) FROM UsersChats WHERE UserId = @UresID AND ChatId = @ChatID)
	IF (@IsUserInChat = 1)
	BEGIN
		INSERT INTO Messages (Content, SentOn, ChatId, UserId)
		VALUES (@Content, GETDATE(), @ChatID, @UresID)
	END
	ELSE
	BEGIN 
		RAISERROR('There is no chat with that user!', 16, 1)
	END
END

--BEGIN TRAN
--EXEC dbo.udp_SendMessage 19, 17, 'Awesome'
--ROLLBACK

--BEGIN TRAN
--EXEC dbo.udp_SendMessage 0, 17, 'Awesome'
--ROLLBACK