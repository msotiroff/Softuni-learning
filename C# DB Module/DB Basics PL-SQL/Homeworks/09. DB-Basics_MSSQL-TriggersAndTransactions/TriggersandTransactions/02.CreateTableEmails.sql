--CREATE TABLE NotificationEmails
--(
--	Id INT PRIMARY KEY IDENTITY, 
--	Recipient INT FOREIGN KEY REFERENCES Accounts(Id), 
--	Subject VARCHAR(MAX) NOT NULL, 
--	Body VARCHAR(MAX) NOT NULL
--)

CREATE TRIGGER tr_NotificationsByEmail ON Logs FOR INSERT
AS
BEGIN

DECLARE @RecipientId INT
DECLARE @Subject VARCHAR(MAX)
DECLARE @Body VARCHAR(MAX)
DECLARE @OldAmount MONEY
DECLARE @NewAmount MONEY

SET @OldAmount = (SELECT OldSum FROM inserted)
SET @NewAmount = (SELECT NewSum FROM inserted)
SET @RecipientId = (SELECT AccountId FROM inserted)
SET @Subject = CONCAT('Balance change for account: ', (SELECT AccountId FROM inserted))
SET @Body = CONCAT('On ', GETDATE(), ' your balance was changed from ', @OldAmount, ' to ', @NewAmount, '.')

INSERT INTO NotificationEmails
VALUES (@RecipientId, @Subject, @Body)

END

--UPDATE Accounts
--SET Balance += 1000
--WHERE Id = 1

--UPDATE Accounts
--SET Balance -= 1000
--WHERE Id = 1