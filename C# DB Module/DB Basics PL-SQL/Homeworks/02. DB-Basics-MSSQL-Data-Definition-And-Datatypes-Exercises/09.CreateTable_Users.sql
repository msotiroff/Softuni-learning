CREATE TABLE Users
(
	Id BIGINT IDENTITY PRIMARY KEY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	Password VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT
)

ALTER TABLE Users
ADD CONSTRAINT CH_UserPictureSize CHECK (DATALENGTH (ProfilePicture) < 900 * 1024)

INSERT INTO Users (Username, Password) 
VALUES 
('msotiroff', 1234),
('mimoti', 1234),
('Gogi', 1234),
('Vasilena', 1234),
('Valentina', 1234)