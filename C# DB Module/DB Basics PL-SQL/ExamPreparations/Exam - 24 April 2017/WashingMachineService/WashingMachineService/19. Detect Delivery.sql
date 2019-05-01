CREATE TRIGGER tr_DetectDelivery ON Orders
FOR UPDATE
AS

DECLARE @OldDeliveryStatus BIT = (SELECT Delivered FROM deleted)
DECLARE @NewDeliveryStatus BIT = (SELECT Delivered FROM inserted)

IF (@OldDeliveryStatus = 0 AND @NewDeliveryStatus = 1)
BEGIN
	UPDATE Parts
	SET StockQty += op.Quantity
		FROM Parts AS p
		JOIN OrderParts AS op ON p.PartId = op.PartId
		JOIN Orders AS o ON o.OrderId = op.OrderId
		JOIN deleted AS d ON d.OrderId = o.OrderId
		JOIN inserted AS ins ON ins.OrderId = o.OrderId
		WHERE d.Delivered = 0 AND ins.Delivered = 1
END


--BEGIN TRAN
--UPDATE Orders
--SET Delivered = 1
--WHERE OrderId = 21
--ROLLBACK
-----------------------
--BEGIN TRAN
--UPDATE Orders
--SET Delivered = 0
--WHERE OrderId = 21
--ROLLBACK