CREATE PROCEDURE listBillSaleDetail
	-- Add the parameters for the stored procedure here
	@bill_id Bigint
	
AS
BEGIN

SELECT         *
FROM         saleDetails
WHERE  (bill_id=@bill_id);
	
END
GO;

CREATE PROCEDURE listBillDate
	-- Add the parameters for the stored procedure here
	@date_init datetime,
	@date_end datetime
	
AS
BEGIN

SELECT         *
FROM         bills
WHERE  date_bill BETWEEN @date_init AND @date_end;
	
END
GO;
CREATE PROCEDURE customerBill
	-- Add the parameters for the stored procedure here
	@customer_Id bigint
	
AS
BEGIN

SELECT         *
FROM         bills
WHERE  (customer_id=@customer_id);
	
END
GO;