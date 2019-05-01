CREATE FUNCTION udf_GetRadians (@Degrees FLOAT)
RETURNS FLOAT
AS
BEGIN

	DECLARE @Result FLOAT
	SET @Result = RADIANS (@Degrees)
	RETURN @Result  

END

--SELECT dbo.udf_GetRadians(22.12) AS Radians