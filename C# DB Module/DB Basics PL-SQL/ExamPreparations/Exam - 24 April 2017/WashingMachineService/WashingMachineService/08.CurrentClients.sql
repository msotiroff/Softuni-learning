SELECT
		cl.FirstName + ' ' + cl.LastName AS [Client],
		DATEDIFF(DAY, j.IssueDate, '20170424') AS [Days going],
		j.Status
	FROM Clients AS cl
	INNER JOIN Jobs AS j
	ON j.ClientId = cl.ClientId
WHERE j.Status <> 'Finished'