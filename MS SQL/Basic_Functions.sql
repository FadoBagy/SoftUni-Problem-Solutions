SELECT
	ROW_NUMBER() OVER (ORDER BY e.JobTitle) AS [Row Number],
	CONCAT(e.FirstName, ' ', e.LastName) AS [Name],
	e.JobTitle,
	RANK() OVER (ORDER BY e.JobTitle) AS [Rank],
	DENSE_RANK() OVER (ORDER BY e.JobTitle) AS [Dense Rank]
FROM Employees AS e
JOIN Addresses AS a ON
	e.AddressID = a.AddressID

SELECT 
	SUBSTRING(FirstName, 1, 3)
FROM Employees


SELECT 
	FirstName,
	LastName
FROM Employees
WHERE SUBSTRING(FirstName, 1, 1) = 'M'
ORDER BY FirstName, LastName

SELECT 
	FirstName,
	CONCAT(LEFT(LastName, 1), REPLICATE('*', 4))
FROM Employees

SELECT 
	HireDate,
	GETDATE() AS CurrentDate,
	DATEDIFF(YEAR, HireDate, GETDATE()) AS YearsOfService
FROM Employees

SELECT 
	FirstName
FROM Employees
WHERE FirstName LIKE '%e%'