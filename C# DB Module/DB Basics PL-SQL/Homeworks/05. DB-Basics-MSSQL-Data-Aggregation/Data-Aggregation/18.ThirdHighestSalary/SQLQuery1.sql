SELECT
	e.DepartmentID,
	E.Salary
	AS [TopSalaries]
FROM (
		SELECT
			DepartmentID,
			MAX(Salary) AS [Salary],
			DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS [Ranking]
		FROM Employees
		GROUP BY DepartmentID, Salary
) AS e
WHERE e.Ranking = 3