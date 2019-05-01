SELECT MIN(AvgSalary) FROM
(
	SELECT 
			DepartmentID, AVG(Salary) AS AvgSalary
		FROM Employees
		GROUP BY DepartmentID
		) AS AvgSalariesByDepartment