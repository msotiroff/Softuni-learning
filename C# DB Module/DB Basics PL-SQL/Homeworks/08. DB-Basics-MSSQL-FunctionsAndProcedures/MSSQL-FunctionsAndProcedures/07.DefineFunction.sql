CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))

RETURNS BIT

AS

BEGIN

	DECLARE @Result BIT = 1
	DECLARE @WordLenght INT = LEN(@word)
	DECLARE @StartIndex INT = 1
	DECLARE @CurrentChar VARCHAR(1)

	WHILE @StartIndex <= @WordLenght
		BEGIN

			SET @CurrentChar = SUBSTRING(@word, @StartIndex, 1)
			IF (@setOfLetters LIKE '%' + @CurrentChar + '%')
				BEGIN
					SET @StartIndex += 1
					CONTINUE
				END
			ELSE
				BEGIN
					SET @Result = 0
					RETURN @Result
				END
		END

	RETURN @Result
END