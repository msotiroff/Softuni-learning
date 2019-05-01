--CREATE TABLE Logs 
--(
--	LogId INT PRIMARY KEY IDENTITY, 
--	AccountId INT FOREIGN KEY REFERENCES Accounts(Id), 
--	OldSum MONEY, 
--	NewSum MONEY
--)

CREATE TRIGGER tr_ChangeBalanceLog ON Accounts FOR UPDATE
AS
BEGIN

DECLARE @AccountID INT
DECLARE @OldBalance MONEY
DECLARE @NewBalane MONEY

SET @AccountID = (SELECT Id FROM inserted)
SET @OldBalance = (SELECT Balance FROM deleted)
SET @NewBalane = (SELECT Balance FROM inserted)

INSERT INTO Logs 
VALUES (@AccountID, @OldBalance, @NewBalane)

END