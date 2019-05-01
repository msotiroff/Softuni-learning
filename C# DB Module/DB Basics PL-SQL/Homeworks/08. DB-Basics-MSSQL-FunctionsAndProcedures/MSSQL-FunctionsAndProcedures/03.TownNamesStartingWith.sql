CREATE PROC dbo.usp_GetTownsStartingWith @BeginWith VARCHAR(MAX)

AS

SELECT 
		t.Name
	FROM Towns AS t
	WHERE LEFT(t.Name, LEN(@BeginWith)) LIKE @BeginWith