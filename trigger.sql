CREATE TRIGGER tr_update_product_stock
ON saleDetails
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF (SELECT COUNT(*) FROM inserted) > 0
    BEGIN
        DECLARE @old_quantity INT, @new_quantity INT;
        SELECT @old_quantity = quantity FROM deleted;
        SELECT @new_quantity = quantity FROM inserted;
        
        IF @old_quantity <> @new_quantity
        BEGIN
            UPDATE products
            SET stock = stock + (@old_quantity - @new_quantity)
            WHERE reference = (SELECT product_id FROM inserted)
        END
        
        IF EXISTS (SELECT * FROM inserted WHERE state = 1)
        BEGIN
            UPDATE products
            SET stock = stock - (SELECT quantity FROM inserted)
            WHERE reference = (SELECT product_id FROM inserted)
        END

        IF EXISTS (SELECT * FROM inserted WHERE state = 0)
        BEGIN
            UPDATE products
            SET stock = stock + (SELECT quantity FROM inserted)
            WHERE reference = (SELECT product_id FROM inserted)
        END
    END
END