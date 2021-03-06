CREATE TABLE People 
(
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Name NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height DECIMAL(10, 2),
	Weight DECIMAL(10, 2),
	Gender VARCHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

-- Judge result do not depend by this constraint
ALTER TABLE People
ADD CONSTRAINT CH_PictureSize CHECK (DATALENGTH(Picture) <= 2 * 1024 * 1024)

ALTER TABLE People
ADD CONSTRAINT CH_GENDER CHECK (Gender IN ('m', 'f'))

INSERT INTO People (Name, Gender, Birthdate) VALUES
('Pesho Peshev', 'm', '19840912'),
('Gosho Goshov', 'm', '19660124'),
('Vanio Vaniov', 'm', '19830909'),
('Pepa Pepova', 'f', '19990101'),
('Ivanka Ivanova', 'f', '20000101')