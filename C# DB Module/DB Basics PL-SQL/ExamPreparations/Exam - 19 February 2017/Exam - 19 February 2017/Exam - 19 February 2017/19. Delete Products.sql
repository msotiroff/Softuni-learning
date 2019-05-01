CREATE TRIGGER tr_DeleteProduct ON Products
INSTEAD OF DELETE
AS

	DELETE FROM Feedbacks WHERE ProductId = (SELECT Id FROM deleted)
	DELETE FROM ProductsIngredients WHERE ProductId = (SELECT Id FROM deleted)
	DELETE FROM Products WHERE Id = (SELECT Id FROM deleted)


--BEGIN TRAN

--DELETE FROM Products WHERE Id = 7

--ROLLBACK