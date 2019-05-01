CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
	Name VARCHAR(50) NOT NULL,
	ManagerID INT NULL FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)