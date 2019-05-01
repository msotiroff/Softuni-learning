SELECT 
		e.EmployeeID,
		e.FirstName,
		CASE
			WHEN p.StartDate >= '20050101' THEN NULL
			ELSE p.Name
		END AS ProjectName
FROM Employees AS e
	INNER JOIN EmployeesProjects AS ep
	ON ep.EmployeeID = e.EmployeeID
	INNER JOIN Projects AS p
	ON p.ProjectID = ep.ProjectID
WHERE ep.EmployeeID = 24
	