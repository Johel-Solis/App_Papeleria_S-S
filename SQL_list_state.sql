CREATE PROCEDURE listStatetUser 
	-- Add the parameters for the stored procedure here
	@state int
	
AS
BEGIN

	SELECT        *
	FROM         users
	WHERE  (state=@state);
	
END
GO;


CREATE PROCEDURE listStateCustomer
	-- Add the parameters for the stored procedure here
	@state int
	
AS
BEGIN

   SELECT      *
FROM          customers
WHERE  (state=@state);
	
END
GO;

CREATE PROCEDURE listStateProvider
	-- Add the parameters for the stored procedure here
	@state int
AS
BEGIN

SELECT        *
FROM         providers
WHERE  (state=@state);
END
GO;


CREATE PROCEDURE listStateCategory
	-- Add the parameters for the stored procedure here
	
	@state int
AS
BEGIN

SELECT        *
FROM      categories
WHERE  (state=@state);	
END
GO;

CREATE PROCEDURE listStateProduct
	-- Add the parameters for the stored procedure here
	@state int
AS
BEGIN

SELECT         *
FROM        products
WHERE  (state=@state);
	
END
GO;

CREATE PROCEDURE listStateSaleDetail
	-- Add the parameters for the stored procedure here
	@state int
	
AS
BEGIN

SELECT         *
FROM         saleDetails
WHERE  (state=@state);
	
END
GO;

CREATE PROCEDURE nlistStateBill
	-- Add the parameters for the stored procedure here
	@state int
AS
BEGIN

SELECT        *
FROM            bills
WHERE  (state=@state);
	
END
GO;
