SELECT 
	FirstName,
	LastName
FROM Employees
WHERE LEFT(FirstName, 2) = 'Sa'

SELECT 
	FirstName,
	LastName
FROM Employees
WHERE LastName LIKE '%ei%'

SELECT 
	FirstName
FROM Employees
WHERE 
	DepartmentID IN (3, 10)
	AND YEAR(HireDate) BETWEEN 1995 AND 2005

SELECT 
	FirstName,
	LastName
FROM Employees
WHERE NOT JobTitle LIKE '%engineer%'

SELECT 
	[Name]
FROM Towns
WHERE 
	LEN([Name]) = 5 
	OR LEN([Name]) = 6
ORDER BY [Name]

SELECT 
	TownID,
	[Name]
FROM Towns
WHERE 
	LEFT([Name], 1) = 'M'
	OR LEFT([Name], 1) = 'K'
	OR LEFT([Name], 1) = 'B'
	OR LEFT([Name], 1) = 'E'
ORDER BY [Name]

SELECT 
	TownID,
	[Name]
FROM Towns
WHERE 
	LEFT([Name], 1) != 'B'
	AND LEFT([Name], 1) != 'R'
	AND LEFT([Name], 1) != 'D'
ORDER BY [Name]

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT 
	FirstName,
	LastName
FROM Employees
WHERE YEAR(HireDate) > 2000

SELECT 
	FirstName,
	LastName
FROM Employees
WHERE LEN(LastName) = 5

SELECT 
	EmployeeID,
	FirstName,
	LastName,
	Salary,
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE 
	Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

SELECT * 
FROM 
	(
		SELECT 
			EmployeeID,
			FirstName,
			LastName,
			Salary,
			DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
		FROM Employees
		WHERE 
			Salary BETWEEN 10000 AND 50000
	) AS RANKING_SUBSREING
WHERE [Rank] = 2
ORDER BY Salary DESC	

SELECT 
	CountryName,
	IsoCode
FROM Countries
WHERE LOWER(CountryName) LIKE '%a%a%a%'
ORDER BY IsoCode


SELECT 
	p.PeakName,
	r.RiverName,
	LOWER(CONCAT(SUBSTRING(PeakName, 1, LEN(PeakName)-1), RiverName)) AS Mix
FROM Rivers AS r,
	 Peaks AS p
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix

SELECT TOP (50)
	[Name],
	FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE YEAR([Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]

SELECT 
	Username,
	SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) as [Email Provider]
FROM Users
ORDER BY [Email Provider], Username

SELECT 
	Username,
	IpAddress
FROM Users
ORDER BY Username

SELECT 
	Username,
	IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

SELECT 
	[Name] as Game,
	CASE
		WHEN DATEPART(HOUR, g.Start) BETWEEN 0 AND 12 THEN 'Morning'
		WHEN DATEPART(HOUR, g.Start) BETWEEN 12 AND 17 THEN 'Afternoon'
		ELSE 'Evening'
	END AS [Part of the Day],
	CASE 
		WHEN Duration <= 3 THEN 'Extra Short' 
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
	END AS [Duration]
FROM Games AS g
ORDER BY g.[Name], [Duration], [Part of the Day]


SELECT 
	[Name] as Game,
	CASE
		WHEN DATEPART(HOUR, g.Start) BETWEEN 0 AND 12 THEN 'Morning'
		WHEN DATEPART(HOUR, g.Start) BETWEEN 12 AND 17 THEN 'Afternoon'
		ELSE 'Evening'
	END AS [Part of the Day],
	CASE 
		WHEN Duration <= 3 THEN 'Extra Short' 
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
	END AS [Duration]
FROM Games AS g
ORDER BY Game, [Duration], [Part of the Day]

SELECT [Name] AS Game,
	CASE
		WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
		ELSE 'Evening'
	END AS [Part of the Day],
	CASE
		WHEN [Duration] <= 3 THEN 'Extra Short'
		WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
		WHEN [Duration] > 6 THEN 'Long'
		ELSE 'Extra Long'
	END AS [Duration]
FROM [Games] AS [g]
ORDER BY [g].[Name], [Duration], [Part of the Day]

SELECT 
	ProductName,
	OrderDate,
	DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders

CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(20) NOT NULL,
	Birthdate DATE
)

INSERT INTO People([Name], Birthdate)
VALUES
	('Victor', '2000-12-07 00:00:00.000'), 
	('Steven', '1992-09-10 00:00:00.000'),
	('Stephen', '1910-09-19 00:00:00.000'),
	('John', '2010-01-06 00:00:00.000')

SELECT 
	[Name],
	DATEDIFF(YEAR, Birthdate, '2016-12-08') AS [Age in Years],
	DATEDIFF(MONTH, Birthdate, '2016-12-08') AS [Age in Months],
	DATEDIFF(DAY, Birthdate, '2016-12-08') AS [Age in Days],
	DATEDIFF(MINUTE, Birthdate, '2016-12-08') AS [Age in Minutes]
FROM People