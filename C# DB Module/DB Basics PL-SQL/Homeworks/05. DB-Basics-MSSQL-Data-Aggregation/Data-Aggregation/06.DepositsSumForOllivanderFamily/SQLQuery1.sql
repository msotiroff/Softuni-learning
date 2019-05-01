SELECT 
	DepositGroup,
	SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
WHERE MagicWandCreator LIKE '%Ollivander%'
GROUP BY DepositGroup