--CREATE TABLE MessageLogs
--(
--	Id INT PRIMARY KEY IDENTITY,
--	Content VARCHAR(200),
--	SentOn DATE,
--	ChatId INT FOREIGN KEY REFERENCES Chats(Id),
--	UserId INT FOREIGN KEY REFERENCES Users(Id)
--)

CREATE TRIGGER tr_DeletedMsgLog ON Messages FOR DELETE
AS
BEGIN

	INSERT INTO MessageLogs (Id, Content, SentOn, ChatId, UserId)
		SELECT Id, Content, SentOn, ChatId, UserId FROM deleted

END

---- ON SINGLE DELETE
--BEGIN TRAN
--      DELETE FROM [Messages]
--       WHERE [Messages].Id = 1
--ROLLBACK

---- ON MULTIPLE DELETE
--BEGIN TRAN
--      DELETE FROM [Messages]
--       WHERE [Messages].Id IN (1, 2, 3)
--ROLLBACK