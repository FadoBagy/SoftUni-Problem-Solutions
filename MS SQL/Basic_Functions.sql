-- ROW_NUMBER() creates count by specific order 
-- RANK() creates count by specific order, takes the ROW NUMBER for the next RANK, this helps to know how much data was in the previous rank by dividing it
-- DENSE_RANK() does the same as RANK(), but continues the count normally
SELECT
	ROW_NUMBER() OVER (ORDER BY e.JobTitle) AS [Row Number],
	CONCAT(e.FirstName, ' ', e.LastName) AS [Name],
	e.JobTitle,
	RANK() OVER (ORDER BY e.JobTitle) AS [Rank],
	DENSE_RANK() OVER (ORDER BY e.JobTitle) AS [Dense Rank]
FROM Employees AS e
JOIN Addresses AS a ON
	e.AddressID = a.AddressID

-- SUBSTRING() takes 3 arguments - From what to make the subsrting, from what index to start, to what length to end (indexing start from 1!)
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