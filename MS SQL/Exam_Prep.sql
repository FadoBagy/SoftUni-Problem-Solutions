CREATE DATABASE [Bitbucket]

-- Problem 1
CREATE TABLE Users(
	[Id] INT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	[Email] VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors(
	[RepositoryId] INT FOREIGN KEY (RepositoryId) REFERENCES Repositories(Id),
	[ContributorId] INT FOREIGN KEY (ContributorId) REFERENCES Users(Id),
	PRIMARY KEY([RepositoryId], [ContributorId])
)

CREATE TABLE Issues(
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] VARCHAR(255) NOT NULL,
	[IssueStatus] VARCHAR(6) NOT NULL,
	[RepositoryId] INT FOREIGN KEY ([RepositoryId]) REFERENCES Repositories(Id),
	[AssigneeId] INT FOREIGN KEY ([AssigneeId]) REFERENCES Users(Id)
) 

CREATE TABLE Commits(
	[Id] INT PRIMARY KEY IDENTITY,
	[Message] VARCHAR(255) NOT NULL,
	[IssueId] INT FOREIGN KEY ([IssueID]) REFERENCES Issues([Id]),
	[RepositoryId] INT FOREIGN KEY ([RepositoryId]) REFERENCES Repositories(Id),
	[ContributorId] INT FOREIGN KEY ([ContributorId]) REFERENCES Users(Id)
)

CREATE TABLE Files(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	[Size] DECIMAL(18, 2) NOT NULL,
	[ParentId] INT FOREIGN KEY ([ParentId]) REFERENCES Files(Id),
	[CommitId] INT FOREIGN KEY ([CommitId]) REFERENCES Commits(Id)
)

-- Problem 2

INSERT INTO Files ([Name], [Size], [ParentId], [CommitId])
VALUES 
	('Trade.idk', 2598.0, 1, 1),
	('menu.net', 9238.31, 2, 2),
	('Administrate.soshy', 1246.93, 3, 3),
	('Controller.php', 7353.15, 4, 4),
	('Find.java', 9957.86, 5, 5),
	('Controller.json', 14034.87, 3, 6),
	('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues ([Title], [IssueStatus], [RepositoryId], [AssigneeId])
VALUES
	('Critical Problem with HomeController.cs file', 'open', 1, 4),
	('Typo fix in Judge.html', 'open', 4, 3),
	('Implement documentation for UsersService.cs', 'closed', 8, 2),
	('Unreachable code in Index.cs', 'open', 9, 8)

-- Problem 3

UPDATE Issues
SET [IssueStatus] = 'closed'
WHERE [AssigneeId] = 6

-- Problem 4

DELETE 
FROM RepositoriesContributors
WHERE RepositoryId = 3

DELETE 
FROM Commits
WHERE RepositoryId = 3

SELECT * 
FROM Repositories 

-- Problem 5 
SELECT 
	[Id],
	[Message],
	[RepositoryId],
	[ContributorId]
FROM Commits
ORDER BY Id, [Message], RepositoryId, ContributorId

-- Problem 6
SELECT 
	Id,
	[Name],
	Size
FROM Files
WHERE 
	Size > 1000
	AND [Name] LIKE '%.html'
ORDER BY Size DESC, Id, [Name]

-- Problem 7
SELECT 
	i.Id,
	CONCAT(u.Username, ' : ', i.Title) AS IssueAssignee
FROM Issues AS i
JOIN Users AS u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, i.AssigneeId

-- Problem 8

-- Problem 9
-- NO!!!
SELECT TOP 5
	r.Id,
	r.[Name],
	COUNT(c.RepositoryId) AS Commits
FROM Commits AS c
LEFT JOIN Repositories AS r ON c.RepositoryId = r.Id
GROUP BY r.[Name], r.Id
ORDER BY Commits DESC, r.Id, r.[Name] 

-- Problem 10
SELECT 
	u.Username,
	AVG(f.Size) AS Size
FROM Commits AS c
JOIN Users AS u ON c.ContributorId = u.Id
JOIN Files AS f ON f.CommitId = c.Id
GROUP BY u.Username
ORDER BY Size DESC, u.Username

GO
-- Problem 11
CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @count INT;

	SET @count = (
			SELECT 
				COUNT(u.Id)
			FROM Users AS u
			JOIN Commits AS c ON c.ContributorId = u.Id
			WHERE u.Username = @username
			GROUP BY u.Username
	)

	RETURN @count
END

GO

SELECT dbo.udf_AllUserCommits('ANinedsa')

SELECT 
	u.Username,
	COUNT(c.Id)
FROM Users AS u
JOIN Commits AS c ON c.ContributorId = u.Id
GROUP BY u.Username
HAVING u.Username = 'RoundAntigaBel'
