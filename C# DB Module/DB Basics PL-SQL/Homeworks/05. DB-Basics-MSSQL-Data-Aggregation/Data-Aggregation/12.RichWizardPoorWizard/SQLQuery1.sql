SELECT SUM(DepositAmount - NextAmount) AS [SumDifference]
  FROM (SELECT 
			DepositAmount , 
			LEAD (DepositAmount) OVER (ORDER BY Id) AS NextAmount
		FROM WizzardDeposits
		) AS WizzardDeposits