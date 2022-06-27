SELECT TOP(5)
	EmployeeID,
	JobTitle,
	e.AddressID,
	a.AddressText
FROM Employees AS e
FULL JOIN Addresses AS a ON
	e.AddressID = a.AddressID
ORDER BY e.AddressID


SELECT TOP(50)
	e.FirstName,
	e.LastName,
	t.[Name],
	a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY FirstName, LastName

SELECT 
	EmployeeID,
	FirstName,
	LastName,
	d.[Name]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY EmployeeID 

SELECT TOP(5)
	EmployeeID,
	FirstName,
	Salary,
	d.[Name]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE Salary > 15000
ORDER BY e.DepartmentID

SELECT TOP 3
	e.EmployeeID,
	FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ProjectID IS NULL
ORDER BY e.EmployeeID

SELECT 
	FirstName,
	LastName,
	HireDate,
	d.[Name]
FROM Employees AS E
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE HireDate > '1999-01-01' AND Name IN ('Sales', 'Finance')
ORDER BY HireDate

SELECT TOP 5
	ep.EmployeeID,
	e.FirstName,
	p.[Name] AS [ProjectName]
FROM EmployeesProjects AS ep
JOIN Projects AS p ON ep.ProjectID = p.ProjectID 
JOIN Employees AS e ON ep.EmployeeID = e.EmployeeID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY ep.EmployeeID

SELECT
	ep.EmployeeID,
	e.FirstName,
	CASE 
		WHEN p.StartDate >= '2005' THEN NULL 
		ELSE p.[Name]
	END AS [ProjectName]
FROM EmployeesProjects AS ep
JOIN Projects AS p ON ep.ProjectID = p.ProjectID 
JOIN Employees AS e ON ep.EmployeeID = e.EmployeeID
WHERE ep.EmployeeID = 24 

SELECT 
	e.EmployeeID,
	e.FirstName,
	e.ManagerID,
	m.FirstName
FROM Employees AS e 
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
	AND e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID

SELECT TOP 50
	e.EmployeeID,
	CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
	CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
	d.[Name]
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

SELECT 
	MIN(dt.Salary) AS MinAverageSalary
FROM (
	SELECT
		AVG(Salary) AS Salary
	FROM Employees
	GROUP BY DepartmentID
) AS dt

SELECT 
	c.CountryCode,
	m.MountainRange,
	p.PeakName,
	p.Elevation
FROM MountainsCountries AS mc
JOIN Countries AS c ON mc.CountryCode = c.CountryCode
	AND c.CountryCode = 'BG'
JOIN Mountains AS m ON m.Id = mc.MountainId
JOIN Peaks AS p ON p.MountainId = m.Id
	AND p.Elevation > 2835
ORDER BY p.Elevation DESC

SELECT 
	[c].[CountryCode],
	COUNT([mc].[MountainId])
FROM [Countries] AS [c]
JOIN [MountainsCountries] AS [mc] 
	ON [c].[CountryCode] = [mc].[CountryCode]
	AND c.CountryCode IN ('BG', 'RU', 'US')
GROUP BY c.CountryCode

SELECT TOP 5
	c.CountryName,
	r.RiverName
FROM Countries  AS c 
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode 
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName
	
SELECT 
	COUNT(c.CountryCode) AS [Count]
FROM Countries AS c 
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
WHERE mc.MountainId IS NULL

SELECT TOP 5
	c.CountryName,
	MAX(p.Elevation) AS HighestPeakElevation,
	MAX(r.Length) AS LongestRiverLength
FROM Countries AS c 
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode 
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
LEFT JOIN Peaks AS p ON p.MountainId = m.id
LEFT JOIN Rivers AS r ON cr.RiverId  = r.Id
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC

SELECT * 
FROM Countries 