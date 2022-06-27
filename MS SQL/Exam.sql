CREATE TABLE Owners(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50)
)

CREATE TABLE AnimalTypes (
	Id INT PRIMARY KEY IDENTITY,
	AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages (
	Id INT PRIMARY KEY IDENTITY,
	AnimalTypeId INT FOREIGN KEY (AnimalTypeId) REFERENCES AnimalTypes(Id)
)

CREATE TABLE Animals (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	BirthDate DATE NOT NULL,
	OwnerId INT FOREIGN KEY (OwnerId) REFERENCES Owners(Id),
	AnimalTypeId INT FOREIGN KEY (AnimalTypeId) REFERENCES AnimalTypes(Id)
)

CREATE TABLE AnimalsCages (
	CageId INT FOREIGN KEY (CageId) REFERENCES Cages(Id),
	AnimalId INT FOREIGN KEY (AnimalId) REFERENCES Animals(Id),
	PRIMARY KEY(CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments(
	Id INT PRIMARY KEY IDENTITY,
	DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50),
	AnimalId INT FOREIGN KEY (AnimalId) REFERENCES Animals(Id),
	DepartmentId INT FOREIGN KEY (DepartmentId) REFERENCES VolunteersDepartments(Id)
)

INSERT INTO Volunteers ([Name], PhoneNumber, [Address], AnimalId, DepartmentId)
VALUES
    ('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
    ('Dimitur Stoev', '0877564223', NULL, 42, 4),
    ('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
    ('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
    ('Boryana Mileva', '0888112233', NULL, 31, 5)

INSERT INTO Animals([Name], BirthDate, OwnerId, AnimalTypeId)
VALUES
    ('Giraffe', '2018-09-21', 21, 1),
    ('Harpy Eagle', '2015-04-17', 15, 3),
    ('Hamadryas Baboon', '2017-11-02', NULL, 1),
    ('Tuatara', '2021-06-30', 2, 4)

DELETE 
FROM Volunteers
WHERE DepartmentId = 2

DELETE 
FROM VolunteersDepartments
WHERE DepartmentName = 'Education program assistant'

SELECT 
    a.[Name],
    [at].AnimalType,
    FORMAT(a.BirthDate, 'd.MM.yyyy') AS [BirthDate]
FROM Animals AS a
JOIN AnimalTypes AS [at] ON a.AnimalTypeId = [at].Id 
ORDER BY a.[Name]

SELECT TOP 5
    o.[Name],
    COUNT(a.OwnerId) AS CountOfAnimals
FROM Animals AS a
JOIN Owners AS o ON a.OwnerId = o.Id
GROUP BY o.[Name]
ORDER BY CountOfAnimals DESC, o.[Name]

SELECT 
    CONCAT(o.[Name], '-', a.[Name]) AS OwnersAnimals,
    o.PhoneNumber,
    ac.CageId
FROM Owners AS o
JOIN Animals AS a ON a.OwnerId = o.Id
JOIN AnimalTypes AS [at] ON a.AnimalTypeId = [at].Id
JOIN AnimalsCages AS ac ON ac.AnimalId = a.Id
WHERE [at].AnimalType = 'Mammals'
ORDER BY o.[Name], a.[Name] DESC

CREATE PROC dbo.usp_AnimalsWithOwnersOrNot
    (@AnimalName VARCHAR(20))
AS 
    SELECT 
        a.[Name],
        CASE
            WHEN o.[Name] IS NULL THEN 'For adoption'
            ELSE o.[Name]
        END AS OwnersName
    FROM Animals AS a
    LEFT JOIN Owners AS o ON a.OwnerId = o.Id
    WHERE a.[Name] = @AnimalName