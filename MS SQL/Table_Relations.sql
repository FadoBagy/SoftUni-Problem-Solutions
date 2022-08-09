-- Ono-To-One
CREATE TABLE Passports (
	PassportID INT PRIMARY KEY IDENTITY,
	PassportNumber NVARCHAR(50) NOT NULL
)

CREATE TABLE Persons (
	PersonID INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	Salary INT NOT NULL,
	PassportID INT,
	CONSTRAINT FK_Passports_Persons
	FOREIGN KEY (PassportID)
	REFERENCES Passports(PassportID)
)
--------------------------------------------------
-- One-To-Many
CREATE TABLE Manufacturers (
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	EstablishedOn DATE
)

CREATE TABLE Models (
	ModelID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	ManufacturerID INT,
	CONSTRAINT FK_Models_Manufacturers
	FOREIGN KEY (ManufacturerID)
	REFERENCES Manufacturers(ManufacturerID)
)

SELECT 
	m.[Name] AS Manufacturers,
	mo.[Name] AS Models
FROM Manufacturers AS m
JOIN Models AS mo ON
	mo.ManufacturerID = m.ManufacturerID
ORDER BY m.[Name] DESC
--------------------------------------------
-- Many-To-Many 
CREATE TABLE Students (
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(40) NOT NULL
)

CREATE TABLE Exams (
	ExamID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] NVARCHAR(70) NOT NULL
)

CREATE TABLE StudentsExams (
	StudentID INT FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
	ExamID INT FOREIGN KEY (ExamID) REFERENCES Exams(ExamID),
	PRIMARY KEY(StudentID, ExamID)
)
-----------------------------
-- Self-Referencing
CREATE TABLE Teachers (
	TeacherID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	ManagerID INT FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)