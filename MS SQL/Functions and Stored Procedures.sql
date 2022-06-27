CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS 
SELECT
	FirstName,
	LastName
FROM Employees
WHERE Salary > 35000


CREATE PROC usp_GetEmployeesSalaryAboveNumber
	(@num DECIMAL(18, 4))
AS 
SELECT
	FirstName,
	LastName
FROM Employees
WHERE Salary >= @num

CREATE OR ALTER PROC usp_GetTownsStartingWith
	(@string VARCHAR(50))
AS 
SELECT 
	[Name] AS Town
FROM Towns 
WHERE [Name] LIKE @string + '%'

CREATE PROC usp_GetEmployeesFromTown
	(@townName VARCHAR(50))
AS
SELECT 
	e.FirstName,
	e.LastName
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
WHERE t.[Name] = @townName

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(8)
AS 
BEGIN
	DECLARE @result VARCHAR(8)

	IF @salary < 30000
	BEGIN
		SET @result = 'Low'
	END
	ELSE IF @salary BETWEEN 30000 AND 50000
	BEGIN 
		SET @result = 'Average'
	END
	ELSE IF @salary > 50000
	BEGIN
		SET @result = 'High'
	END

	RETURN @result
END

CREATE PROC usp_EmployeesBySalaryLevel
	(@level VARCHAR(8))
AS
IF @level = 'Low'
BEGIN
	SELECT 
		FirstName,
		LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = 'Low'
END
ELSE IF @level = 'Average'
BEGIN
	SELECT 
		FirstName,
		LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = 'Average'
END
ELSE IF @level = 'High'
BEGIN
	SELECT 
		FirstName,
		LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = 'High'
END

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS CHAR(1)
AS 
BEGIN
	IF @setOfLetters
END

EXEC usp_EmployeesBySalaryLevel 'High'

SELECT 
	FirstName,
	LastName,
	Salary,
	dbo.ufn_GetSalaryLevel(Salary)
FROM Employees

SELECT *
FROM Employees

GO

CREATE PROC usp_GetHoldersFullName
AS 
SELECT 
	CONCAT(FirstName, ' ', LastName) AS [Full Name]
FROM AccountHolders 
Go

CREATE PROC usp_GetHoldersWithBalanceHigherThan
	(@num DECIMAL)
AS
SELECT 
	ah.FirstName,
	ah.LastName
FROM AccountHolders AS ah
JOIN Accounts AS a ON ah.Id = a.AccountHolderId
WHERE a.Balance > @num
ORDER BY FirstName, LastName

GO

CREATE OR ALTER FUNCTION ufn_CalculateFutureValue
	(@sum DECIMAL, @yearlyInterestRate FLOAT,  @theNumberOfYears INT)
RETURNS DECIMAL(20,4)
AS
BEGIN
	DECLARE @result DECIMAL(20,4)
	SET @result = @sum * POWER((1 + @yearlyInterestRate), @theNumberOfYears)
	RETURN @result
END

EXEC usp_GetHoldersWithBalanceHigherThan 15346

SELECT 
	dbo.ufn_CalculateFutureValue(1000, 0.1, 5)
FROM Accounts