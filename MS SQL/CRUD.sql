CREATE TABLE [Users] (
	[Id] INT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	CHECK (DATALENGTH([Password]) > 5),
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] TIME,
	[IsDeleted] VARCHAR(5),
	CHECK ([IsDeleted] = 'true' OR [IsDeleted] = 'false')
)

INSERT INTO
	[Users] ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES
	('Gosheto', '123', NULL, '15:45:25', 'false'),
	('Mariq', 'mariq123', NULL, '23:15:15', 'false'),
	('Fado', 'STRONGPASSWORD123!haha', NULL, '12:30:23', 'false'),
	('Bagi', '321', NULL, '16:45:25', 'true'),
	('Miteto', '123', NULL, '10:55:25', 'false')

UPDATE [Users]
SET [Username] = 'Baginator'
WHERE [Id] = 4

SELECT 
	[Username] AS [Име на потребителя],
	[Password] AS [Парола],
	[IsDeleted] As [Акаунта е изтрит]
FROM [Users]

SELECT * FROM [Departments]

SELECT [Name] FROM [Departments]

SELECT 
	[FirstName],
	[LastName],
	[Salary]
FROM [Employees]

SELECT 
	[FirstName],
	[MiddleName],
	[LastName]
FROM [Employees]

SELECT 
	CONCAT([FirstName], '.', [LastName], '@softuni.bg') AS ["Full Email Address]
FROM [Employees]

SELECT 
	DISTINCT [Salary]
FROM [Employees]

SELECT *
FROM [Employees]
WHERE [JobTitle] = 'Sales Representative'

SELECT 
	[FirstName],
	[LastName],
	[JobTitle]
FROM [Employees]
WHERE [Salary] BETWEEN 20000 AND 30000

SELECT 
	CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName]) AS [Full Name]
FROM [Employees]
WHERE [Salary] = 25000 OR [Salary] = 14000 OR [Salary] = 12500 OR [Salary] = 23600 

SELECT 
	[FirstName],
	[LastName]
FROM [Employees]
WHERE [ManagerID] IS NULL

SELECT 
	[FirstName],
	[LastName],
	[Salary]
FROM [Employees]
WHERE [Salary] > 50000
ORDER BY [Salary] DESC

SELECT TOP (5)
	[FirstName],
	[LastName]
FROM [Employees]
ORDER BY [Salary] DESC

SELECT 
	[FirstName],
	[LastName]
FROM [Employees]
WHERE [DepartmentID] != 4 

SELECT *
FROM [Employees]
ORDER BY
	Salary DESC, 
	FirstName , 
	LastName DESC,
	MiddleName 

CREATE VIEW v_EmployeeSalary AS
SELECT 
	[FirstName],
	[LastName],
	[Salary]
FROM [Employees] 

SELECT FirstName FROM v_EmployeeSalary

CREATE VIEW V_EmployeesSalaries AS
SELECT 
	[FirstName],
	[LastName],
	[Salary]
FROM [Employees] 

CREATE VIEW V_EmployeeNameJobTitle AS
SELECT 
	CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName]) AS [Full Name],
	JobTitle
FROM [Employees]

SELECT DISTINCT 
	JobTitle
FROM [Employees]

SELECT TOP (10) *
FROM [Projects]
ORDER BY StartDate, [Name]

SELECT TOP (7) 
	[FirstName],
	[LastName],
	HireDate
FROM [Employees]
ORDER BY [HireDate] desc


-- MODIFYING DATA 
INSERT INTO
	Towns ([Name])
VALUES 
	('Burgas'),
	('Varna'),
	('Ruse')

INSERT INTO
	Towns ([Name]) 
SELECT [Name]
FROM Towns
WHERE TownID BETWEEN 1 AND 10

SELECT 
	FirstName,
	LastName,
	JobTitle
INTO
	EmployeesInfo
FROM [Employees]

DELETE FROM Towns WHERE TownID > 32

TRUNCATE TABLE EmployeesInfo

UPDATE Towns
SET [Name] = 'Rodeman'
WHERE TownID = 1

UPDATE Employees
SET Salary = Salary + (Salary + 0.12)
WHERE DepartmentID = 12 OR DepartmentID = 4 OR DepartmentID = 46 OR DepartmentID = 42

SELECT Salary FROM Employees

SELECT PeakName
FROM Peaks
ORDER BY PeakName

SELECT TOP (30)
	CountryName
	,[Population]
FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY 
	[Population] DESC,
	CountryName

SELECT 
	CountryName,
	CountryCode,
	CASE 
		WHEN CurrencyCode != 'EUR' THEN 'Not Euro'
		WHEN CurrencyCode = 'EUR' THEN 'Euro'
	END AS [Currency]
FROM Countries
WHERE CurrencyCode IS NOT NULL
ORDER BY CountryName DESC

SELECT * FROM V_EmployeeNameJobTitle
SELECT * FROM Characters

SELECT [Name] 
FROM Characters
ORDER BY [Name]