CREATE PROCEDURE listUser 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN

	SELECT         *
	FROM            users;
	
	
END
GO;

CREATE PROCEDURE listPerson
	-- Add the parameters for the stored procedure here
		 
AS
BEGIN

	SELECT         *
	FROM            persons;
END
GO;

CREATE PROCEDURE listCustomer
	-- Add the parameters for the stored procedure here
	
AS
BEGIN

   SELECT         *
   FROM           customers;	
	
END
GO;

CREATE PROCEDURE listProvider
	-- Add the parameters for the stored procedure here
	
AS
BEGIN

	SELECT         *
	FROM           providers;
	
END
GO;


CREATE PROCEDURE listCategory
	-- Add the parameters for the stored procedure here
	
	
AS
BEGIN

SELECT        *
FROM         categories;

	
END
GO;

CREATE PROCEDURE listProduct
	-- Add the parameters for the stored procedure here
	
AS
BEGIN

SELECT        *
FROM            products;
	
END
GO;

CREATE PROCEDURE listSaleDetail
	-- Add the parameters for the stored procedure here
AS
BEGIN

SELECT       *
FROM       saleDetails;
	
END
GO;

CREATE PROCEDURE listBill
	-- Add the parameters for the stored procedure here
	
AS
BEGIN

SELECT         *
FROM           bills;

	
END
GO;
